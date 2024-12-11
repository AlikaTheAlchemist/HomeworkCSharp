using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_5_test
{
    public class Sells : IDhelper
    {
        private int id;
        private int Anymalid;
        private int Customerid;
        private DateTime date;
        private int price;


        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int AnymalID
        {
            get { return Anymalid; }
            set { Anymalid = value; }
        }
        public int CustomerID
        {
            get { return Customerid; }
            set { Customerid = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Sells(int ID, int aid, int cid, DateTime date, int price)
        {
            this.id = ID;
            this.Anymalid = aid;
            this.Customerid = cid;
            this.date = date;
            this.price = price;
        }

        public Sells()
        {
        }

        // Перегрузка ToString 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string cellid = $"{id}";
            sb.Append(cellid.PadRight(15)); // Отступ между колонками
            string cellida = $"{Anymalid}";
            sb.Append(cellida.PadRight(15));
            string cellidc = $"{Customerid}";
            sb.Append(cellidc.PadRight(15));
            string celldt = $"{date}";
            sb.Append(celldt.PadRight(20));
            string cellprc = $"{price}";
            sb.Append(cellprc.PadRight(15));

            return sb.ToString();
        }
    }
}
