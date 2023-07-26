using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Test_Project.StepDefinitions
{
    [Binding]
    public class RPNCalculatorStepDefinitions
    {
        private RPNCalculator.RPNCalculator rpnCalculators = new RPNCalculator.RPNCalculator();
        private String _rpnMathExpression;
        private double actualResult;

        [Given(@"the rpn expression input is ""([^""]*)""")]
        public void GivenTheRpnExpressionInputIs(String rpnMathExpression)
        {
            _rpnMathExpression = rpnMathExpression;
        }

        [When(@"the evaluated method is invoked")]
        public void WhenTheEvaluatedMethodIsInvoked()
        {
            actualResult = rpnCalculators.evaluate(_rpnMathExpression);
        }

        [Then(@"the expected result is ""([^""]*)""")]
        public void ThenThisExpectedResultIs(string strExpectedResult)
        {
            double expectedResult = double.Parse(strExpectedResult);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}