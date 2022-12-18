using System;


namespace lab4
{
    [Serializable]
    public class Toy
    {
        string name;
        int price;
        int lowerAgeLimit;
        int upperAgeLimit;
        static string[] namesOfToys = { "Мяч", "Конструктор", "Кукла", "Машинка" };

        public string Name { 
            get { return this.name; }
            set { this.name = value; }
        }

        public int Price 
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public int LowerAgeLimit
        {
            get { return this.lowerAgeLimit; }
            set { this.lowerAgeLimit = value; }
        }

        public int UpperAgeLimit
        {
            get { return this.upperAgeLimit; }
            set { this.upperAgeLimit = value; }
        }

        public Toy()
        {
            Random rnd = new Random();
            
            this.name = namesOfToys[rnd.Next(0,3)];
            this.price = rnd.Next(500, 5000);
            this.lowerAgeLimit = rnd.Next(0,7);
            this.upperAgeLimit = rnd.Next(7, 12);
        }

        public override string ToString()
        {
            Console.WriteLine(this.name);
            Console.WriteLine("Цена: "+this.price);
            Console.WriteLine("От "+this.lowerAgeLimit +" до "+ this.upperAgeLimit);
            return null;
        }
    }
}
