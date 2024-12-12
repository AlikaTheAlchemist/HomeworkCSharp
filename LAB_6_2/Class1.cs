using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6_2
{

    public class Fraction : ICloneable, IFractionOperations
    {
        private int numerator;
        private int denominator;
        private double? cachedValue; // Кэшированное вещественное значение

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю");
            }

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            this.numerator = numerator;
            this.denominator = denominator;
            Simplify();
            cachedValue = null; // Сбрасываем кэш при изменении дроби
        }

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        // Интерфейсы

        // Клонирование
        public object Clone()
        {
            // Возвращаем новый объект, созданный с теми же значениями числителя и знаменателя
            return new Fraction(this.numerator, this.denominator);
        }

        // Получение вещественного значения
        public double GetValue()
        {
            if (!cachedValue.HasValue) // Если значение не кэшировано, вычисляем его
            {
                cachedValue = (double)numerator / denominator;
            }
            return cachedValue.Value;
        }

        // Установка числителя
        public void SetNumerator(int numerator)
        {
            this.numerator = numerator;
            Simplify();
            cachedValue = null; // Сбрасываем кэш
        }

        // Установка знаменателя
        public void SetDenominator(int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю");
            }

            this.denominator = denominator;
            Simplify();
            cachedValue = null; // Сбрасываем кэш
        }



        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int num = f1.numerator * f2.denominator + f2.numerator * f1.denominator;
            int den = f1.denominator * f2.denominator;
            return new Fraction(num, den);
        }

        public static Fraction operator +(Fraction f, int n)
        {
            return f + new Fraction(n, 1);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int num = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
            int den = f1.denominator * f2.denominator;
            return new Fraction(num, den);
        }

        public static Fraction operator -(Fraction f, int n)
        {
            return f - new Fraction(n, 1);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int num = f1.numerator * f2.numerator;
            int den = f1.denominator * f2.denominator;
            return new Fraction(num, den);
        }

        public static Fraction operator *(Fraction f, int n)
        {
            return f * new Fraction(n, 1);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.numerator == 0)
            {
                throw new ArgumentException("Cannot divide by zero");
            }
            int num = f1.numerator * f2.denominator;
            int den = f1.denominator * f2.numerator;
            return new Fraction(num, den);
        }

        public static Fraction operator /(Fraction f, int n)
        {
            if (n == 0)
            {
                throw new ArgumentException("Cannot divide by zero");
            }
            return f / new Fraction(n, 1);
        }

        public Fraction Sum(Fraction f)
        {
            return this + f;
        }

        public Fraction Div(Fraction f)
        {
            return this / f;
        }

        public Fraction Minus(Fraction f)
        {
            return this - f;
        }

        public Fraction Minus(int n)
        {
            return this - n;
        }

        public Fraction Multiply(Fraction f)
        {
            return this * f;
        }


        // Сравнение дробей
        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this.numerator == other.numerator && this.denominator == other.denominator;
            }
            return true;
        }

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            if (ReferenceEquals(f1, null) && ReferenceEquals(f2, null))
                return true;
            if (ReferenceEquals(f1, null) || ReferenceEquals(f2, null))
                return false;

            return f1.Equals(f2);
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }


        
    }

   
}
