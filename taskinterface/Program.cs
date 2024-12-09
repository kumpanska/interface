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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
