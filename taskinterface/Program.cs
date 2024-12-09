using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace taskinterface
{
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
