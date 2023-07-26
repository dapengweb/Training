

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BddOrange.StepDefinitions
{
    [Binding]
    public class OrangeLoginStepDefinitions
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


        [Given(@"go to url ""([^""]*)""")]
        public void GivenGoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [When(@"we use username and password to login")]
        public void WhenWeUseUsernameAndPasswordToLogin()
        {
            Thread.Sleep(3000);
            _driver.FindElement(By.Name("username")).SendKeys("Admin");
            _driver.FindElement(By.Name("password")).SendKeys("admin123");
            _driver.FindElement(By.XPath("//button[contains(@class,'orangehrm-login-button')]")).Click();
        }

        [Then(@"go to success url")]
        public void ThenGoToSuccessUrl()
        {
            Thread.Sleep(3000);
            _driver.FindElement(By.XPath("//a[contains(@class,'oxd-main-menu-item')]")).Click();
            Thread.Sleep(3000);
            _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[1]/div/div[2]/input")).SendKeys("Admin");
            _driver.FindElement(By.XPath("//button[contains(@class,'oxd-button--medium oxd-button--secondary')]")).Click();
            _driver.PageSource.Should().Contain("(1) Record Found");
            //var info = _driver.PageSource.Should().Contain("Febrian RizkytestingLastName");
        }
    }
}
