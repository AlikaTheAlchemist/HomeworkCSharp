using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Aspose.Cells;

namespace LAB_5_test
{
    internal class Exel
    {
        public List<Worksheet> Sheets { get; set; }

        public Exel(string filePath)
        {
            // Загружаем Excel файл
            Workbook workbook = new Workbook(filePath);
            Sheets = new List<Worksheet>();

            // Добавляем все листы из файла в коллекцию
            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                Sheets.Add(workbook.Worksheets[i]);
            }
        }


        // Перегрузка ToString для вывода всех листов базы данных
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Содержимое базы данных:");

            foreach (var sheet in Sheets)
            {
                sb.AppendLine($"Лист: {sheet.Name}");
                sb.AppendLine(ShowSheet(sheet)); // Получаем строковое представление листа
            }

            return sb.ToString();
        }



        // Метод для вывода данных листа
        public string ShowSheet(Worksheet sheet)
        {
            StringBuilder sb = new StringBuilder();
            Cells cells = sheet.Cells;
            int maxRow = cells.MaxRow;
            int maxColumn = cells.MaxColumn;

            // Форматируем вывод данных
            for (int row = 0; row <= maxRow; row++)
            {
                for (int col = 0; col <= maxColumn; col++)
                {
                    string cellValue = cells[row, col].Value?.ToString() ?? "";
                    sb.Append(cellValue.PadRight(15)); // Отступ между колонками
                }
                sb.AppendLine(); // Переход на новую строку
            }

            return sb.ToString();
        }

        // Метод для получения конкретного листа по имени
        public Worksheet GetSheet(string sheetName)
        {
            return Sheets.FirstOrDefault(sheet => sheet.Name == sheetName);
        }

        // Метод для получения листа по индексу
        public Worksheet GetSheet(int index)
        {
            if (index >= 0 && index < Sheets.Count)
            {
                return Sheets[index];
            }
            else
            {
                Console.WriteLine("Лист с таким индексом не существует.");
                return null;
            }
        }



        // Добавление нового объекта в таблицу
        public void AddObject(int sheetIndex)
        {
            Worksheet sheet = Sheets[sheetIndex];
            Cells cells = sheet.Cells;

            // Определяем первую пустую строку
            int newRow = cells.MaxDataRow + 1;

            // Определяем следующий id
            int nextId = 0;
            // Проходим по всем строкам первого столбца и находим максимальный id
            for (int row = 1; row <= cells.MaxRow; row++) // Пропускаем заголовок
            {
                if (int.TryParse(cells[row, 0].Value?.ToString(), out int currentId))
                {
                    nextId = Math.Max(nextId, currentId);
                }
            }
            // Следующий id
            nextId++;
            Console.WriteLine($"ID: {nextId}");

            // Устанавливаем id в первом столбце
            cells[newRow, 0].PutValue(nextId);

            // Получаем заголовки таблицы
            Console.WriteLine("Введите данные для следующих столбцов:");
            for (int col = 1; col < cells.MaxColumn; col++)
            {
                string columnName = cells[0, col].Value?.ToString() ?? $"Колонка {col + 1}";
                Console.Write($"{columnName}: ");
                string value = Console.ReadLine();
                cells[newRow, col].PutValue(value); // Записываем данные в новую строку
            }

            // Сохранение файла
            sheet.Workbook.Save("updated_data.xlsx");
            Console.WriteLine($"Данные успешно добавлены в строку {newRow + 1}.");
        }

        // Удаление объекта по ID
        public void RemoveObject(int sheetIndex, int id)
        {
            Worksheet sheet = Sheets[sheetIndex];
            Cells cells = sheet.Cells;

            for (int row = 1; row <= cells.MaxRow; row++) // Пропускаем заголовок
            {
                if (int.TryParse(cells[row, 0].Value?.ToString(), out int currentId) && currentId == id)
                {
                    // Удаляем строку с найденным ID
                    sheet.Cells.DeleteRow(row);
                    sheet.Workbook.Save("updated_data.xlsx");
                    Console.WriteLine($"Элемент с ID {id} успешно удалён.");
                    return;
                }
            }

            Console.WriteLine("Элемент с таким ID не найден.");
        }

        // Корректировка объекта по ID
        public void CorrectObject(int sheetIndex, int id)
        {
            Worksheet sheet = Sheets[sheetIndex];
            Cells cells = sheet.Cells;

            for (int row = 1; row <= cells.MaxRow; row++) // Пропускаем заголовок
            {
                if (int.TryParse(cells[row, 0].Value?.ToString(), out int currentId) && currentId == id)
                {
                    Console.WriteLine("Найден элемент для корректировки:");

                    // Выводим текущие данные
                    for (int col = 0; col < cells.MaxColumn; col++)
                    {
                        Console.Write(cells[row, col].Value?.ToString().PadRight(15));
                    }

                    // Ввод новых данных
                    Console.WriteLine("\nВведите новые значения (оставьте пустым, чтобы сохранить текущее значение):");
                    for (int col = 1; col < cells.MaxColumn; col++) // Пропускаем первый столбец (ID)
                    {
                        string columnName = cells[0, col].Value?.ToString() ?? $"Колонка {col + 1}";
                        Console.Write($"{columnName}: ");
                        string newValue = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newValue))
                        {
                            cells[row, col].PutValue(newValue);
                        }
                    }

                    // Сохранение изменений
                    sheet.Workbook.Save("updated_data.xlsx");
                    Console.WriteLine("Элемент успешно отредактирован.");
                    return;
                }
            }

            Console.WriteLine("Элемент с таким ID не найден.");
        }









        // Запрос из примера кошки Сфинксы 2 таблицы
        public static int Cats(Exel database)
        {
            // Получение таблиц через объект ExcelFile
            Worksheet animalsSheet = database.GetSheet("Животные");
            Worksheet salesSheet = database.GetSheet("Продажи");

            if (animalsSheet == null || salesSheet == null)
            {
                Console.WriteLine("Таблицы 'Животные' или 'Продажи' не найдены!");
                return -1;
            }

            // Чтение данных
            Cells animalsCells = animalsSheet.Cells;
            Cells salesCells = salesSheet.Cells;

            // Результат
            int total = 0;

            // Проход по строкам таблицы продаж
            for (int salesRow = 1; salesRow <= salesCells.MaxDataRow; salesRow++) // Пропускаем заголовок
            {
                int animalId = Convert.ToInt32(salesCells[salesRow, 1].Value); // id_животного
                DateTime saleDate = Convert.ToDateTime(salesCells[salesRow, 3].Value); // Дата
                int price = Convert.ToInt32(salesCells[salesRow, 4].Value); // Цена

                // Проверяем, что дата соответствует январю 2023 года
                if (saleDate.Year == 2023 && saleDate.Month == 1)
                {
                    // Ищем животное по id
                    for (int animalRow = 1; animalRow <= animalsCells.MaxDataRow; animalRow++) // Пропускаем заголовок
                    {
                        int currentAnimalId = Convert.ToInt32(animalsCells[animalRow, 0].Value); // id_животного
                        string type = animalsCells[animalRow, 1].Value?.ToString(); // вид
                        string breed = animalsCells[animalRow, 2].Value?.ToString(); // порода

                        // Проверяем, что животное — кошка породы "Сфинкс"
                        if (currentAnimalId == animalId && type == "Кошка" && breed == "Сфинкс")
                        {
                            total += price;
                            break;
                        }
                    }
                }
            }

            return total;
        }

        // Покупатели из Магнитогорска младше 30 лет
        public static List<string> Magnet(Exel database)
        {
            // Получаем лист "Покупатели"
            var customersSheet = database.GetSheet("Покупатели");

            // Проверка на наличие листа
            if (customersSheet == null)
            {
                Console.WriteLine("Таблица 'Покупатели' не найдена!");
                return new List<string>();
            }

            // Чтение данных
            var customersCells = customersSheet.Cells;

            // Список для хранения имен подходящих покупателей
            var youngCustomers = new List<string>();

            // Проход по строкам таблицы "Покупатели"
            for (int customerRow = 1; customerRow <= customersCells.MaxDataRow; customerRow++) // Пропускаем заголовок
            {
                string name = customersCells[customerRow, 1].Value?.ToString(); // Имя покупателя
                int age = Convert.ToInt32(customersCells[customerRow, 2].Value); // Возраст покупателя
                string city = customersCells[customerRow, 3].Value?.ToString(); // Город

                // Проверяем условия: город — Магнитогорск и возраст < 30
                if (city == "Магнитогорск" && age < 30)
                {
                    youngCustomers.Add(name); // Добавляем имя в список
                }
            }

            return youngCustomers;
        }

        // кролики и шиншиллы из уфы (3 таблицы)
        public static List<string> BuyersFromUfa(Exel database)
        {
            // Получаем листы
            var animalsSheet = database.GetSheet("Животные");
            var salesSheet = database.GetSheet("Продажи");
            var customersSheet = database.GetSheet("Покупатели");

            // Проверяем наличие всех необходимых таблиц
            if (animalsSheet == null || salesSheet == null || customersSheet == null)
            {
                Console.WriteLine("Один из нужных листов не найден!");
                return new List<string>();
            }

            // Чтение данных
            var animalsCells = animalsSheet.Cells;
            var salesCells = salesSheet.Cells;
            var customersCells = customersSheet.Cells;

            // Список для хранения имен покупателей, соответствующих условиям
            var buyersFromUfa = new List<string>();

            // Проходим по строкам таблицы продаж
            for (int salesRow = 1; salesRow <= salesCells.MaxDataRow; salesRow++) // Пропускаем заголовок
            {
                int animalId = Convert.ToInt32(salesCells[salesRow, 1].Value); // ID животного
                int customerId = Convert.ToInt32(salesCells[salesRow, 2].Value); // ID покупателя

                // Ищем животное по ID
                for (int animalRow = 1; animalRow <= animalsCells.MaxDataRow; animalRow++) // Пропускаем заголовок
                {
                    int currentAnimalId = Convert.ToInt32(animalsCells[animalRow, 0].Value); // ID животного
                    string animalType = animalsCells[animalRow, 1].Value?.ToString(); // Тип животного

                    // Проверяем, что это кролик или шиншилла
                    if (currentAnimalId == animalId && (animalType == "Кролик" || animalType == "Шиншилла"))
                    {
                        // Ищем покупателя по ID
                        for (int customerRow = 1; customerRow <= customersCells.MaxDataRow; customerRow++) // Пропускаем заголовок
                        {
                            int currentCustomerId = Convert.ToInt32(customersCells[customerRow, 0].Value); // ID покупателя
                            string city = customersCells[customerRow, 3].Value?.ToString(); // Город покупателя

                            // Проверяем, что покупатель из Уфы
                            if (currentCustomerId == customerId && city == "Уфа")
                            {
                                string customerName = customersCells[customerRow, 1].Value?.ToString(); // Имя покупателя
                                if (!string.IsNullOrEmpty(customerName) && !buyersFromUfa.Contains(customerName))
                                {
                                    buyersFromUfa.Add(customerName);
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            return buyersFromUfa;
        }

        // Запрос на количество купленных золотых рыбок покупателями старше 50 (3 таблицы)
        public static int Goldfishes(Exel database)
        {
            // Получаем листы
            var animalsSheet = database.GetSheet("Животные");
            var salesSheet = database.GetSheet("Продажи");
            var customersSheet = database.GetSheet("Покупатели");

            // Проверка на наличие нужных листов
            if (animalsSheet == null || salesSheet == null || customersSheet == null)
            {
                Console.WriteLine("Один из нужных листов не найден!");
                return -1;
            }

            // Чтение данных
            var animalsCells = animalsSheet.Cells;
            var salesCells = salesSheet.Cells;
            var customersCells = customersSheet.Cells;

            // Переменная для подсчета количества продаж
            int goldfishSalesCount = 0;

            // Проходим по строкам таблицы продаж
            for (int salesRow = 1; salesRow <= salesCells.MaxDataRow; salesRow++) // Пропускаем заголовок
            {
                int animalId = Convert.ToInt32(salesCells[salesRow, 1].Value); // id животного
                DateTime saleDate = Convert.ToDateTime(salesCells[salesRow, 3].Value); // дата
                int customerId = Convert.ToInt32(salesCells[salesRow, 2].Value); // id покупателя

                // Проверяем, что это золотая рыбка
                for (int animalRow = 1; animalRow <= animalsCells.MaxDataRow; animalRow++) // Пропускаем заголовок
                {
                    int currentAnimalId = Convert.ToInt32(animalsCells[animalRow, 0].Value); // id животного
                    string type = animalsCells[animalRow, 1].Value?.ToString(); // вид
                    string breed = animalsCells[animalRow, 2].Value?.ToString(); // порода

                    // Если это золотая рыбка
                    if (currentAnimalId == animalId && type == "Рыбка" && breed == "Золотая рыбка")
                    {
                        // Ищем покупателя и проверяем его возраст
                        for (int customerRow = 1; customerRow <= customersCells.MaxDataRow; customerRow++) // Пропускаем заголовок
                        {
                            int currentCustomerId = Convert.ToInt32(customersCells[customerRow, 0].Value); // id покупателя
                            int age = Convert.ToInt32(customersCells[customerRow, 2].Value); // возраст покупателя

                            // Проверяем, что покупатель старше 50 лет
                            if (currentCustomerId == customerId && age > 50)
                            {
                                // Если это продажа золотой рыбки покупателю старше 50 лет, увеличиваем счетчик
                                goldfishSalesCount++;
                            }
                        }
                    }
                }
            }

            return goldfishSalesCount;
        }
    }
}
    

