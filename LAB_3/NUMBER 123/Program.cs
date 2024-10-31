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
            int n, m;


            // ввод массива с клавиатуры начиная с последнего столбца
            Console.WriteLine("Проверка создания матрицы с вводимыми числами:");
            Console.WriteLine("Введите число строк и столбцов матрицы:");
            n = PR.ReadNumInt();
            m = PR.ReadNumInt();
            Console.WriteLine("Введите элементы:");
            Mass mas1 = new Mass(n, m);
            Console.WriteLine("Полученная матрица:");
            Console.WriteLine(mas1.ToString());


            //// минимальный повторяющийся элемент
            //Console.WriteLine("\nПроверка вывода минимального элемента из повторяющихся:");
            //if (mas1.Reapit(n, m, mas1) != null) Console.WriteLine($"Минимальный повторяющийся элемент матрицы с введёнными элементами: {mas1.Reapit(n, m, mas1)}");
            //else Console.WriteLine("Не удалось найти ни единого повторяющегося значения");


            //// главная диагональ и ниже [-100, 100]  всё что выше[-4.5, 4.675]
            //Console.WriteLine("\nПроверка создания квадратной матрицы со случайными значениями:");
            //Console.WriteLine("Введите число строк и столбцов квадратной матрицы:");
            //n = PR.ReadNumInt();
            //Mass mas2 = new Mass(n);
            //Console.WriteLine("Полученная матрица:");
            //Console.WriteLine(mas2);


            //// заполнение типа зигзагом
            //Console.WriteLine("\nПроверка создания квадратной матрицы с фиксированными значениями:");
            //Console.WriteLine("Введите число строк и столбцов квадратной матрицы:");
            //n = PR.ReadNumInt();
            //double[,] array = new double[n, n];

            //int k = 1, i, j;
            //for (int h = 0; h < n; h++)
            //{
            //    if (h % 2 == 0) { i = h; j = 0; }
            //    else { j = h; i = 0; }
            //    while ((i + j == h) && (i >= 0) && (j >= 0))
            //    {
            //        array[i, j] = k;
            //        k++;
            //        if (h % 2 == 0) { i--; j++; }
            //        else { i++; j--; }
            //    }

            //    if ((i > 0) && (j >= 0)) array[i, j] = 0;
            //}
            //Mass mas3 = new Mass(n, n, array);
            //Console.WriteLine("Полученная матрица:");
            //Console.WriteLine(mas3);

            Console.WriteLine("Введите число строк и столбцов матрицы А:");
            n = PR.ReadNumInt();
            m = PR.ReadNumInt();
            Console.WriteLine("Введите элементы:");
            Mass masA = new Mass(n, m);
            Console.WriteLine("Полученная матрица:");
            Console.WriteLine(mas1.ToString());

            Console.WriteLine("Введите число строк и столбцов матрицы В:");
            n = PR.ReadNumInt();
            m = PR.ReadNumInt();
            Console.WriteLine("Введите элементы:");
            Mass masB = new Mass(n, m);

            Console.WriteLine("Введите число строк и столбцов матрицы С:");
            n = PR.ReadNumInt();
            m = PR.ReadNumInt();
            Console.WriteLine("Введите элементы:");
            Mass masC = new Mass(n, m);

            Console.WriteLine("Матрица А:");
            Console.WriteLine(masA.ToString());
            Console.WriteLine("Матрица В:");
            Console.WriteLine(masB.ToString());
            Console.WriteLine("Матрица С:");
            Console.WriteLine(masC.ToString());
            Console.WriteLine("Результат матричного выражения А+2*В-З*С^T :");
            try
            {
                Console.WriteLine(masA + 2 * masB - 3 * masC.Tr());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка! Складывать и вычитать можно только матрицы одинакового размера");
            }

        }

        public int ReadNumInt()
        {
            while (true)
            {
                string value = Console.ReadLine();
                if (int.TryParse(value, out int num))
                {
                    return num;
                }
                Console.WriteLine("Ошибка: Введите целое положительное число.");
            }

        }

    }
}