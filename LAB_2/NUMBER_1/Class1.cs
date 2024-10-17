using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{

    // базовый класс
    internal class CastomString
    {
        // поля
        private string x;

        // аксессоры (свойства)
        // строка
        public string TheString 
        {
            set { x = value; }
            get { return x; }   
        
        }

        // конструкторы
        // конструктор без параметров / по умолчанию
        public CastomString() { this.x = "";}

        // конструктор с параметрами
        public CastomString(string x) {this.x = x;}

        // конструктор копирования
        public CastomString(CastomString a) {this.x = a.x;}


        // добавить воскицательные знаки в начало
        public void ExclamationMark() { this.x = "!!!" + this.x; }

        // перегруз ту стринг 
        public override string ToString()
        {
            return $"Имя: {x}";
        }

    }



    // ДОЧЕРНИЙ КЛАСС с полем для числа
    class NumberForString : CastomString
    {
        private int number;

        public int Number
        {
            set { number = value; }
            get { return number; }
        }


        // конструктор с параметрами
        public NumberForString(string x, int number)
            : base(x)
        {
            Number = number;
        }


        // конструктор копирования
        public NumberForString(NumberForString a) 
            : base(a)
        {
            this.number = a.number;
        }

        // увеличение числа на заданное значение
        public void IncreaseNumber(int value)
        {
            number += value;
        }

        // заменить число
        public void SetNumber(int newNumber)
        {
            number = newNumber;
        }

        // перегрузка ту стринг ещё раз на всякий случай
        public override string ToString()
        {
            return $"Имя: {TheString}, Баллы: {Number}";
        }



    }

}

