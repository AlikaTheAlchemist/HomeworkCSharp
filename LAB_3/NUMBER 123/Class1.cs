using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal class Mass
    {
        private double[,] array;

        public double[,] Mas
        { 
            get { return array; } 
            set { array = value; }
        }


        // конструктор по умолчанию
        public Mass() { array = new double[1,1]; }


        // конструктор с вводимыми числами С ПОСЛЕДНЕГО СТОЛБЦА
        public Mass(int n, int m)
        {
            array = new double[n, m];
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"Элемент [{j},{i}]:");
                    array[j, i] = ReadNumDouble();
                }
            }
        }


        // конструктор со случайными числами 
        // главная диагональ и ниже [-100, 100]  всё что выше[-4.5, 4.675]
        public Mass(int n)
        {
            array = new double[n, n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == j) || (j < i)) array[i, j] = rnd.Next(-100, 100);
                    else array[i, j] = rnd.NextDouble() * (45.675 - (-4.5)) + (-4.5);
                }
            }
        }


        // ЗАПОЛНЕНИЕ ЗИГЗАГОМ будет просто копированием
        // конструктор который копирует существующий массив в объект
        public Mass(int n, int m, double[,] mas)
        {
            array = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = mas[i, j];
                }
            }
        }


        // минимальный повторяющийся элемент
        public double? Reapit(int n, int m, Mass a)
        {
            double? minRep = null;      //чтобы можно было хранить null

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    double current = a.array[i, j];
                    bool reapit = false;


                    for (int k = 0; k < n; k++)
                    {
                        for (int l = 0; l < m; l++)
                        {
                            if (k == i && l == j) continue;
                            if (a.array[k, l] == current)
                            {
                                reapit = true;
                                break;
                            }
                        }
                        if ((minRep == null || current < minRep) && (reapit == true))
                        {
                            minRep = current;
                            break;
                        }
                    }

                }
            }
            return minRep;
        }


        // транспонированная матрица
        public Mass Tr ()
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            double[,] array1 = new double[m,n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array1[j, i] = array[i, j]; // Транспонирование
                }
            }

            Mass trans = new Mass(n,m,array1);
            return trans;
        }

        // перегруз сложения матриц
        public static Mass operator +(Mass e1, Mass e2)
        {
            if ((e1.array.GetLength(0) != e2.array.GetLength(0)) || (e1.array.GetLength(1) != e2.array.GetLength(1)))
            {
                return new Mass();
            }

            for (int i = 0; i < e1.array.GetLength(0); i++)
            {
                for (int j = 0; j < e1.array.GetLength(1); j++)
                {

                    e1.array[i, j] = e1.array[i, j] + e2.array[i, j];

                }
            }
            return e1;
        }

        // перегруз вычитания матриц
        public static Mass operator -(Mass e1, Mass e2)
        {
            if ((e1.array.GetLength(0) != e2.array.GetLength(0)) || (e1.array.GetLength(1) != e2.array.GetLength(1)))
            {
                return new Mass();
            }

            for (int i = 0; i < e1.array.GetLength(0); i++)
            {
                for (int j = 0; j < e1.array.GetLength(1); j++)
                {

                    e1.array[i, j] = e1.array[i, j] - e2.array[i, j];

                }
            }
            return e1;
        }

        // перегруз умножения матрицы на число
        public static Mass operator *(double x, Mass e1)
        {
            for (int i = 0; i < e1.array.GetLength(0); i++)
            {
                for (int j = 0; j < e1.array.GetLength(1); j++)
                {
                    double e = e1.array[i, j] * x;
                    e1.array[i, j] = e;
                }
            }
            return e1;
        }

        // перегруз тустринг
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < array.GetLength(0); i++)    // количество строк
            {
                for (int j = 0; j < array.GetLength(1); j++)  // количество столбцов
                {
                    result.Append($"{array[i,j]:f2} ");
                }
                result.AppendLine();
            }
            return $"{result}";
        }

        // проверка ввода
        private double ReadNumDouble()
        {
            while (true)
            {
                string value = Console.ReadLine();
                if (double.TryParse(value, out double num))
                {
                    return num;
                }
                Console.WriteLine("Ошибка: Введите число.");
            }
        }
    }
}
