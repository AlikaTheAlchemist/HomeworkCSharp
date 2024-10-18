using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_2_NUM_2
{
    internal class Money
    {
        // поля для хранения рублей и копеек
        private uint rubles;
        private byte kopeks;

        // аксесоры
        public uint Rubles
        {
            get { return rubles; }
            set { rubles = value; }
        }

        public byte Kopeks
        {
            get { return kopeks; }
            set { kopeks = value; }
        }

        // конструктор без параметров
        public Money()
        {
            this.rubles = 0;
            this.Kopeks = 0; 
        }

        // конструктор с параметром
        public Money(uint rubles, byte kopeks)
        {
            this.rubles = rubles;
            this.Kopeks = kopeks; 
        }

        // конструктор копирования
        public Money(Money a)
        {
            this.rubles = a.rubles;
            this.Kopeks = a.Kopeks;
        }

        // добавление копеек
        public void AddKopeks(uint additionalKopeks)
        {
            // общее количество копеек после добавления
            uint totalKopeks = (uint)this.kopeks + additionalKopeks;

            // рассчитываем новые рубли и копейки
            this.Rubles = this.rubles + totalKopeks / 100;
            this.Kopeks = (byte)(totalKopeks % 100);
        }

        // to string
        public override string ToString()
        {
            return $"{rubles} руб. {kopeks:00} коп.";
        }

        // перегрузка  ++ 
        public static Money operator ++(Money money)
        {
            uint totalKopeks = (uint)money.kopeks + 1; 
            uint newRubles = money.rubles + totalKopeks / 100;
            byte newKopeks = (byte)(totalKopeks % 100);

            return new Money(newRubles, newKopeks);
        }

        // перегрузка  -- 
        public static Money operator --(Money money)
        {
            {
                // нужно ли уменьшить копейки
                uint totalKopeks = (uint)money.kopeks; 
                if (totalKopeks == 0)
                {
                    // если копейки ноль уменьшаем рубли и устанавливаем копейки на 99
                    if (money.rubles > 0)
                    {
                        return new Money(money.rubles - 1, 99);
                    }
                    else
                    {
                        // если рубли ноль возвращаем текущее значение 
                        return money;
                    }
                }
                else
                {
                    totalKopeks -= 1; // уменьшаем копейки
                    uint newRubles = money.rubles + totalKopeks / 100; // пересчет рублей
                    byte newKopeks = (byte)(totalKopeks % 100); // новое значение копеек

                    return new Money(newRubles, newKopeks);
                }
            }
        }


        // приведение типа 

        public static implicit operator uint(Money a)  // явное
        {
            return a.rubles;
        }

        public static explicit operator double(Money a) // неявное
        {
            double b = a.kopeks;
            b = b / 100;
            return b;
        }


        // СЛОЖЕНИЕ И ВЫЧИТАНИЕ
        public static Money operator +(Money e1, Money e2)
        {
            uint rubls = e1.rubles + e2.rubles;
            uint kops = (uint)(e1.kopeks + e2.kopeks);

            rubls = rubls + kops / 100;
            byte kop = (byte)(kops % 100);

            return new Money(rubls, kop);
        }

        public static Money operator -(Money e1, Money e2)
        {
            int rubls = (int)e1.rubles - (int)e2.rubles;
            int kops = (int)(e1.kopeks - e2.kopeks);

            if (kops < 0)
            {
                if (rubls >= 0)
                {
                    kops = kops + 100;
                    rubls--;
                }
                else kops = kops * (-1);
            }

            if (rubls < 0)
            {
                rubls = rubls * (-1);
            }

            byte kop = (byte)(kops % 100);
            uint rubs = (uint)(rubls);

            return new Money(rubs, kop);
        }

    }
}
