using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_5_test
{
    internal class requests
    {

        // Сфинксы в январе 2023 года (сумма покупок)
        public static decimal Sphynx(List<Animals> animals, List<Sells> sells)
        {
            return sells
            // Соединяем по ID две таблицы
            .Join(animals,
                  sell => sell.AnymalID,
                  animal => animal.ID,
                  (sell, animal) => new { sell, animal })

            // Фильтруем результат
            .Where(x => x.animal.Type == "Кошка" &&
                        x.animal.Breed == "Сфинкс" &&
                        x.sell.Date.Year == 2023 &&
                        x.sell.Date.Month == 1)

            // Считаем сумму
            .Sum(x => x.sell.Price);

        }

        // Вывод списка покупателей по городу и возрасту
        public static List<Customers> CustomersByAgeAndCity(List<Customers> customers, uint age, string city)
        {
            return customers
                .Where(customer => customer.Age == age && customer.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Золотые рыбки купленные людьми старше 50 (тут немного другой способ, не такой как в запросе со сфинксами)
        public static int GoldfishPurchases(List<Sells> sells, List<Animals> animals, List<Customers> customers)
        {
            // Соединяем таблицы по ID
            int count = (from sell in sells
                         join animal in animals on sell.AnymalID equals animal.ID
                         join customer in customers on sell.CustomerID equals customer.ID

                         // Фильтруем результат
                         where animal.Type.Equals("Рыбка", StringComparison.OrdinalIgnoreCase) &&
                               animal.Breed.Equals("Золотая рыбка", StringComparison.OrdinalIgnoreCase) &&
                               customer.Age > 50

                         select sell).Count();

            return count;
        }


        // Вывести покупателей, купивших введённое животное в введённом городе (плюс информация о породе!!!)
        public static List<(Customers Buyer, string Breed)> BuyersByCityAndAnimal(List<Sells> sells, List<Animals> animals, List<Customers> customers, string city, string animalType)
        {

            var result = (from sell in sells
                          join animal in animals on sell.AnymalID equals animal.ID
                          join customer in customers on sell.CustomerID equals customer.ID


                          where customer.City.Equals(city, StringComparison.OrdinalIgnoreCase) &&
                                animal.Type.Equals(animalType, StringComparison.OrdinalIgnoreCase)


                          select (Buyer: customer, Breed: animal.Breed)).ToList();

            return result;
        }
   

    }
}
