using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6
{
    
    // Класс Кот реализует интерфейс Meowable
    class Cat : Meowable
    {
        public string Name { get; set; }

        // Конструктор принимает имя кота
        public Cat(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя не может быть пустым", nameof(name));
            }
            Name = name;
        }

        // Перегруз ToString
        public override string ToString()
        {
            return $"кот: {Name}";
        }

        // Мяуканье без параметров
        public void Meow()
        {
            Console.WriteLine($"{Name}: мяу!");
        }

        // Мяуканье N раз
        public void Meow(uint times)
        {
            if (times <= 0)
            {
                throw new ArgumentException("Количество раз должно быть положительным", nameof(times));
            }

            string meows = string.Join("-", new string[times].Select(_ => "мяу"));
            Console.WriteLine($"{Name}: {meows}!");
        }
    }

   

}
