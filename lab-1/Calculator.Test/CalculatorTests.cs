namespace Calculator.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        [TestCase(1, 1, 1)]    // Test case with parameters (1 * 1 = 1)
        [TestCase(2, 2, 4)]    // Test case with parameters (2 * 2 = 4)
        public void ProductTest(int a, int b, int expectedResult)
        {
            int result = calculator.Product(a, b);
            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}