
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Security.Policy;

namespace BddOrange.StepDefinitions
{
    [Binding]
    public class AddUserStepDefinitions
    {

        private static IWebDriver _driver;

        [Before]
        public void InitializeBeforeEachScenario()
        {
            _driver = new ChromeDriver();
        }


        [After]
        public void CleanupAfterEveryScenario()
        {
            _driver.Quit();
            _driver.Dispose();
            //_driver = null;
        }



        [Given(@"I have successfully logged in as Administrator in Orange HRM website")]
        public void GivenIHaveSuccessfullyLoggedInAsAdministratorInOrangeHRMWebsite()
        {
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            Thread.Sleep(3000);
            _driver.FindElement(By.Name("username")).SendKeys("Admin");
            _driver.FindElement(By.Name("password")).SendKeys("admin123");
            _driver.FindElement(By.XPath("//button[contains(@class,'orangehrm-login-button')]")).Click();
        }

        [When(@"I click on Admin menu and Add new Admin user")]
        public void WhenIClickOnAdminMenuAndAddNewAdminUser()
        {
            Thread.Sleep(6000);
            _driver.FindElement(By.XPath("//a[contains(@class,'oxd-main-menu-item')]")).Click();
            Thread.Sleep(3000);
            _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div[2]/div[1]/button")).Click();
            Thread.Sleep(3000);
            
            var typeOfUser = _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[1]/div/div[2]/div/div/div[1]"));
            typeOfUser.Click();
            var choosetypeofuser = _driver.FindElements(By.XPath("//div[@role=\"listbox\"]")).FirstOrDefault();
            var textForChoosetypeofuser = choosetypeofuser.FindElements(By.TagName("div"));
            textForChoosetypeofuser[1].Click();

            var employeeName = _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[2]/div/div[2]/div/div/input"));
            employeeName.SendKeys("Fiona Grace");
            Thread.Sleep(3000);
            var choosetypeofEmployee = _driver.FindElements(By.XPath("//div[@role=\"listbox\"]")).FirstOrDefault();
            var textForChoosetypeofEmployee = choosetypeofEmployee.FindElements(By.TagName("div"));
            textForChoosetypeofEmployee[0].Click();


            var typeOfStatus = _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[3]/div/div[2]/div/div/div[1]"));
            typeOfStatus.Click();
            var choosetypeofStatus = _driver.FindElements(By.XPath("//div[@role=\"listbox\"]")).FirstOrDefault();
            var textForChoosetypeofStatus = choosetypeofStatus.FindElements(By.TagName("div"));
            textForChoosetypeofStatus[1].Click();

            _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[4]/div/div[2]/input")).SendKeys("Peter");

            _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/input")).SendKeys("Pass123");

            _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/input")).SendKeys("Pass123");

            _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[3]/button[2]")).Click();
        }

        [When(@"filled up the necessary fields")]
        public void WhenFilledUpTheNecessaryFields()
        {
            throw new PendingStepException();
        }

        [Then(@"I should be able to create a new admin user")]
        public void ThenIShouldBeAbleToCreateANewAdminUser()
        {
            Thread.Sleep(3000);
            _driver.PageSource.Contains("Jeganathan");
        }
    }
}
