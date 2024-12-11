using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace LAB_5_test
{
    internal class Requests
    {
        // Запрос из примера кошки Сфинксы
        public static int Cats(Workbook database)
        {
            // Получение таблиц
            Worksheet animalsSheet = database.Worksheets["животные"];
            Worksheet salesSheet = database.Worksheets["продажи"];

            if (animalsSheet == null || salesSheet == null)
            {
                Console.WriteLine("Таблицы 'животные' или 'продажи' не найдены!");
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


        public static string City(Workbook database)
        {
            // Получение таблицы "покупатели"
            Worksheet customersSheet = database.Worksheets["покупатели"];

            if (customersSheet  == null)
            {
                Console.WriteLine("Таблица 'покупатели' не найдена!");
                return "";
            }

            // Чтение данных
            Cells customersCells = customersSheet.Cells;


            // Список для хранения городов
            var cities = new List<string>();

            // Чтение данных из таблицы "покупатели"
            for (int customerRow = 1; customerRow <= customersCells.MaxDataRow; customerRow++) // Пропускаем заголовок
            {
                string city = customersCells[customerRow, 3].Value?.ToString(); // Адрес (город)
                if (!string.IsNullOrEmpty(city))
                {
                    cities.Add(city);
                }
            }

            // Находим самый часто встречающийся город
            var mostFrequentCity = cities
                .GroupBy(city => city)
                .OrderByDescending(group => group.Count())
                .FirstOrDefault()?.Key;

            return mostFrequentCity;
        }

    }
}
