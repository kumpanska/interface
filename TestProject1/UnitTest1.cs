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
    }
}