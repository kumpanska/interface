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
    class MyFrac : IMyNumber<MyFrac>,IComparable<MyFrac>
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
        override public String ToString()
        {
            return $"{nom}/{denom}";
        }
        public int CompareTo(MyFrac other)
        {
            return (this.nom * other.denom).CompareTo(other.nom * this.denom);
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
        override public String ToString()
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
            double denominator = that.re * that.re + that.im * that.im;
            return new MyComplex((this.re * that.re + this.im * that.im) / denominator, (this.im * that.re - this.re * that.im) / denominator);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
