using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace lab4
{
    static class WorkWithFile
    {
        public static void FillBinFile(string path) // заполняет бинарный файл случайными числами
        {
            int size;
            int tmp;
            Random rnd = new Random();
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            BinaryWriter binaryWriter = new BinaryWriter(fs);

            Console.WriteLine("Сколько элементов записать?");
            size = int.Parse(Console.ReadLine());

            Console.WriteLine("Записываем в бинарный файл");
            for (int i = 0; i < size; i++)
            {
                tmp = rnd.Next(1,100);
                Console.WriteLine(tmp);
                binaryWriter.Write(tmp);
            }

            fs.Close();
        }

        public static void FillBinFileWithToys(string path) // заполняет файл игрушками
        { 
            int size = 10;
            Toy[] toys = new Toy[size];

            for (int i = 0; i < size; i++)
                toys[i] = new Toy();

            XmlSerializer xml = new XmlSerializer(toys.GetType());
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            xml.Serialize(fs, toys);

            fs.Close();
        }
        public static void ReadBinFile(string path, List<int> list) // считывает целые числа из бинарного файла
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fs);

            Console.WriteLine("Читаем из бинарного файла");

            while (binaryReader.PeekChar() > -1) // метод PeekChar считывает следующий символ и возвращает его числовое представление. Если символ отсутствует, то метод возвращает -1 что будет означать, что мы достигли конца файла.
                list.Add(binaryReader.ReadInt32());

            fs.Close();
        }

        public static void ChooseToy(string path, int age) // выбирает подходящую игрушку
        {
            const int size = 10;
            Toy[] toys = new Toy[size];

            XmlSerializer xml = new XmlSerializer(toys.GetType());
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            toys = xml.Deserialize(fs) as Toy[];

            Console.WriteLine("\nСписок всех игрушек: ");
            foreach (Toy item in toys)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < size; i++)
                if (toys[i].Name != "Мяч" && toys[i].LowerAgeLimit < age && toys[i].UpperAgeLimit > age)
                {
                    Console.WriteLine("Подходящая игрушка: ");
                    Console.WriteLine(toys[i]);
                    break;
                }

            fs.Close();
        }

        public static void CopyToMatrix(string path) // Скопировать элементы заданного файла в квадратную матрицу размером n x n
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fs);

            int n;
            Console.WriteLine("Введите n: ");
            n = int.Parse(Console.ReadLine());

            int[,] arr = new int[n, n];
            Console.WriteLine("Читаем из бинарного файла");

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (binaryReader.PeekChar() > -1)
                        arr[i, j] = binaryReader.ReadInt32();
                    else arr[i, j] = 0;
                }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(String.Format("{0,4}", arr[i, j]));
                Console.WriteLine();
            }

            Console.WriteLine("Cтолбец, где произведение элементов дальше всего от нуля: " + (ColumnIndex(arr)+1));

            fs.Close();
        }

        public static void CreateNewFile(string pathOfNewFile, string path) // Получить в другом файле последовательного доступа все компоненты исходного файла, кроме тех, которые кратны k
        {
            List<int> list = new List<int>();
            Console.WriteLine("Введите k: ");
            int k = int.Parse(Console.ReadLine());
            StreamWriter sw = new StreamWriter(pathOfNewFile, false);

            ReadBinFile(path, list);

            foreach (int item in list)
            {
                if ((item % k) != 0)
                    sw.WriteLine(item);
            }
            sw.Close();
        }


        private static int ColumnIndex(int[,] arr) // возвращет индек столбца в котором произведение элементов дальше всего от нуля
        {
            int columns = arr.GetLength(1);
            int[] summ = new int[columns];
            for (int i = 0; i < summ.GetLength(0); i++)
                summ[i] = 1;

            for (int i = 0, k = 0; i < arr.GetLength(1); i++, k++)
                for (int j = 0; j < arr.GetLength(0); j++)
                    summ[k] *= arr[j, i];

            Console.WriteLine();
            foreach (int item in summ)
            {
                Console.WriteLine(item);
            }

            int max = summ.Max();
            int index = summ.ToList().IndexOf(max);
            return index;
        }

        public static void SummMaxMin(string path) // сумма максимального и минимального элемента в текстовом файле
        {
            List<int> list = new List<int>();
            StreamReader sr = new StreamReader(path);

            while(!sr.EndOfStream)
                list.Add(int.Parse(sr.ReadLine()));
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Min());
            int summ = list.Max() + list.Min();
            Console.WriteLine("Сумма максимального и минимального элемента: " + summ);
            sr.Close();
        }

        public static void SummEven(string path) // сумма всех чётных элементов в текстовом файле
        {
            List<int> list = new List<int>();
            StreamReader sr = new StreamReader(path);
            string str;
            string[] tmp;
            int summ = 0;
            while (!sr.EndOfStream)
            {
                str = sr.ReadLine();
                tmp = str.Split(" ");
                foreach (string item in tmp)
                {
                    list.Add(int.Parse(item));
                }
            }

            foreach (int item in list)
            {
                if (item % 2 == 0)
                    summ += item;
            }

            Console.WriteLine("Сумма всех четных элементов: " + summ);

            sr.Close();
        }

        public static void CreateNewFileWithFirstElemOfString(string path, string pathNewFile) // создаёт новый файл, каждая строка которого содержит первый символ соответствующей строки исходного файла.
        {
            StreamReader sr = new StreamReader(path);
            StreamWriter sw = new StreamWriter(pathNewFile, false);
            string str;
            while (!sr.EndOfStream)
            {
                str = sr.ReadLine();
                sw.WriteLine(str[0]);
            }
            sr.Close();
            sw.Close();
        }
    }
}
