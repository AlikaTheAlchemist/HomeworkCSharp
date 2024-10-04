// monstrosity of a homework 

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
            Programm PR = new Programm();           // нельзя коментить вот этот блок
            Random rnd = new Random();
            int x, z, y;
            char a;
            string word;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Лабораторная работа №1");


            // удобнее будет коментить/раскоментить все эти ужасные задания ниже особенно №3


            Console.WriteLine("Задание №1: Необходимо реализовать метод таким образом, чтобы он возвращал результат сложения двух последних знаков числа х, предполагая, что знаков в числе неменее двух.");
            Console.WriteLine("Введите число:"); x = Convert.ToInt32(Console.ReadLine());
            while (x < 10 && x > -10)
            {
                Console.WriteLine("Знаков в числе меньше двух, введите другое число:");
                x = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(value: $"Ответ: {PR.sumLastNums(x)}");



            Console.WriteLine("Задание №2: Необходимо реализовать метод таким образом, чтобы он принимал число x и возвращал true, если оно положительное. ");
            Console.WriteLine("Введите число:"); x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {PR.isPositive(x)}");



            Console.WriteLine("Задание №4: Необходимо реализовать метод таким образом, чтобы он возвращал true, если любое из принятых чисел делит другое нацело.");
            Console.WriteLine("Введите числа:");
            x = Convert.ToInt32(Console.ReadLine()); z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {PR.isDivisor(x, z)}");



            Console.WriteLine("Задание №5: Необходимо реализовать метод таким образом, чтобы он считал сумму цифр двух чисел из разряда единиц.Выполните с его помощью последовательноесложение пяти чисел и результат выведите на экран.Постарайтесь выполнитьзадачу, используя минимально возможное количество вспомогательныхпеременных.");
            Console.WriteLine("Введите числа:");
            x = Convert.ToInt32(Console.ReadLine()); z = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 3; i++)
            {
                x = PR.lastNumSum(x, z);
                Console.WriteLine($"Сумма равна: {x}");
                Console.WriteLine("Введите ещё число для сложения:");
                z = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"Ответ: {PR.lastNumSum(x, z)}");



            Console.WriteLine("Задание №6: Необходимо реализовать метод таким образом, чтобы он возвращал деление x на y, и при этом гарантировал, что не будет выкинута ошибка деления на 0. При делении на 0 следует вернуть из метода число 0.");
            Console.WriteLine("Введите числа:");
            x = Convert.ToInt32(Console.ReadLine()); z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {PR.safeDiv(x, z)}");



            Console.WriteLine("Задание №7: Необходимо реализовать метод таким образом, чтобы он возвращал строку, которая включает два принятых методом числа и корректно выставленный знак операции сравнения (больше, меньше, или равно). ");
            Console.WriteLine("Введите числа:");
            x = Convert.ToInt32(Console.ReadLine()); z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {PR.makeDecision(x, z)}");



            Console.WriteLine("Задание №8: Необходимо реализовать метод таким образом, чтобы он возвращал true, если два любых числа (из трех принятых) можно сложить так, чтобы получить третье. ");
            Console.WriteLine("Введите числа:");
            x = Convert.ToInt32(Console.ReadLine()); z = Convert.ToInt32(Console.ReadLine()); y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {PR.sum3(x, z, y)}");



            Console.WriteLine("Задание №9: Необходимо реализовать метод таким образом, чтобы он возвращал строку, в которой сначала будет число х, а затем одно из слов: год, года, лет");
            Console.WriteLine("Введите число:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {PR.age(x)}");



            Console.WriteLine("Задание №10: В качестве параметра метод принимает строку, в которой записано название дня недели. Необходимо реализовать метод таким образом, чтобы он выводилна экран название переданного в него дня и всех последующих до конца недели дней.Если в качестве строки передан не день, то выводится текст “это не день недели”.");
            Console.WriteLine("Введите день недели с большой буквы:");
            word = Console.ReadLine();
            PR.printDays(word);



            Console.WriteLine("Задание №11: Необходимо реализовать метод таким образом, чтобы он возвращал строку, в которой будут записаны все числа от x до 0(включительно)");
            Console.WriteLine("Введите число:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {PR.reverseListNums(x)}");



            Console.WriteLine("Задание №12: Необходимо реализовать метод таким образом, чтобы он возвращал результат возведения x в степень y.");
            Console.WriteLine("Введите числа:");
            x = Convert.ToInt32(Console.ReadLine()); z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {PR.pow(x, z)}");



            Console.WriteLine("Задание №13: Необходимо реализовать метод таким образом, чтобы он возвращал true, если все знаки числа одинаковы, и false в ином случае.  ");
            Console.WriteLine("Введите число:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {PR.equalNum(x)}");



            Console.WriteLine("Задание №14: Необходимо реализовать метод таким образом, чтобы он выводил на экран треугольник из символов ‘*’ у которого х символов в высоту, а количество символов в ряду совпадает с номером строки.  ");
            Console.WriteLine("Введите число:");
            x = Convert.ToInt32(Console.ReadLine());
            PR.leftTriangle(x);



            Console.WriteLine("Задание №15: Необходимо реализовать метод таким образом, чтобы он генерировал случайное число от 0 до 9, далее считывал с консоли введенное пользователем число и выводил, угадал ли пользователь то, что было загадано, или нет. Метод запускается до тех пор, пока пользователь не угадает число. После этого выведите на экран количество попыток, которое потребовалось пользователю, чтобы угадать число.  ");
            PR.guessGame();



            Console.WriteLine("Задание №16: Необходимо реализовать метод таким образом, чтобы он возвращал индекс последнего вхождения числа x в массив arr. Если число не входит в массив – возвращается -1 ");
            Console.WriteLine("Введите число элементов в массиве:");
            z = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[z];
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(11);
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine($"a = {array[i]}");
            Console.WriteLine("Введите число для поиска последнего вхождения:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {PR.findLast(array, x)}");
            array = null;



            Console.WriteLine("Задание №17: Необходимо реализовать метод таким образом, чтобы он возвращал новый массив, который будет содержать все элементы массива arr, однако в позицию pos будет вставлено значение x  ");
            Console.WriteLine("Введите число элементов в массиве:");
            z = Convert.ToInt32(Console.ReadLine());
            array = new int[z];
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(11);
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine($"a = {array[i]}");
            Console.WriteLine("Введите число x и его позицию y:");
            x = Convert.ToInt32(Console.ReadLine()); y = Convert.ToInt32(Console.ReadLine());
            while (y >= z || y < 0)
            {
                Console.WriteLine("Номер позиции должен находится в рамках массива, введите y:");
                y = Convert.ToInt32(Console.ReadLine());
            }
            int[] array2 = PR.add(array, x, y);
            for (int i = 0; i < array2.Length; i++)
                Console.WriteLine($"a = {array2[i]}");
            array = null; array2 = null;



            Console.WriteLine("Задание №18: Необходимо реализовать метод таким образом, чтобы он изменял массив arr. После проведенных изменений массив должен быть записан задом-наперед.  ");
            Console.WriteLine("Введите число элементов в массиве:");
            z = Convert.ToInt32(Console.ReadLine());
            array = new int[z];
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(11);
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine($"a = {array[i]}");
            PR.reverse(array);
            Console.WriteLine("Массив после преобразований:");
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine($"a = {array[i]}");
            array = null;



            Console.WriteLine("Задание №19: Необходимо реализовать метод таким образом, чтобы он возвращал новый массив, в котором сначала идут элементы первого массива (arr1), а затем второго (arr2).   ");
            Console.WriteLine("Введите число элементов в массивах:");
            z = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            array = new int[z];
            array2 = new int[y];

            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(11);
            for (int i = 0; i < array2.Length; i++)
                array2[i] = rnd.Next(11);
            Console.WriteLine("Массив 1:");
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine($"a = {array[i]}");
            Console.WriteLine("Массив 2:");
            for (int i = 0; i < array2.Length; i++)
                Console.WriteLine($"a2 = {array2[i]}");

            int[] array3 = PR.concat(array, array2);
            Console.WriteLine("Полученный массив:");
            for (int i = 0; i < array.Length + array2.Length; i++)
                Console.WriteLine($"a3 = {array3[i]}");
            array = null; array2 = null; array3 = null;




            Console.WriteLine("Задание №20: Необходимо реализовать метод таким образом, чтобы он возвращал новый массив, в котором записаны все элементы массива arr кроме отрицательных.   ");
            Console.WriteLine("Введите число элементов в массиве:");
            z = Convert.ToInt32(Console.ReadLine());
            array = new int[z];
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(-6, 11);
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine($"a = {array[i]}");
            array2 = PR.deleteNegative(array);
            Console.WriteLine("Полученный массив:");
            for (int i = 0; i < array2.Length; i++)
                Console.WriteLine($"a = {array2[i]}");
            array = null; array2 = null;



            Console.WriteLine("Задание №3: Необходимо реализовать метод таким образом, чтобы он принимал символ x и возвращал true, если это большая буква в диапазоне от ‘A’ до ‘Z’.");
            Console.WriteLine("Введите символ:"); x = Console.Read();
            a = Convert.ToChar(x);
            while (!Char.IsLetter(a))
            {
                Console.WriteLine("Символ не является буквой, попробуйте ещё раз: ");
                x = Console.Read();
                a = Convert.ToChar(x);
            }
            Console.WriteLine($"Ответ: {PR.isUpperCase(a)}");


        }

        public int sumLastNums(int x) // возвращает сумму двух последних знаков
        {
            int answer = x % 10; x = x / 10;
            if (answer + x % 10 > 0) return answer + x % 10;
            else return (answer + x % 10) * (-1);
        }
        public bool isPositive(int x) // положительное ли число
        {
            if (x > 0) return true;
            else return false;
        }
        public bool isUpperCase(char x) // заглавная ли буква
        {
            if (x >= 'A' && x <= 'Z') return true;
            else return false;
        }
        public bool isDivisor(int a, int b) // делится ли без остатка одно на другое или другое на одно
        {
            if (a % b == 0 || b % a == 0) return true;
            else return false;
        }
        public int lastNumSum(int a, int b)    // вернуть сумму разряда единиц
        {
            return a % 10 + b % 10;
        }
        public double safeDiv(int x, int y) // деление x на y
        {
            if (y == 0) return 0; // если вдруг деление на 0 то вернуть 0
            else return x / y;
        }
        public String makeDecision(int x, int y) // больше меньше или равно в строке
        {
            if (x > y) return $"{x} > {y}";
            else if (x < y) return $"{x} < {y}";
            else return $"{x} = {y}";
        }
        public bool sum3(int x, int y, int z) // можно ли из двух чисел получить третье
        {
            if ((x + y == z) || (x + z == y) || (y + z == x)) return true;
            else return false;
        }
        public String age(int x) // год года или лет
        {
            if (x % 10 == 1 && x != 11) return $"{x} год";
            else if ((x % 10 == 2 || x % 10 == 3 || x % 10 == 4) && (x != 12 && x != 13 && x != 14)) return $"{x} года";
            else return $"{x} лет";
        }
        public void printDays(String x) // дни недели
        {
            Console.WriteLine("Результат:");
            switch (x)
            {
                case "Понедельник": Console.WriteLine("Понедельник"); goto case "Вторник";
                case "Вторник": Console.WriteLine("Вторник"); goto case "Среда";
                case "Среда": Console.WriteLine("Среда"); goto case "Четверг";
                case "Четверг": Console.WriteLine("Четверг"); goto case "Пятница";
                case "Пятница": Console.WriteLine("Пятница"); goto case "Суббота";
                case "Суббота": Console.WriteLine("Суббота"); goto case "Воскресенье";
                case "Воскресенье": Console.WriteLine("Воскресенье"); break;
                default: Console.WriteLine("Это не день недели"); break;
            }
        }
        public String reverseListNums(int x) // строка с числами от x до 0
        {
            string answer = $"{x}, ";
            if (x > 0)
            {
                while (x > 0)
                {
                    x--;
                    answer = answer + $"{x}";
                    if (x != 0) answer = answer + ", ";
                }
            }
            else
            {
                while (x < 0)
                {
                    x++;
                    answer = answer + $"{x}";
                    if (x != 0) answer = answer + ", ";
                }
            }
            return answer;
        }
        public int pow(int x, int y) // x в степени y
        {
            int p = 1;
            while (y >= 1)
            {
                p = p * x;
                y--;
            }
            return p;
        }
        public bool equalNum(int x) // одинаковые цифры
        {
            int a = x % 10;
            while (x > 0)
            {
                if (x % 10 != a) return false;
                a = x % 10;
                x = x / 10;
            }
            return true;
        }
        public void leftTriangle(int x) // треугольник из звёздочек
        {
            string p = "";
            for (int i = 1; i <= x; i++)
            {
                for (int j = i; j > 0; j--) p = p + "*";
                Console.WriteLine(p);
                p = "";

            }
        }
        public void guessGame() // угадай число
        {
            Random rnd = new Random();
            int x = rnd.Next(10), a, count = 1;
            Console.WriteLine("Угадайте число от 0 до 9:");
            a = Convert.ToInt32(Console.ReadLine());
            while (a != x)
            {
                count++;
                Console.WriteLine("Вы не угадали, попробуйте ещё раз:");
                a = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"Вы угадали! Вам потребовалось {count} попыток");
        }
        public int findLast(int[] arr, int x) // поиск последнего вхождения числа в массив
        {
            int find = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x) find = i;
            }
            return find;
        }
        public int[] add(int[] arr, int x, int pos)
        {
            arr[pos] = x;
            return arr;
        } // вставляем число в массив
        public void reverse(int[] arr) // переворачиваем массив
        {
            int p;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                p = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = p;
            }
        }
        public int[] concat(int[] arr1, int[] arr2) // склеиваем два массива в один
        {
            int x = arr1.Length + arr2.Length;
            int[] array = new int[x];
            for (int i = 0; i < arr1.Length; i++)
            {
                array[i] = (int)arr1[i];
            }
            for (int i = arr1.Length; i < arr1.Length + arr2.Length; i++)
            {
                array[i] = (int)arr2[i - arr1.Length];
            }
            return array;
        }
        public int[] deleteNegative(int[] arr) // создаём массив который записывает только неотрицательные числа
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++) if (arr[i] >= 0) count++;
            int[] array = new int[count];
            int j = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    array[j] = arr[i];
                    j++;
                }
                else
                {
                    while (arr[i] < 0) i++;
                    array[j] = arr[i];
                    j++;
                }

                if (j == array.Length) break;

            }

            return array;
        }

    }
}
