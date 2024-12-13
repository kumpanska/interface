using taskinterface;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
        }
        [TestMethod]
        public void TestMyComplex_Multiplication()
        {
            var complex1 = new MyComplex(1, 2);
            var complex2 = new MyComplex(3, 4);
            var result = complex1.Multiply(complex2);
            Assert.AreEqual("-5+10i", result.ToString());
        }
        [TestMethod]
        public void TestMyComplex_Divide()
        {
            var complex1 = new MyComplex(1, 2);
            var complex2 = new MyComplex(1, 3);
            var result = complex1.Divide(complex2);
            Assert.AreEqual("0,7-0,1i", result.ToString());
        }
        [TestMethod]
        public void TestMyComplex_Substract()
        {
            var complex1 = new MyComplex(5, 4);
            var complex2 = new MyComplex(3, 7);
            var result = complex1.Subtract(complex2);
            Assert.AreEqual("2-3i", result.ToString());
        }
        [TestMethod]
        public void TestMyComplex_Addition()
        {
            var complex1 = new MyComplex(10, 9);
            var complex2 = new MyComplex(2, 7);
            var result = complex1.Subtract(complex2);
            Assert.AreEqual("8+2i", result.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMyComplex_ExceptionDivideByZero()
        {
            var complex1 = new MyComplex(-1, 2);
            var complex2 = new MyComplex(0, 0);
            var result = complex1.Divide(complex2);
        }
        [TestMethod]
        public void TestMyComplex_Constructor()
        {
            var complex = new MyComplex(3.5, -2.7);
            Assert.AreEqual("3,5-2,7i", complex.ToString());
        }
        [TestMethod]
        public void TestMyComplex_ConstructorWithString()
        {
            var complex = new MyComplex("4+1i");
            Assert.AreEqual("4+1i", complex.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMyComplex_ConstructorInvalidString()
        {
            var complex = new MyComplex("4f+1i");
        }
        public void TestMyFrac_Constructor()
        {
            var frac = new MyFrac(3,2);
            Assert.AreEqual("3/2", frac.ToString());
        }
        [TestMethod]
        public void TestMyRrac_ConstructorWithString()
        {
            var frac = new MyFrac("15/7");
            Assert.AreEqual("15/7", frac.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMyFrac_ConstructorInvalidString()
        {
            var frac = new MyFrac("14/9h");
        }
    }
}