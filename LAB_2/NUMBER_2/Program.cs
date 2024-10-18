using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_2_NUM_2
{

    public class Programm
    {
        public static void Main(string[] args)      // MAIN
        {
            Console.OutputEncoding = Encoding.UTF8;
            Programm PR = new Programm();
            uint r;
            byte k;

            // тестирование конструктора по умолчанию
            Console.WriteLine("Создание объекта по умолчанию:");
            Money noMoney = new Money();
            Console.WriteLine(noMoney.ToString());


            Console.WriteLine("Создание объекта с вводимыми параметрами:");
            Console.WriteLine("Введите количество рублей:");
            r = PR.ReadUint();
            Console.WriteLine("Введите количество копеек (0-99):");
            k = PR.ReadByte();

            // создание объекта с вводимыми параметрами
            Console.WriteLine("Создание объекта:");
            Money wallet = new Money(r, k);
            Console.WriteLine(wallet.ToString());

            // добавляем  копейки
            Console.WriteLine("Сколько копеек хотите добавить?:");
            r = PR.ReadUint();
            wallet.AddKopeks(r);
            Console.WriteLine("После добавления: " + wallet.ToString());

            // тестирование конструктора копирования
            Console.WriteLine("Копирование объекта:");
            Money newMoney = new Money(wallet);
            Console.WriteLine(newMoney.ToString());

            // тестирование ++
            Console.WriteLine("Добавление копейки с помощью ++:");
            newMoney++;
            Console.WriteLine(newMoney.ToString());

            // тестирование --
            Console.WriteLine("Вычитание копейки с помощью --:");
            newMoney--;
            Console.WriteLine(newMoney.ToString());

            // тестирование uint
            Console.WriteLine("Тестирование операций приведения типа:");
            Console.WriteLine("Рубли:");
            uint rub = newMoney;
            Console.WriteLine(rub);

            // тестирование double
            Console.WriteLine("Копейки:");
            double kop = (double)wallet;
            Console.WriteLine(kop);


            // тестирование сложения
            Console.WriteLine("\nСоздание новых объектов для сложения:");
            Console.WriteLine("Введите рубли и копейки первого объекта:");
            r = PR.ReadUint();
            k = PR.ReadByte();
            Money slagMoney = new Money(r, k);
            Console.WriteLine("Введите рубли и копейки второго объекта:");
            r = PR.ReadUint();
            k = PR.ReadByte();
            Money plusMoney = new Money(r, k);
            Money summMoney = new Money();
            summMoney = slagMoney + plusMoney;
            Console.WriteLine($"Сумма = {summMoney.ToString()}");


            // тестирование вычитания
            Console.WriteLine("\nСоздание новых объектов для вычитания:");
            Console.WriteLine("Введите рубли и копейки первого объекта:");
            uint r1 = PR.ReadUint();
            byte k1 = PR.ReadByte();
            Money umenMoney = new Money(r1, k1);
            Console.WriteLine("Введите рубли и копейки второго объекта:");
            uint r2 = PR.ReadUint();
            byte k2 = PR.ReadByte();
            Money minusMoney = new Money(r2, k2);
            Money razMoney = new Money();
            razMoney = umenMoney - minusMoney;
            Console.WriteLine($"Разность = {razMoney.ToString()}");

        }


        // проверка и ввод рублей
        public uint ReadUint()
        {
            uint value;
            while (!uint.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Ошибка: Введите целое положительное число.");
            }
            return value;
        }

        // проверка и ввод копеек
        public byte ReadByte()
        {
            byte value;
            while (!byte.TryParse(Console.ReadLine(), out value) || value >= 100)
            {
                Console.WriteLine("Ошибка: Введите число от 0 до 99.");
            }
            return value;
        }
    }
    
}
