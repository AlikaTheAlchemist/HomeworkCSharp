using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Cells;

namespace LAB_5_test
{
    class Program
    {
        static void Main()
        {
            Program PR = new Program();


            // ЛОГИРОВАНИЕ

            string LogPath = "C:\\Users\\alika\\source\\repos\\LAB_5_test\\LAB_5_test\\logs.txt";
            string CastomLog = "C:\\Users\\alika\\source\\repos\\LAB_5_test\\LAB_5_test\\";
            string logs;
            bool appendToFile = true;

            // Цикл для проверки корректности ввода
            while (true)
            {
                // Запрос на создание нового файла или использование существующего
                Console.WriteLine("Хотите создать новый лог-файл или использовать существующий? (new - новый, append - существующий):");
                string userChoice = Console.ReadLine()?.ToLower();

                if (userChoice == "new")
                {
                    // Запрос на имя нового лог-файла
                    Console.WriteLine("Введите имя нового лог-файла (например, log.txt):");
                    logs = CastomLog + Console.ReadLine();
                    appendToFile = false; // Будем перезаписывать лог
                    break; // Выход из цикла, если введен правильный ответ
                }
                else if (userChoice == "append")
                {
                    // Запрос на использование существующего файла
                    Console.WriteLine($"Путь лог-файла: {LogPath}");
                    logs = LogPath;
                    appendToFile = true; // Добавляем в существующий файл
                    break; // Выход из цикла, если введен правильный ответ
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите 'new' или 'append'.");
                }
            }

            // Создаем объект Logger
            Logger logger = new Logger(logs, appendToFile);

            try
            {
                // Логируем начало работы программы
                logger.Log("Программа запущена.");
            }
            catch (Exception ex) { };



            // ОСНОВНАЯ ЧАСТЬ

            string FilePath = "C:\\Users\\alika\\source\\repos\\LAB_5_test\\LAB_5_test\\LR5-var2.xls";
            string CastomFilePath = "C:\\Users\\alika\\source\\repos\\LAB_5_test\\LAB_5_test\\";

            // Ввод имени файла и проверка на его существование
            Console.WriteLine("Введите имя файла формата xls, в котором содержится база данных, в формате 'имя_файла.xls':");
            CastomFilePath = CastomFilePath + Console.ReadLine() ;
            while (!File.Exists(CastomFilePath))
            {
                logger.Log($"Файл не найден: {CastomFilePath}");
                Console.WriteLine("Файл с таким именем не был найден");
                CastomFilePath = "C:\\Users\\alika\\source\\repos\\LAB_5_test\\LAB_5_test\\";
                Console.WriteLine("Введите имя файла формата xls, в котором содержится база данных, в формате 'имя_файла.xls':");
                CastomFilePath = CastomFilePath + Console.ReadLine();
            }

            try
            {
                // Логируем успешную загрузку файла
                logger.Log($"База данных успешно загружена из файла: {CastomFilePath}");
            }
            catch (Exception ex) { };

            // Создание объекта Exel
            Exel database = new Exel(CastomFilePath);


            Console.WriteLine("\nПрограмма работает.");
            PR.Command();

            while (true)
            {
                // Проверяем, была ли нажата клавиша
                if (Console.KeyAvailable)
                {
                    // Читаем нажатую клавишу
                    var key = Console.ReadKey(intercept: true).Key;

                    // Выход из цикла
                    if (key == ConsoleKey.Escape)
                    {
                        try
                        {
                            logger.Log("Программа завершена.");
                        }
                        catch (Exception ex) { };

                        Console.WriteLine("\nПрограмма завершена.");
                        break;
                    }

                    
                    if (key == ConsoleKey.R)
                    {
                        Console.WriteLine("\nСписок запросов: \n Нажмите '1' для вывода списка покупателей из Магниторогска, младше 30 лет.\n Нажмите '2' для вывода суммы, на которую купили кошек породы Сфинкс в январе 2023 года. \n Нажмите '3' для вывода списка покупателей из Уфы, купивших кролика или шиншиллу. \n Нажмите '4' для вывода количество продаж золотых рыбок покупателям старше 50 лет.");
                    }

                    // Вывод базы данных
                    if (key == ConsoleKey.D)
                    {
                        Console.WriteLine("\nВывод базы данных.");
                        Console.WriteLine(database.ToString());

                        try
                        {
                            logger.Log("Вывод базы данных полностью.");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }

                    // Вывод листа по номеру
                    if (key == ConsoleKey.L)
                    {
                        Console.WriteLine("\nВывод листа по номеру.");
                        Console.WriteLine("\nВведите номер листа:");
                        int num = PR.intCheck(database.Sheets.Count);
                        Console.WriteLine(database.ShowSheet(database.GetSheet(num)));

                        try
                        {
                            logger.Log($"Вывод листа по номеру {num}.");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }

                    // Удаление элемента по ключу
                    if (key == ConsoleKey.E)
                    {
                        Console.WriteLine("\nУдаление элемента по ключу.");
                        Console.WriteLine("\nВведите номер листа:");
                        int num = PR.intCheck(database.Sheets.Count);
                        Console.WriteLine("\nВведите ID объекта:");
                        uint id = PR.uintCheck();  
                        database.RemoveObject(num, (int)id);

                        try
                        {
                            logger.Log($"Удаление элемента {id} из листа {num}.");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }

                    // Корректировка элемента по ключу
                    if (key == ConsoleKey.C)
                    {
                        Console.WriteLine("\nКорректировка элемента по ключу.");
                        Console.WriteLine("\nВведите номер листа:");
                        int num = PR.intCheck(database.Sheets.Count);
                        Console.WriteLine("\nВведите ID объекта:");
                        uint id = PR.uintCheck();      
                        database.CorrectObject(num, (int)id);

                        try
                        {
                            logger.Log($"Корректировка элемента {id} из листа {num}.");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }

                    // Добавление элемента
                    if (key == ConsoleKey.A)
                    {
                        Console.WriteLine("\nДобавление элемента.");
                        Console.WriteLine("\nВведите номер листа:");
                        int num = PR.intCheck(database.Sheets.Count);
                        database.AddObject(num);

                        try
                        {
                            logger.Log($"Добавление элемента в лист {num}.");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }


                    // ЗАПРОСЫ

                    // Покупатели из Магниторогска младше 30 лет (1 таблица)
                    if (key == ConsoleKey.D1)
                    {

                        var Customers = Exel.Magnet(database);
                        Console.WriteLine("\nПокупатели из Магнитогорска младше 30 лет:");
                        foreach (var name in Customers)
                        {
                            Console.WriteLine(name);
                        }

                        try
                        {
                            logger.Log("Запрос  для вывода покупателей из Магниторогска, младше 30 лет.");
                        }
                        catch (Exception ex) { };

                        PR.Command();


                    }

                    // Запрос про кошек сфинксов (2 таблицы)
                    if (key == ConsoleKey.D2)
                    {
                        Console.WriteLine($"\nВ январе 2023 года кошек породы Сфинкс купили на сумму {Exel.Cats(database)} р.");
                        try
                        {
                            logger.Log("Запрос на сумму, на которую купили кошек породы Сфинкс в январе 2023 года.");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }

                    // Кролики и шиншиллы из уфы (3 таблицы)
                    if (key == ConsoleKey.D3)
                    {
                        var buyersFromUfa = Exel.BuyersFromUfa(database);
                        Console.WriteLine("\nПокупатели из Уфы, купившие кролика или шиншиллу:");
                        foreach (var buyer in buyersFromUfa)
                        {
                            Console.WriteLine(buyer);
                        }

                        try
                        {
                            logger.Log("Запрос  для вывода покупателей из Уфы, купивших кролика или шиншиллу.");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }

                    // Запрос на количество купленных золотых рыбок покупателями старше 50 (3 таблицы)
                    if (key == ConsoleKey.D4)
                    {
                        Console.WriteLine($"\nПродано золотых рыбок людям старше 50: {Exel.Goldfishes(database)}");

                        try
                        {
                            logger.Log("Запрос на гколичество проданных золотых рыбок покупателям старше 50");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }
                }



            }

        }

        public int intCheck (int count)
        {
            int n;
            while ((!int.TryParse(Console.ReadLine(), out n)) || (n < 0) || (n >= count))
            {
                Console.WriteLine("Неверный ввод");
            }

            return n;
        }
        public uint uintCheck()
        {
            uint n;
            while ((!uint.TryParse(Console.ReadLine(), out n)))
            {
                Console.WriteLine("Неверный ввод");
            }

            return n;
        }

        public void Command()
        {
            // Комманды
            Console.WriteLine("\nНажмите 'Esc' для выхода. \nНажмите 'D' для вывода базы данных. \nНажмите 'L' для вывода листа базы данных по его номеру. \nНажмите 'E' для удаления элемента (по ID). \nНажмите 'С' для корректирования элемента (по ID).\nНажмите 'А' для добавления элемента. \nНажмите 'R' для вывода информации о возможных запросах.");

        }

    }
}