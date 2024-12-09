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
    class MyFrac
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
        MyFrac Add(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom + that.nom * this.denom, this.denom * that.denom);
        }
        MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom - that.nom * this.denom, this.denom * that.denom);
        }
        MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(this.nom * that.nom, this.denom * that.denom);
        }
        MyFrac Divide(MyFrac that)
        {
            if (that.denom == 0)
            {
                throw new System.DivideByZeroException("Divide by zero");
            }
            return new MyFrac(this.nom * that.denom, this.denom * that.nom);
        }
    }
    class MyComplex
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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
