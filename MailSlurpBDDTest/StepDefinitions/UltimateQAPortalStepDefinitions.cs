
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MailSlurpBDDTest.StepDefinitions
{
    [Binding]
    public class UltimateQAPortalStepDefinitions
    {
        private static IWebDriver _driver;

        [BeforeScenario]
        public void InitializeBeforeEachScenarioGetsExecuted()
        {
            _driver = new ChromeDriver();



        }



        [AfterScenario]
        public void CleanupAfterEveryScenarioGetsExecuted()
        {
            _driver.Quit();
            _driver.Dispose();
            //_driver = null;
        }

        [Given(@"I opened Chrome Web browser")]
        public void GivenIOpenedChromeWebBrowser()
        {
            //_driver = new ChromeDriver();
        }

        [When(@"navigate to ""([^""]*)"";")]
        public void WhenNavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
            var element = _driver.FindElement(By.Id("idExample"));
            element.Click();
        }

        [Then(@"it should take me to the success web page")]
        public void ThenItShouldTakeMeToTheSuccessWebPage()
        {
            _driver.Url.Should().Be("https://ultimateqa.com/button-success");
        }

        [Then(@"Its title should be ""([^""]*)""")]
        public void ThenItsTitleShouldBe(string title)
        {
            _driver.Title.Should().Contain(title);
        }

        [Given(@"navigate to ""([^""]*)"";")]
        public void GivenNavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [Given(@"I click the button with className ""([^""]*)""")]
        public void GivenIClickTheButtonWithClassName(string buttonClass)
        {
            var element = _driver.FindElement(By.ClassName(buttonClass));
            element.Click();
        }

        [Then(@"it should take me to the success web page with url ""([^""]*)""")]
        public void ThenItShouldTakeMeToTheSuccessWebPageWithUrl(string url)
        {
            _driver.Url.Should().Be(url);
        }

        [Given(@"I click the button with Name ""([^""]*)""")]
        public void GivenIClickTheButtonWithName(string name)
        {
            var element = _driver.FindElement(By.Name(name));
            element.Click();
        }

        [Given(@"I click the anchor link that has a text ""([^""]*)""")]
        public void GivenIClickTheAnchorLinkThatHasAText(string linkText)
        {
            _driver.FindElement(By.LinkText(linkText)).Click();
        }

        [When(@"I select a value ""([^""]*)"" from the drop down")]
        public void WhenISelectAValueFromTheDropDown(string opel)
        {
            //_driver = new ChromeDriver();
            var element = _driver.FindElement(By.XPath("//select"));
            element.Text.Should().Contain("Volvo");

            SelectElement e = new SelectElement(element);
            e.SelectByText(opel);
        }

        [When(@"I select a valuea ""([^""]*)"" from the drop down")]
        public void WhenISelectAValueaFromTheDropDown(string opel)
        {
            var element = _driver.FindElement(By.XPath("//select"));
            element.Text.Should().Contain("Volvo");

            SelectElement e = new SelectElement(element);
            e.SelectByText(opel);
        }


        [Then(@"it should shown the ""([^""]*)"" option in the top of the drop down list")]
        public void ThenItShouldShownTheOptionInTheTopOfTheDropDownList(string opel)
        {
            var element = _driver.FindElement(By.XPath("//select"));
            element.Text.Should().Contain(opel);
        }

    }
}
