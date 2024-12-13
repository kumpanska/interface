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
            SimplifyFrac();
        }
        private void SimplifyFrac()
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(nom, denom);
            nom /= gcd;
            denom /= gcd;
            if (denom < 0)
            {
                nom = -nom;
                denom = -denom;
            }
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
            MyFrac frac1 = new MyFrac("4/8");
            MyFrac frac2 = new MyFrac("6/8");
            Console.WriteLine($"{frac1}+{frac2}");
            Console.WriteLine(frac1.Add(frac2));
            TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
            TestSquareDifference(new MyFrac(1, 2), new MyFrac(1, 3));
            TestSquareDifference(new MyComplex(1, 2), new MyComplex(1, 3));
            Console.ReadKey();
        }
        static void TestSquareDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a^2-b^2)/(a+b)=((a-b)(a+b))/(a+b) with a = " + a + ", b = " + b + " ===");
            T aMinusB = a.Subtract(b);
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a - b) = " + aMinusB);
            Console.WriteLine("(a + b) = " + aPlusB);
            T aSquared = a.Multiply(a);//a^2
            T bSquared = b.Multiply(b);//b^2
            Console.WriteLine("a^2 = " + aSquared);
            Console.WriteLine("b^2 = " + bSquared);
            T leftSide = aSquared.Subtract(bSquared);//a^2-b^2
            Console.WriteLine("(a^2 - b^2) = " + leftSide);
            Console.WriteLine("(a^2 - b^2)/(a+b) = " + leftSide.Divide(aPlusB));//(a^2-b^2)/(a+b)
            Console.WriteLine(" = = = ");
            T rightSide = aMinusB.Multiply(aPlusB);//(a-b)(a+b)
            Console.WriteLine("(a-b)(a+b) " + rightSide);
            Console.WriteLine("((a-b)(a+b))/(a+b) " + rightSide.Divide(aPlusB));//((a-b)(a+b))/(a+b)
            Console.WriteLine("=== Finishing testing (a^2-b^2)/(a+b)=((a-b)(a+b))/(a+b) with a = " + a + ", b = " + b + " ===");
        }
        static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
                                   // I'm not sure how to create constant factor "2" in more elegant way,
                                   // without knowing how IMyNumber is implemented
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }
    }
}
