namespace Calculator.Test
{
    public class Tests
    {
        Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TestCase(2, 2, 4)]
        public void TestAdd(int a, int b, int result)
        {
            Assert.That(_calculator.Add(a, b), Is.EqualTo(result));
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 2, 1)]
        public void TestDivide(int a, int b, int result)
        {
            Assert.That(_calculator.Divide(a, b), Is.EqualTo(result));
        }
    }
}