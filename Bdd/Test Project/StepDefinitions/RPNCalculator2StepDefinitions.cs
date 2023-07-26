using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Test_Project.StepDefinitions
{
    [Binding]
    public class RPNCalculator2StepDefinitions
    {
        private RPNCalculator.RPNCalculator rpnCalculators = new RPNCalculator.RPNCalculator();
        private String _rpnMathExpression;
        private double actualResult;
        private Exception actualException;

        [Given(@"the rpn math expression input is ""([^""]*)""")]
        public void GivenTheRpnMathExpressionInputIs(String rpnMathExpression)
        {
            _rpnMathExpression = rpnMathExpression;
        }

        [When(@"thie evaluate method is invoked")]
        public void WhenThieEvaluateMethodIsInvoked()
        {
            try
            {
                actualResult = rpnCalculators.evaluate(_rpnMathExpression);
            }
            catch (Exception ex)
            {
                actualException = ex;
            }
        }

        [Then(@"this expected result is ""([^""]*)""")]
        public void ThenThisExpectedResultIs(string strExpectedResult)
        {
            double expectedResult = double.Parse(strExpectedResult);
            Assert.AreEqual(expectedResult, actualResult,0.0001);
        }

        [Then(@"it should throw Exception with message ""([^""]*)""")]
        public void ThenThisExpectedIsItShouldThrowExceptionWithMessage(string expectedErrorMessage)
        {
            Assert.AreEqual(expectedErrorMessage,actualException.Message);
        }

    }
}
