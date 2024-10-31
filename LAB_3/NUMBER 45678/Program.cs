using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_3_NUM_48
{
    class Programm
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string name = "";
            string name1 = "file1.bin";
            string name2 = "file2.bin";
            string name3 = "file3.txt";
            string name4 = "file4.txt";
            string name5 = "file5.txt";


            // Создание и заполнение файла случайными числами
            FileHelp.RandomBin(name1);
            // Содержимое файла
            FileHelp.ShowFileBin(name1);
            // Вичисление произведения
            Console.WriteLine($"Произведение нечетных отрицательных чисел: {FileHelp.ComposeBin(name1)}");


            // Создание и заполнение файла с багажом
            FileHelp.CreateBaggage(name2);
            // Просмотр содержимого файла
            FileHelp.ShowBaggage(name2);
            // Анализ данных о багаже
            FileHelp.AnalyzeBaggage(name2);


            // Создание и заполнение файла случайными числами
            FileHelp.RandomText(name3);
            //// Содержимое файла
            FileHelp.ShowFileTxt(name3);
            // Вычисление суммы квадратов элементов файла
            Console.WriteLine($"Сумма квадратов чисел в файле: {FileHelp.SumOfSquares(name3)}");


            // Создание и заполнение файла случайными числами
            FileHelp.RandNumsString(name4);
            // Содержимое файла
            FileHelp.ShowFileTxt(name4);
            // Вычисление произведения элементов файла
            Console.WriteLine($"Произведение чисел в файле: {FileHelp.ComposeTxt(name4)}");
            // Вычисление произведения элементов файла GJCNHJXYJ
            Console.WriteLine("\nПроизведение чисел в файле построчно");
            FileHelp.ComposeTxtLine(name4);


            Console.WriteLine("Введите название файла, в который будут копироватья строки:");
            name = name + Console.ReadLine() + ".txt";
            Console.WriteLine("Введите длину строк, которые будут копироваться:");
            uint m;
            while (!uint.TryParse(Console.ReadLine(), out m))
            {
                Console.WriteLine("Ошибка: Введите целое положительное число.");
            }
            FileHelp.CopyLines(name5, name, m);
            // Содержимое файла
            FileHelp.ShowFileTxtLine(name);
        }
    }
}
