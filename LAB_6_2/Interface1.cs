using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6_2
{
    public interface IFractionOperations
    {
        double GetValue(); // Получение вещественного значения
        void SetNumerator(int numerator); // Установка числителя
        void SetDenominator(int denominator); // Установка знаменателя

    }
}
