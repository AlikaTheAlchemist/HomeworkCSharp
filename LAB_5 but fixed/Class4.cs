using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Aspose.Cells;

namespace LAB_5_test
{

    public class Database
    {

        // Создать лист животных
        public static List<Animals> CreateAnimalsList(string CastomFilePath)
        {
            // Список для хранения объектов Animal
            List<Animals> animals = new List<Animals>();

            // Загружаем файл Excel
            Workbook workbook = new Workbook(CastomFilePath);
            Worksheet worksheet = workbook.Worksheets[0]; // Получаем первый лист

            Cells cells = worksheet.Cells;
            int maxRow = cells.MaxRow;
            int maxColumn = cells.MaxColumn;

            // Получаем количество строк
            int rowCount = maxRow + 1; // MaxDataRow возвращает индекс последней строки с данными

            for (int row = 1; row < rowCount; row++) // начинаем с 1, чтобы пропустить заголовки
            {
                int id = int.Parse(worksheet.Cells[row, 0].Value.ToString()); // ID
                string type = worksheet.Cells[row, 1].Value.ToString();        // Вид
                string breed = worksheet.Cells[row, 2].Value.ToString();       // Порода

                // Используем конструктор для создания объекта Animal
                Animals animal = new Animals(id, type, breed);

                animals.Add(animal);
            }

            return animals;
        }


        // Создать список покупателей
        public static List<Customers> CreateCustomersList(string CastomFilePath)
        {
            // Список для хранения объектов Animal
            List<Customers> Byers = new List<Customers>();

            // Загружаем файл Excel
            Workbook workbook = new Workbook(CastomFilePath);
            Worksheet worksheet = workbook.Worksheets[1]; // Получаем первый лист

            Cells cells = worksheet.Cells;
            int maxRow = cells.MaxRow;
            int maxColumn = cells.MaxColumn;

            // Получаем количество строк
            int rowCount = maxRow + 1; // MaxDataRow возвращает индекс последней строки с данными

            for (int row = 1; row < rowCount; row++) // начинаем с 1, чтобы пропустить заголовки
            {
                int id = int.Parse(worksheet.Cells[row, 0].Value.ToString());  // ID
                string name = worksheet.Cells[row, 1].Value.ToString();        // Имя
                int age = int.Parse(worksheet.Cells[row, 2].Value.ToString()); // Возраст
                string city = worksheet.Cells[row, 3].Value.ToString();        // Город

                // Используем конструктор для создания объекта Animal
                Customers customer = new Customers(id, name, age, city);

                Byers.Add(customer);
            }

            return Byers;
        }

        // Создать список покупок
        public static List<Sells> CreateSellsList(string CastomFilePath)
        {
            // Список для хранения объектов Animal
            List<Sells> Sayls = new List<Sells>();

            // Загружаем файл Excel
            Workbook workbook = new Workbook(CastomFilePath);
            Worksheet worksheet = workbook.Worksheets[2]; // Получаем первый лист

            Cells cells = worksheet.Cells;
            int maxRow = cells.MaxRow;
            int maxColumn = cells.MaxColumn;

            // Получаем количество строк
            int rowCount = maxRow + 1; // MaxDataRow возвращает индекс последней строки с данными

            for (int row = 1; row < rowCount; row++) // начинаем с 1, чтобы пропустить заголовки
            {
                int id = Convert.ToInt32(worksheet.Cells[row, 0].Value);  // ID
                int ida = int.Parse(worksheet.Cells[row, 1].Value.ToString());  // ID животного
                int idc = int.Parse(worksheet.Cells[row, 2].Value.ToString());   // ID покупателя
                DateTime date = Convert.ToDateTime(worksheet.Cells[row, 3].Value); // Дата
                int age = int.Parse(cells[row, 4].Value.ToString()); // Цена



                // Используем конструктор для создания объекта Animal
                Sells Sell = new Sells(id, ida, idc, date, age);

                Sayls.Add(Sell);
            }

            return Sayls;
        }

        public static string AnimalsHeader()
        {
            StringBuilder sb = new StringBuilder();
            string cellid = "ID";
            sb.Append(cellid.PadRight(15)); // Отступ между колонками
            string celltp = "Вид";
            sb.Append(celltp.PadRight(15));
            string cellbr = "Порода";
            sb.Append(cellbr.PadRight(15));
            return sb.ToString();
        }

        public static string CustomerHeader()
        {
            StringBuilder sb = new StringBuilder();
            string cellid = "ID";
            sb.Append(cellid.PadRight(15)); // Отступ между колонками
            string cellnm = "Имя";
            sb.Append(cellnm.PadRight(20));
            string cellag = "Возраст";
            sb.Append(cellag.PadRight(15));
            string cellct = "Город";
            sb.Append(cellct.PadRight(15));
            return sb.ToString();
        }

        public static string SellsHeader()
        {
            StringBuilder sb = new StringBuilder();
            string cellid = "ID";
            sb.Append(cellid.PadRight(15)); // Отступ между колонками
            string cellida = "ID животного";
            sb.Append(cellida.PadRight(15));
            string cellidc = "ID покупателя";
            sb.Append(cellidc.PadRight(15));
            string celldt = "Дата";
            sb.Append(celldt.PadRight(20));
            string cellprc = "Цена";
            sb.Append(cellprc.PadRight(15));
            return sb.ToString();
        }

        // Вывод одного листа
        public static void PrintList<T> (List<T> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            foreach (T item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        // Удаление элемента по ключу
        public static void DeleteObjectByID<T>(List<T> list, uint id) where T : IDhelper
        {
            var ToRemove = list.FirstOrDefault(item => item.ID == id); // Находим первый объект в списке, у которого ID равно заданному
            if (ToRemove != null)
            {
                list.Remove(ToRemove);
                Console.WriteLine($"Объект с ID {id} удалён.");
            }
            else
            {
                Console.WriteLine($"Объект с ID {id} не найден.");
            }
        }

        // Корректирование элемента по ключу
        public static void UpdateByID<T>(List<T> list, uint id) where T : IDhelper
        {
            var ToUpdate = list.FirstOrDefault(item => item.ID == id);      // Находим первый объект в списке, у которого ID равно заданному
            if (ToUpdate == null)
            {
                Console.WriteLine($"Объект с ID {id} не найден.");
                return;
            }

            // Выводим текущие значения объекта
            Console.WriteLine("Текущие значения объекта:");
            foreach (var prop in typeof(T).GetProperties())
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(ToUpdate)}");       // для каждого свойства выводится имя и значение
            }

            Console.WriteLine("Введите имя свойства, которое хотите изменить (или 'exit' для выхода):");
            string propertyName = Console.ReadLine();

            while (propertyName.ToLower() != "exit")
            {
                var property = typeof(T).GetProperty(propertyName);     // Ищем свойство с указанным именем
                if (property == null)
                {
                    Console.WriteLine("Свойство не найдено. Повторите ввод:");
                }
                else
                {
                    Console.WriteLine($"Введите новое значение для {propertyName}:");
                    string newValue = Console.ReadLine();
                    try
                    {
                        var convertedValue = Convert.ChangeType(newValue, property.PropertyType);
                        property.SetValue(ToUpdate, convertedValue);
                        Console.WriteLine($"{propertyName} обновлено успешно!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при обновлении свойства: {ex.Message}");
                    }
                }

                Console.WriteLine("Введите имя следующего свойства для изменения (или 'exit' для выхода):");
                propertyName = Console.ReadLine();
            }

            Console.WriteLine("Изменения сохранены.");
        }


        // Добавить элемент
        public static void AddItem<T>(List<T> list) where T : class
        {
            // Создание нового объекта
            T newItem = (T)Activator.CreateInstance(typeof(T), nonPublic: true);

            Console.WriteLine($"Добавление нового объекта типа {typeof(T).Name}:");

            // Автогенерация ID
            var idProperty = typeof(T).GetProperty("ID");
            if (idProperty != null && idProperty.PropertyType == typeof(int))
            {
                int newId = list.Count > 0
                    ? list.Max(item => (int)idProperty.GetValue(item)) + 1
                    : 1; // Если список пуст, начинаем с 1
                idProperty.SetValue(newItem, newId);
                Console.WriteLine($"Сгенерирован ID: {newId}");
            }

            // Заполнение остальных свойств через пользовательский ввод
            foreach (var property in typeof(T).GetProperties())
            {
                if (property.Name == "ID") continue; // Пропускаем свойство ID, оно уже установлено

                Console.Write($"Введите значение для {property.Name} ({property.PropertyType.Name}): ");
                string input = Console.ReadLine();

                try
                {
                    var convertedValue = Convert.ChangeType(input, property.PropertyType);
                    property.SetValue(newItem, convertedValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при вводе значения для {property.Name}: {ex.Message}");
                }
            }

            list.Add(newItem);
            Console.WriteLine("Объект добавлен:");
            Console.WriteLine(newItem);
        }
    }
}
