using System;
using System.Collections.Generic;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> list = new List<int>(); 
                string pathBinFile = "C:\\Users\\kjgug\\source\\repos\\lab4\\lab4\\binfile.dat";
                WorkWithFile.FillBinFile(pathBinFile);
                WorkWithFile.ReadBinFile(pathBinFile, list);

                foreach ( int item in list)
                {
                    Console.WriteLine(item);
                }

                // задание 1
                Console.WriteLine("Задание 1.");
                WorkWithFile.CreateNewFile("C:\\Users\\kjgug\\source\\repos\\lab4\\lab4\\newfile.txt", pathBinFile);
                Console.WriteLine();

                // задание 2
                Console.WriteLine("Задание 2.");
                WorkWithFile.CopyToMatrix(pathBinFile);
                Console.WriteLine();

                //задание 3
                Console.WriteLine("Задание 3.");
                WorkWithFile.FillBinFileWithToys("C:\\Users\\kjgug\\source\\repos\\lab4\\lab4\\seri.xml");
                WorkWithFile.ChooseToy("C:\\Users\\kjgug\\source\\repos\\lab4\\lab4\\seri.xml", 3);
                Console.WriteLine();

                //задание 4
                Console.WriteLine("Задание 4.");
                WorkWithFile.SummMaxMin("C:\\Users\\kjgug\\source\\repos\\lab4\\lab4\\list1.txt");
                Console.WriteLine();

                //задание 5
                Console.WriteLine("Задание 5.");
                WorkWithFile.SummEven("C:\\Users\\kjgug\\source\\repos\\lab4\\lab4\\list2.txt");
                Console.WriteLine();

                //задание 6
                Console.WriteLine("Задание 6.");
                WorkWithFile.CreateNewFileWithFirstElemOfString("C:\\Users\\kjgug\\source\\repos\\lab4\\lab4\\list3.txt", "C:\\Users\\kjgug\\source\\repos\\lab4\\lab4\\list4.txt");
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
