using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_5_test
{
    public class Animals : IDhelper
    {
        private int id;
        private string type;
        private string breed;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }


        public Animals(int ID, string Type, string Breed)
        {
            this.id = ID;
            this.type = Type;
            this.breed = Breed;
        }

        public Animals()
        {
        }


        // Перегрузка ToString 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string cellid = $"{ID}";
            sb.Append(cellid.PadRight(15)); // Отступ между колонками
            string celltp = $"{Type}";
            sb.Append(celltp.PadRight(15));
            string cellbr = $"{Breed}";
            sb.Append(cellbr.PadRight(15));

            return sb.ToString();
        }

    }
}
