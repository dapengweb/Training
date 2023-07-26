using FluentAssertions.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using mailslurp.Api;
using mailslurp.Client;
using System.Text.RegularExpressions;

namespace MailSlurpBDDTest.StepDefinitions
{
    [Binding]
    public class EmailSignupInMailSlurpSampleWebsiteStepDefinitions
    {
        private static IWebDriver _driver;
        private static mailslurp.Client.Configuration _config;

        //MailSlur API Key
        private static readonly string apiKey = Environment.GetEnvironmentVariable("API_KEY", EnvironmentVariableTarget.User);
        private static readonly string driverPath = Environment.GetEnvironmentVariable("DRIVER_PATH", EnvironmentVariableTarget.User);
        private static readonly long TimeoutMillis = 30_000L;

        private readonly ScenarioContext _scenarioContext;
        private const string Password = "test-password";

        [After]
        public void CleanupAfterEveryScenarioGetsExecuted()
        {
            //_driver.Quit();
            //_driver.Dispose();
        }

        public EmailSignupInMailSlurpSampleWebsiteStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var timespan = TimeSpan.FromMilliseconds(TimeoutMillis);
            var service = string.IsNullOrEmpty(driverPath)
                ?ChromeDriverService.CreateDefaultService() : ChromeDriverService.CreateDefaultService(driverPath);
            _driver = new ChromeDriver(service,new ChromeOptions(),timespan);
            _driver.Manage().Timeouts().ImplicitWait = timespan;

            apiKey.Should().NotBeNull();
            _config = new mailslurp.Client.Configuration();
            _config.ApiKey.Add("x-api-key", apiKey);
        }

        [Given(@"an user visits the MailSlurp demo web site")]
        public void GivenAnUserVisitsTheMailSlurpDemoWebSite()
        {
            _driver.Navigate().GoToUrl("https://playground.mailslurp.com");
            _driver.Title.Should().Contain("React App");

            _driver.FindElement(By.CssSelector("[data-test=sign-in-create-account-link]")).Click();
        }

        [Given(@"has a test email address")]
        public void GivenHasATestEmailAddress()
        {
            var inboxApi = new InboxControllerApi(_config);
            var inbox = inboxApi.CreateInbox();

            _scenarioContext.Add("emailAddress", inbox.EmailAddress);
            _scenarioContext.Add("inboxId", inbox.Id);
        }

        [When(@"the user signs up")]
        public void WhenTheUserSignsUp()
        {
            //_driver.FindElement(By.Name("username")).SendKeys(_scenarioContext.Get<string>("emailAddress"));
            //_driver.FindElement(By.Name("password")).SendKeys(Password);
            //_driver.FindElement(By.CssSelector("[data-test=sign-in-sign-in-button]")).Click();

            _driver.FindElement(By.Name("email")).SendKeys(_scenarioContext.Get<string>("emailAddress"));
            _driver.FindElement(By.Name("password")).SendKeys(Password);

            _driver.FindElement(By.CssSelector("[data-test=sign-up-create-account-button]")).Click();
        }

        [Then(@"the receive a confirmation code by email that can verify their account")]
        public void ThenTheReceiveAConfirmationCodeByEmailThatCanVerifyTheirAccount()
        {
            var inboxId = _scenarioContext.Get<Guid>("inboxId");
            var emailAddress = _scenarioContext.Get<string>("emailAddress");
            var waitForApi = new WaitForControllerApi(_config);
            var email = waitForApi.WaitForLatestEmail(inboxId: inboxId, timeout: 30000L, unreadOnly: true);
            Thread.Sleep(10000);
            email.Subject.Should().Contain("Please confirm your email address");

            var regularExpr = new Regex(@".*verification code is (\d{6}.*)",RegexOptions.Compiled);
            var match = regularExpr.Match(email.Body);
            var confirmationCode = match.Groups[1].Value;
            confirmationCode.Length.Should().Be(6);

            _driver.FindElement(By.Name("code")).SendKeys(confirmationCode);
            _driver.FindElement(By.CssSelector("[data-test=confirm-sign-up-confirm-button]")).Click();

            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(10000);

            //attempt to login with the newly created email
            _driver.Navigate().GoToUrl("https://playground.mailslurp.com");
            _driver.FindElement(By.Name("username")).SendKeys(emailAddress);
            _driver.FindElement(By.Name("password")).SendKeys(Password);
            _driver.FindElement(By.CssSelector("[data-test=sign-in-sign-in-button]")).Click();

            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(10000);
            _driver.FindElement(By.TagName("h1")).Text.Contains("Welcome").Should().BeTrue();
        }

    }
}
