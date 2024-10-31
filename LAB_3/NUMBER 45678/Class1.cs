using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
public struct BaggageItem
{
    public string Name { get; set; } // название единицы багажа
    public int Weight { get; set; }  // масса
}

[Serializable]
public class Passenger
{
    public List<BaggageItem> Baggages { get; set; } // содержит список багажа

    public Passenger()
    {
        Baggages = new List<BaggageItem>();     //  инициализирует список багажа
    }
}

public static class FileHelp

{
    // ЗАДАНИЕ 4

    // Создание и заполнение бинарного файла случайным количеством случайных чисел
    public static void RandomBin(string filePath)
    {
        try
        {
            // Очищаем файл, если он существует
            if (File.Exists(filePath))
            {
                File.Delete(filePath); // Удаляем файл, чтобы создать новый
            }

            var random = new Random();
            int count = random.Next(5, 20); // Случайное количество чисел

            using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(-10, 10); // Генерация случайного числа в диапазоне
                    writer.Write(number);
                }
            }

            Console.WriteLine($"Файл '{filePath}' успешно создан и заполнен случайными числами.");
        }
        catch (Exception ex) { Console.WriteLine($"Ошибка при создании файла: {ex.Message}"); };
    }

    // Произведение нечетных отрицательных чисел в бинарном файле
    public static int ComposeBin(string filePath)
    {
        int com = 1;
        bool hasOddNegative = false;

        try
        {
            using (var reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();
                    if (number < 0 && number % 2 != 0) // Проверка на нечётность и отрицательность
                    {
                        com *= number;
                        hasOddNegative = true;
                    }
                }
                if (!hasOddNegative)
                    com = 0;

                Console.WriteLine("Произведение нечётных отрицательных чисел успешно вычислено.");
            }

        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return 0;
        }

        return com;
    }




    // ЗАДАНИЕ 5
    // Метод для создания и заполнения файла с багажом случайными данными
    public static void CreateBaggage(string filePath)
    {
        var random = new Random();
        var passengers = new List<Passenger>();
        int passengerCount = random.Next(2, 10); // Случайное количество пассажиров

        string bag1 = "Рюкзак", bag2 = "Коробка", bag3 = "Сумка";
        string[] select = new string[3] { bag1, bag2, bag3 };

        for (int i = 0; i < passengerCount; i++)
        {
            int itemCount = random.Next(1, 5); // Случайное количество единиц багажа на пассажира (от 1 до 5)
            var passenger = new Passenger();

            for (int j = 0; j < itemCount; j++)
            {
                var item = new BaggageItem
                {
                    Weight = random.Next(1, 30), // Генерация случайной массы
                    Name = select[random.Next(0, select.Length)],
                };
                passenger.Baggages.Add(item);
            }
            passengers.Add(passenger);
        }

        // Сериализация данных в XML и запись в файл
        try
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<Passenger>));
                serializer.Serialize(fs, passengers);
            }
            Console.WriteLine("Файл с багажом успешно создан и заполнен случайными данными.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании файла: {ex.Message}");
        }
    }

    // Метод для подсчета пассажиров с более чем двумя единицами багажа и превышающими среднее число единиц
    public static void AnalyzeBaggage(string filePath)
    {
        List<Passenger> passengers;

        // Чтение и десериализация данных из XML-файла
        try
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(List<Passenger>));
                passengers = (List<Passenger>)serializer.Deserialize(fs);
            }
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return;
        }

        // Подсчет числа пассажиров с более чем двумя единицами багажа
        int countMoreThanTwo = 0;
        foreach (var passenger in passengers)
        {
            if (passenger.Baggages.Count > 2)
            {
                countMoreThanTwo++;
            }
        }
        Console.WriteLine($"Количество пассажиров с более чем двумя единицами багажа: {countMoreThanTwo}");


        // Подсчет среднего числа единиц багажа
        double averageBaggageCount = passengers.Count > 0 ? (double)passengers.Sum(p => p.Baggages.Count) / passengers.Count : 0;
        Console.WriteLine($"Среднее число едениц багажа: {averageBaggageCount:f0}");


        // Подсчет числа пассажиров, количество единиц багажа которых превосходит среднее
        int countAboveAverage = 0;
        foreach (var passenger in passengers)
        {
            if (passenger.Baggages.Count > averageBaggageCount)
            {
                countAboveAverage++;
            }
        }
        Console.WriteLine($"Количество пассажиров, у которых количество единиц багажа превосходит среднее: {countAboveAverage}");
    }


    // Метод для просмотра содержимого файла
    public static void ShowBaggage(string filePath)
    {
        List<Passenger> passengers;

        // Чтение и десериализация данных из XML-файла
        try
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(List<Passenger>));
                passengers = (List<Passenger>)serializer.Deserialize(fs);
            }

            Console.WriteLine("Содержимое файла:");
            for (int i = 0; i < passengers.Count; i++)
            {
                Console.WriteLine($"Пассажир {i + 1}:");
                foreach (var baggage in passengers[i].Baggages)
                {
                    Console.WriteLine($" - {baggage.Name}: {baggage.Weight} кг");
                }
            }
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
        }
    }






    // ЗАДАНИЕ 6

    // Создание и заполнение текстового файла случайными числами
    public static void RandomText(string filePath)
    {
        try
        {
            // Удаляем файл если он существует
            if (File.Exists(filePath))
            {
                File.Delete(filePath); 
            }

            var random = new Random();
            int count = random.Next(5, 20); // Случайное количество чисел (от 5 до 20)

            using (StreamWriter writer = new StreamWriter(filePath))    // Закрывает файл автоматически в конце работы
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(1, 10); // Генерация случайного числа в диапазоне от 1 до 10
                    writer.WriteLine(number); // Запись числа в файл
                }
            }

            Console.WriteLine($"Файл '{filePath}' успешно создан и заполнен случайными числами.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании файла: {ex.Message}");
        }
    }

    // Вычисления суммы квадратов чисел в текстовом файле
    public static int SumOfSquares(string filePath)
    {
        int sumOfSquares = 0;

        try
        {
            using (StreamReader reader = new StreamReader(filePath))    // Закрывает файл автоматически в конце работы
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        Console.WriteLine($"Сумма = {sumOfSquares}; {number}^2 = {number * number}");
                        sumOfSquares += number * number; // Сумма квадратов
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return 0;
        }

        return sumOfSquares;
    }








    // ЗАДАНИЕ 7

    // Метод для создания и заполнения текстового файла случайными числами ПОСТРОЧНО
    public static void RandNumsString(string filePath)
    {
        try
        {
            // Удаляем файл если он существует
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            var random = new Random();
            int lineCount = random.Next(5, 10); // Случайное количество строк
            int numbersPerLine = random.Next(2, 5); // Случайное количество чисел в строке

            using (StreamWriter writer = new StreamWriter(filePath))    // Закрывает файл автоматически в конце работы
            {
                for (int i = 0; i < lineCount; i++)
                {
                    for (int j = 0; j < numbersPerLine; j++)
                    {
                        int number = random.Next(1, 10); // Генерация случайного числа от 1 до 10
                        writer.Write(number);

                        // Добавляем пробел между числами, кроме последнего числа в строке
                        if (j < numbersPerLine - 1)
                        {
                            writer.Write(" ");
                        }
                    }
                    writer.WriteLine(); // Переход на новую строку после записи нескольких чисел
                }
            }

            Console.WriteLine($"Файл '{filePath}' успешно создан и заполнен случайными числами.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании файла: {ex.Message}");
        }
    }

    // Метод для вычисления произведения чисел в текстовом файле
    public static long ComposeTxt(string filePath)
    {
        long com = 1; // Инициализируем произведение

        try
        {
            using (StreamReader reader = new StreamReader(filePath))    // Закрывает файл автоматически в конце работы
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Разделяем строку на числа по пробелам
                    string[] numbers = line.Split(' ');
                    foreach (var number in numbers)
                    {
                        if (long.TryParse(number, out long num))
                        {
                            Console.WriteLine($"Произведение: {com} * {num} = {com * num}");
                            com *= num; // Умножаем на текущее число
                        }
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return 0;
        }

        return com;
    }

    // Метод для вычисления произведения чисел ПОСТРОЧНО (на всякий случай)
    public static void ComposeTxtLine(string filePath)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filePath))    // Закрывает файл автоматически в конце работы
            {
                string line;
                int lineNumber = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    // Разделяем строку на числа по пробелам
                    string[] numbers = line.Split(' ');
                    int product = 1; // Инициализируем произведение для текущей строки
                    foreach (var number in numbers)
                    {
                        if (int.TryParse(number, out int num))
                        {
                            product *= num; // Умножаем на текущее число
                        }
                    }
                    Console.WriteLine($"Произведение чисел в строке {lineNumber}: {product}");
                    lineNumber++;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
        }
    }





    // ЗАДАНИЕ 8

    // Метод для копирования строк заданной длины m из одного файла в другой
    public static void CopyLines(string fromFilePath, string toFilePath, uint m)
    {
        try
        {
            using (StreamReader reader = new StreamReader(fromFilePath))    // Закрывает файл автоматически в конце работы
            using (StreamWriter writer = new StreamWriter(toFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Проверяем длину строки
                    if (line.Length == m)
                    {
                        writer.WriteLine(line); // Записываем строку в другой файл
                    }
                }
            }
            Console.WriteLine($"Строки длиной {m} символов успешно скопированы в '{toFilePath}'.");
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Исходный файл не найден.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при работе с файлами: {ex.Message}");
        }
    }





    // ВСПОМОГАТЕЛЬНОЕ

    // Вывод элементов из бинарного файла
    public static void ShowFileBin(string filePath)
    {
        try
        {
            using (var reader = new BinaryReader(File.Open(filePath, FileMode.Open)))       // Закрывает файл автоматически в конце работы
            {
                Console.WriteLine("Содержимое файла:");
                while (reader.BaseStream.Position != reader.BaseStream.Length) // От текущей позиции до конца файла
                {
                    int number = reader.ReadInt32();
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
        }
    }

    // Вывод текстового файла с числами
    public static void ShowFileTxt(string filePath)
    {
        try
        {
            Console.WriteLine("Содержимое файла:");
            using (StreamReader reader = new StreamReader(filePath))    // Закрывает файл автоматически в конце работы
            {
                string content = reader.ReadToEnd();    // Считывает сразу весь текст
                string formattedContent = content.Replace(Environment.NewLine, " "); // Заменяет перенос строки на пробел
                Console.WriteLine(formattedContent); // Вывод с удалением лишних строк в начале и вконце
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
        }
    }


    // Вывод строками (для красивого вывода в 8 задании)
    public static void ShowFileTxtLine(string filePath)
    {
        try
        {
            Console.WriteLine("Содержимое файла:");
            using (StreamReader reader = new StreamReader(filePath))    // Закрывает файл автоматически в конце работы
            {
                string line;
                while ((line = reader.ReadLine()) != null)  // Читает файл построчно
                {
                    Console.WriteLine(line);    // Выводит каждую строку
                }
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
        }
    }
}

