using Calculator;
using NUnit.Framework;

namespace CalculatorTest
{
    public class BasicCalculatorTests
    {
        BasicCalculator bc;
        [SetUp]
        public void Setup()
        {
            bc = new BasicCalculator();
        }

        [TestCase(10,20)] // 1 testcase
        [TestCase(15,15)] // 2 testcase
        [TestCase(20, 15)]
        public void AddTest(int a, int b)
        {
            // AAA 
            // Assign
            /*int a = 10;
            int b = 20;*/

            // Act
            int result = bc.Add(a, b);
            
            // Assert
            int c = a + b;
            Assert.AreEqual(c, result);
        }

        [Test]
        public void SubTest()
        {
            // AAA 
            // Assign
            int a = 10;
            int b = 20;

            // Act
            int result = bc.Sub(b, a);

            // Assert
            Assert.AreEqual(10, result);
        }
    }
}