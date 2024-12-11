using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_5_test
{
    public class Customers : IDhelper
    {
        private int id;
        private string name;
        private int age;
        private string city;


        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public Customers(int ID, string name, int age, string city)
        {
            this.id = ID;
            this.name = name;
            this.age = age;
            this.city = city;
        }

        public Customers()
        {
        }

        // Перегрузка ToString 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string cellid = $"{ID}";
            sb.Append(cellid.PadRight(15)); // Отступ между колонками
            string cellnm = $"{Name}";
            sb.Append(cellnm.PadRight(20));
            string cellag = $"{Age}";
            sb.Append(cellag.PadRight(15));
            string cellct = $"{City}";
            sb.Append(cellct.PadRight(15));

            return sb.ToString();
        }
    }
}
