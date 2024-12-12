using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6
{
    class Program
    {
        static void Main()
        {
            // Создаем кота
            Cat barsik = new Cat("Барсик");

            // Оборачиваем кота в счетчик мяуканий
            MeowCounter countedBarsik = new MeowCounter(barsik);

            // Создаем еще одного кота
            Cat murzik = new Cat("Мурзик");

            // Создаем игрушку
            MeowingToy toy = new MeowingToy("Мяукающая игрушка");

            Console.WriteLine(barsik);
            Console.WriteLine(murzik);
            Console.WriteLine(toy);

            // Список мяукающих объектов
            var meowables = new List<Meowable> { countedBarsik, murzik, toy };

            // Вызываем метод для мяуканья всех объектов 1 раз
            MakeAllMeow(meowables, 1);

            // Барсик мяукает отдельно
            countedBarsik.Meow(3);

            // Выводим количество мяуканий для Барсика
            Console.WriteLine($"{barsik.Name} мяукал {countedBarsik.MeowCount} раз(а).");

        }


        // Метод, принимающий набор мяукающих объектов
        static void MakeAllMeow(IEnumerable<Meowable> meowables, uint times)
        {
            foreach (var meowable in meowables)
            {
                meowable.Meow(times);
            }
        }
    }

}