using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6
{
    // Интерфейс для мяукающих объектов
    interface Meowable
    {
        void Meow();
        void Meow(uint times);
    }

    // Обертка для подсчета количества мяуканий
    class MeowCounter : Meowable
    {
        private readonly Meowable _meowable;
        public uint MeowCount { get; set; }

        public MeowCounter(Meowable meowable)
        {
            _meowable = meowable;
            MeowCount = 0;
        }

        public void Meow()
        {
            _meowable.Meow();
            MeowCount++;
        }

        public void Meow(uint times)
        {
            _meowable.Meow(times);
            MeowCount += times;
        }
    }

}
