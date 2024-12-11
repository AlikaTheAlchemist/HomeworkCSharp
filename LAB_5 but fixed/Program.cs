using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Cells;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("Хотите создать новый лог-файл или использовать существующий? (new - новый, old - существующий):");
                string userChoice = Console.ReadLine()?.ToLower();

                if (userChoice == "new")
                {
                    // Запрос на имя нового лог-файла
                    Console.WriteLine("Введите имя нового лог-файла (например, log.txt):");
                    logs = CastomLog + Console.ReadLine();
                    appendToFile = false; // Будем перезаписывать лог
                    break; // Выход из цикла, если введен правильный ответ
                }
                else if (userChoice == "old")
                {
                    // Запрос на имя старого лог-файла
                    Console.WriteLine("Введите имя существующего лог-файла (например, log.txt):");
                    logs = CastomLog + Console.ReadLine();
                    appendToFile = true; // Добавляем в существующий файл
                    break; // Выход из цикла, если введен правильный ответ
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите 'new' или 'old'.");
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
                //logger.Log($"Файл не найден: {CastomFilePath}");
                Console.WriteLine("Файл с таким именем не был найден");
                CastomFilePath = "C:\\Users\\alika\\source\\repos\\LAB_5_test\\LAB_5_test\\";
                Console.WriteLine("Введите имя файла формата xls, в котором содержится база данных, в формате 'имя_файла.xls':");
                CastomFilePath = CastomFilePath + Console.ReadLine();
            }


            // Создание листов отдельно
            List<Animals> Animals = Database.CreateAnimalsList(CastomFilePath);
            List<Customers> Customers = Database.CreateCustomersList(CastomFilePath);
            List<Sells> Sells = Database.CreateSellsList(CastomFilePath);


            try
            {
                // Логируем успешную загрузку файла
                logger.Log($"База данных успешно загружена из файла: {CastomFilePath}");
            }
            catch (Exception ex) { };


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
                        Console.WriteLine("\nСписок запросов: \n Нажмите '1' для вывода списка покупателей по возрасту и городу.\n Нажмите '2' для вывода суммы, на которую купили кошек породы Сфинкс в январе 2023 года. \n Нажмите '3' для вывода списка покупателей, купивших введённое животное в введённом городе. \n Нажмите '4' для вывода количество продаж золотых рыбок покупателям старше 50 лет.");
                    }

                    // Вывод базы данных
                    if (key == ConsoleKey.D)
                    {
                        Console.WriteLine("\nВывод базы данных.");

                        Console.WriteLine($"\n{Database.AnimalsHeader()}");
                        Database.PrintList(Animals);
                        Console.WriteLine($"\n{Database.CustomerHeader()}");
                        Database.PrintList(Customers);                   
                        Console.WriteLine($"\n{Database.SellsHeader()}");
                        Database.PrintList(Sells);

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
                        Console.WriteLine("\nВведите номер листа (1-3):");
                        int num = PR.intCheck(3);
                        if (num == 1) {
                            Console.WriteLine(Database.AnimalsHeader());
                            Database.PrintList(Animals); }
                        else if (num == 2) {
                            Console.WriteLine(Database.CustomerHeader());
                            Database.PrintList(Customers); }
                        else if (num == 3) {
                            Console.WriteLine(Database.SellsHeader());
                            Database.PrintList(Sells); }
                        else { Console.WriteLine("Неверный ввод!"); }

                        try
                        {
                            logger.Log($"Вывод листа под номером {num}.");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }

                    // Удаление элемента по ключу
                    if (key == ConsoleKey.E)
                    {
                        Console.WriteLine("\nУдаление элемента по ключу.");
                        Console.WriteLine("\nВведите номер листа:");
                        int num = PR.intCheck(3);
                        Console.WriteLine("\nВведите ID объекта:");
                        uint id = PR.uintCheck();

                        if (num == 1) { Database.DeleteObjectByID(Animals, id); }
                        else if (num == 2) { Database.DeleteObjectByID(Customers, id); }
                        else if (num == 3) { Database.DeleteObjectByID(Sells, id); }
                        else { Console.WriteLine("Неверный ввод!"); }
                       
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
                        int num = PR.intCheck(3);
                        Console.WriteLine("\nВведите ID объекта:");
                        uint id = PR.uintCheck();

                        if (num == 1) { Database.UpdateByID(Animals, id); }
                        else if (num == 2) { Database.UpdateByID(Customers, id); }
                        else if (num == 3) { Database.UpdateByID(Sells, id); }
                        else { Console.WriteLine("Неверный ввод!"); }

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
                        int num = PR.intCheck(3);

                        if (num == 1) { Database.AddItem(Animals); }
                        else if (num == 2) { Database.AddItem(Customers); }
                        else if (num == 3) { Database.AddItem(Sells); }
                        else { Console.WriteLine("Неверный ввод!"); }

                        try
                        {
                            logger.Log($"Добавление элемента в лист {num}.");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }


                    //// ЗАПРОСЫ


                    // Запрос про кошек сфинксов (2 таблицы)
                    if (key == ConsoleKey.D2)
                    {
                        Console.WriteLine($"\nВ январе 2023 года кошек породы Сфинкс купили на сумму {requests.Sphynx(Animals, Sells)} р.");

                        try
                        {
                            logger.Log("Запрос на сумму, на которую купили кошек породы Сфинкс в январе 2023 года.");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }


                    // Покупатели по возрасту и городу (1 таблица)
                    if (key == ConsoleKey.D1)
                    {

                        Console.WriteLine("\nВведите искомый город:");
                        string city = PR.stringCheck();
                        Console.WriteLine("\nВведите искомый возраст:");
                        uint age = PR.uintCheck();

                        List<Customers> AgeAndCity = requests.CustomersByAgeAndCity(Customers, age, city);

                        // Вывод результатов
                        Console.WriteLine($"Покупатели возраста {age} из города {city}:");
                        Console.WriteLine(Database.CustomerHeader());
                        Database.PrintList(AgeAndCity);

                        try
                        {
                            logger.Log("Запрос для вывода списка покупателей по возрасту.");
                        }
                        catch (Exception ex) { };

                        PR.Command();

                    }



                    // Вывести покупателей, купивших введённое животное в введённом городе  (3 таблицы)
                    if (key == ConsoleKey.D3)
                    {
                        Console.WriteLine("\nВведите искомый город:");
                        string city = PR.stringCheck();
                        Console.WriteLine("\nВведите искомое животное(вид):");
                        string type = PR.stringCheck();


                        var buyers = requests.BuyersByCityAndAnimal(Sells, Animals, Customers, city, type);

                        // Вывод результата
                        if (buyers.Any())
                        {
                            Console.WriteLine($"Покупатели из города {city}, купившие животных типа {type}:");
                            foreach (var buyer in buyers)
                            {
                                Console.WriteLine($"{buyer.Buyer.Name} купил породу {buyer.Breed}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Нет покупателей из города {city}, купивших животных типа {type}.");
                        }

                        try
                        {
                            logger.Log("Запрос для вывода покупателей покупателей, купивших определённое животное в определённом городе .");
                        }
                        catch (Exception ex) { };

                        PR.Command();
                    }


                    // Запрос на количество купленных золотых рыбок покупателями старше 50 (3 таблицы)
                    if (key == ConsoleKey.D4)
                    {
                        Console.WriteLine($"\nПродано золотых рыбок людям старше 50: {requests.GoldfishPurchases(Sells, Animals, Customers)}");

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
            while ((!int.TryParse(Console.ReadLine(), out n)) || (n <= 0) || (n > count))
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

        public string stringCheck()
        {
            while (true)
            {
                string city = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(city))
                {
                    return city.Trim();
                }
                Console.WriteLine("Некорректный ввод. Название города не должно быть пустым.");
            }
        }

        public void Command()
        {
            // Комманды
            Console.WriteLine("\nНажмите 'Esc' для выхода. \nНажмите 'D' для вывода базы данных. \nНажмите 'L' для вывода листа базы данных по его номеру. \nНажмите 'E' для удаления элемента (по ID). \nНажмите 'С' для корректирования элемента (по ID).\nНажмите 'А' для добавления элемента. \nНажмите 'R' для вывода информации о возможных запросах.");

        }

    }
}