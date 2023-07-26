namespace RPNCalculator { 
    public class RPNCalculatorTest
    {
        private RPNCalculator rpnCalculator;
        private double actualResult;
        private double expectedResult;

        [SetUp]
        public void Setup()
        {
            rpnCalculator = new RPNCalculator();
            actualResult = 0;
            expectedResult = 0;
        }

        [TearDown]
        public void CleanUp()
        {
            rpnCalculator = null;
        }

        [Test]
        public void testSimpleAddition()
        {
            actualResult = rpnCalculator.evaluate("10 15 +");
            expectedResult = 25.0;
            Assert.AreEqual( expectedResult, actualResult );

            actualResult = rpnCalculator.evaluate("100 150 +");
            expectedResult = 250.0;
            Assert.AreEqual(expectedResult, actualResult);

            actualResult = rpnCalculator.evaluate("120 30 +");
            expectedResult = 150.0;
            Assert.AreEqual(expectedResult, actualResult);

        }
        [Test]
        public void testSimpleSubtraction()
        {
            actualResult = rpnCalculator.evaluate("100 15 -");
            expectedResult = 85.0;
            Assert.AreEqual(expectedResult, actualResult);

            actualResult = rpnCalculator.evaluate("150 15 -");
            expectedResult = 135.0;
            Assert.AreEqual(expectedResult, actualResult);

        }
        [Test]
        public void testSimpleMultiplication()
        {
            actualResult = rpnCalculator.evaluate("100 15 *");
            expectedResult = 1500.0;
            Assert.AreEqual(expectedResult, actualResult);

            actualResult = rpnCalculator.evaluate("15 10 *");
            expectedResult = 150.0;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void testSimpleDivision()
        {
            actualResult = rpnCalculator.evaluate("100 10 /");
            expectedResult = 10.0;
            Assert.AreEqual(expectedResult, actualResult);

            actualResult = rpnCalculator.evaluate("15 5 /");
            expectedResult = 3.0;
            Assert.AreEqual(expectedResult, actualResult);

        }


        [Test]
        public void testSimpleMathExpression()
        {
            actualResult = rpnCalculator.evaluate("100 20 / 20 5 - +");
            expectedResult = 20.0;
            Assert.AreEqual(expectedResult, actualResult);

            actualResult = rpnCalculator.evaluate("100 20 / 20 5 * +");
            expectedResult = 105;
            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}