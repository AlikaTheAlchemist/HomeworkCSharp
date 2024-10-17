//Разработать класс с одним строковым полем. Создать конструктор копирования. Разработать
//метод, приписывающий к полю в начало три знака восклицания. Перегрузить метод ToString()
//для формирования строки из полей класса. Реализовать дочерний класс (его содержание
//предложить самостоятельно и описать в решении: какой содержательный смысл имеют поля;
//реализовать конструкторы; предложить и реализовать 2-3 метода). Протестировать все
//конструкторы и другие методы базового и дочернего классов.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab
{
    public class Programm
    {
        public static void Main(string[] args)      // MAIN
        {

            Console.OutputEncoding = Encoding.UTF8;
            Programm PR = new Programm();
            string text, textinput, numinput = "";
            int score = 0, increse = 0;

            // ввод и проверка строки
            Console.WriteLine("Введите Имя");
            text = Console.ReadLine();
            textinput = PR.StringCheck(text);



            Console.WriteLine("\nТестирование базового класса:");
            // тестирование базового класса
            Console.WriteLine("Создание объекта:");
            CastomString baseString = new CastomString(textinput);
            Console.WriteLine(baseString.ToString());

            Console.WriteLine("Тестирование метода на добавление восклицательных знаков:");
            baseString.ExclamationMark();
            Console.WriteLine(baseString.ToString());

            // копирование объекта
            Console.WriteLine("Тестирование копирования объекта:");
            CastomString baseCopy = new CastomString(baseString);
            Console.WriteLine($"Оригинал строки: {baseString.ToString()}");
            Console.WriteLine($"Копия строки: {baseCopy.ToString()}");




            Console.WriteLine("\nТестирование дочернего класса:");
            Console.WriteLine("Введите имя: ");
            textinput = Console.ReadLine();
            PR.StringCheck(textinput);
            Console.WriteLine("Введите количество баллов: ");


            // проверка ввода числа
            score = PR.NumCheck(numinput, score);


            // тестирование дочернего класса
            Console.WriteLine("Создание объекта:");
            NumberForString stringNum = new NumberForString(textinput, score);
            Console.WriteLine(stringNum.ToString());

            Console.WriteLine("Тестирование метода на добавление восклицательных знаков:");
            stringNum.ExclamationMark();
            Console.WriteLine(stringNum.ToString());


            // увеличение числа в дочернем классе
            Console.WriteLine("Тестирование метода на увеличение числа: Насколько вы хотите увеличить число?");

            //ПРОВЕРКА ВВОДА ЧИСЛА
            increse = PR.NumCheck(numinput, increse);

            stringNum.IncreaseNumber(increse);
            Console.WriteLine(stringNum.ToString());


            // установка нового значения числа
            Console.WriteLine("Тестирование установки нового значения: Каким числом заменить?");
            //ПРОВЕРКА ВВОДА ЧИСЛА
            increse = PR.NumCheck(numinput, increse);
            stringNum.SetNumber(increse);
            Console.WriteLine(stringNum.ToString());

            // копирование объекта дочернего класса
            Console.WriteLine("Тестирование копирования объекта:");
            NumberForString derivedCopy = new NumberForString(stringNum);
            Console.WriteLine($"Оригинал объекта: {stringNum.ToString()}");
            Console.WriteLine($"Копия объекта: {derivedCopy.ToString()}");


        }

        // проверка ввода строки
        public string StringCheck(string x)
        {
            while (string.IsNullOrEmpty(x))
            {
                Console.WriteLine("Ошибка: строка пуста.");
                x = Console.ReadLine();
            }
            return x;
        }


        // проверка ввода числа
        public int NumCheck(string numinput, int score)
        {
            bool isNumber = false;
            while (!isNumber)
            {

                numinput = Console.ReadLine();

                if (!int.TryParse(numinput, out score))
                {
                    Console.WriteLine("Ошибка: введено не число.");
                }
                else
                {
                    isNumber = true;
                }
            }

            return score = Convert.ToInt32(numinput);
        }
        
    }
}
