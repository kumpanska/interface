using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace taskinterface
{
    interface IMyNumber<T> where T : IMyNumber<T>
    {
        T Add(T b);
        T Subtract(T b);
        T Multiply(T b);
        T Divide(T b);
    }
    class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private BigInteger nom;
        private BigInteger denom;
        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
            {
                throw new DivideByZeroException("Denominator can't be zero");
            }
            this.nom = nom;
            this.denom = denom;
        }
        public override String ToString()
        {
            return $"{nom}/{denom}";
        }
        public MyFrac(string str)
        {
            string[] parts = str.Split('/');
            if (parts.Length != 2 || !BigInteger.TryParse(parts[0], out nom) || !BigInteger.TryParse(parts[1], out denom))
            {
                throw new ArgumentException("Wrong format. Expected format: 'numerator/denominator'");
            }
            if (denom == 0)
            {
                throw new ArgumentException("Denominator can't be zero format");
            }

        }
        public int CompareTo(MyFrac that)
        {
            return (this.nom * that.denom).CompareTo(that.nom * this.denom);
        }
        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom + that.nom * this.denom, this.denom * that.denom);
        }
        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom - that.nom * this.denom, this.denom * that.denom);
        }
        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(this.nom * that.nom, this.denom * that.denom);
        }
        public MyFrac Divide(MyFrac that)
        {
            if (that.denom == 0)
            {
                throw new System.DivideByZeroException("Divide by zero");
            }
            return new MyFrac(this.nom * that.denom, this.denom * that.nom);
        }
    }
    class MyComplex : IMyNumber<MyComplex>
    {
        private double re;
        private double im;
        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        public MyComplex(string str)
        {
            string[] parts = str.Split(new char[] { '+', 'i' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2 || !double.TryParse(parts[0], out re) || !double.TryParse(parts[1], out im))
            {
                throw new ArgumentException("Wrong format. Expected format: 'real+imaginaryi'");
            }
        }
        public override String ToString()
        {
            return $"{re}+{im}i";
        }
        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(this.re + that.re, this.im + that.im);
        }
        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(this.re - that.re, this.im - that.im);
        }
        public MyComplex Multiply(MyComplex that)
        {
            return new MyComplex(this.re * that.re - this.im * that.im, this.re * that.im + this.im * that.re);
        }
        public MyComplex Divide(MyComplex that)
        {
            if (that.re == 0 && that.im == 0)
            {
                throw new System.DivideByZeroException("Divide by zero");
            }
            double numerator1 = this.re * that.re + this.im * that.im;
            double numerator2 = this.im * that.re - this.re * that.im;
            double denominator = that.re * that.re + that.im * that.im;
            return new MyComplex(numerator1 / denominator, numerator2 / denominator);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
