using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6_2
{
    class Program
    {

        static void Main()
        {
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(2, 3);
            Fraction f3 = new Fraction(3, 4);
            Fraction f4 = new Fraction(1, 3);

            Console.WriteLine($"Дроби: {f1}, {f2}, {f3}\n");


            // Базовый функционал
            //Console.WriteLine($"{f1} + {f2} = {f1.Sum(f2)}");
            //Console.WriteLine($"{f1} - {f2} = {f1.Minus(f2)}");
            //Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
            //Console.WriteLine($"{f1} / {f2} = {f1.Div(f2)}\n");

            //Console.WriteLine($"{f1} + 5 = {f1 + 5}");
            //Console.WriteLine($"{f1} - 5 = {f1.Minus(5)}");
            //Console.WriteLine($"{f1} * 5 = {f1 * 5}");
            //Console.WriteLine($"{f1} / 5 = {f1 / 5}\n");

            //Console.WriteLine($"f1.Sum(f2).Div(f3).Minus(5) = {f1.Sum(f2).Div(f3).Minus(5)}");


            //// Сравнение дробей
            //Console.WriteLine($"{f1} == {f4}: {f1 == f4}");
            //Console.WriteLine($"{f1} != {f2}: {f1 != f2}");
            //Console.WriteLine($"{f1} == {f3}: {f1 == f3}");
            //Console.WriteLine($"{f1} != {f4}: {f1 != f4}");


            // Клонирование
            //Console.WriteLine($"Копия дроби {f1} - {(Fraction)f1.Clone()}");


            // Шаблоны
            Console.WriteLine($"Вещественное значение дроби {f1}: {f1.GetValue()}");
            Console.WriteLine($"Вещественное значение дроби {f3}: {f3.GetValue()}");

            Console.WriteLine($"\nИзменяем знаменатель дроби {f1} на 6 =>");
            // Изменяем знеменатель
            f1.SetDenominator(6);
            Console.WriteLine($"{f1}");

            Console.WriteLine($"Изменяем числитель дроби {f3} на 6 =>");
            // Изменяем числитель
            f3.SetNumerator(6);
            Console.WriteLine($"{f3}");

            // Получаем обновленное вещественное значение
            Console.WriteLine($"\nОбновлённое вещественное значение дроби {f1}: {f1.GetValue()}");
            Console.WriteLine($"Обновлённое вещественное значение дроби {f3}: {f3.GetValue()}");

        }
    }

    
}
