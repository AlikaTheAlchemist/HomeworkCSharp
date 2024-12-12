using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6
{
    // Произвольный класс, тоже реализующий интерфейс Meowable
    class MeowingToy : Meowable
    {
        public string Model { get; set; }

        public MeowingToy(string model)
        {
            Model = model;
        }

        // Перегруз ToString
        public override string ToString()
        {
            return $"игрушка: {Model}";
        }

        public void Meow()
        {
            Console.WriteLine($"{Model}: мяу!");
        }

        public void Meow(uint times)
        {
            if (times <= 0)
            {
                throw new ArgumentException("Количество раз должно быть положительным", nameof(times));
            }

            string meows = string.Join("-", new string[times].Select(_ => "мяу"));
            Console.WriteLine($"{Model}: {meows}!");
        }
    }
}
