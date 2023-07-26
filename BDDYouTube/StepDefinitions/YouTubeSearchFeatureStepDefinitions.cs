using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics.Metrics;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace BDDYouTube.StepDefinitions
{
    [Binding]
    public class YouTubeSearchFeatureStepDefinitions : IDisposable
    {
        private static ChromeDriver chromeDriver;
        private string url;
        private string searchString;

        public YouTubeSearchFeatureStepDefinitions() => chromeDriver = new ChromeDriver();
        [BeforeFeature]
        public static void initBeforeEveryScenario()
        {
            
        }
        [AfterFeature]
        public static void tearDownAfterScenario()
        {
            chromeDriver = null;
        }

        [Given(@"I typed YouTube url ""([^""]*)""")]
        public void GivenITypedYouTubeUrl(string youTubeUrl)
        {
            url = youTubeUrl;
        }

        [When(@"I navigate to youtube page")]
        public void WhenIPressTheEnterButtonInTheChromeWebBrowserAddressBar()
        {
            chromeDriver.Navigate().GoToUrl(url);
        }

        [When(@"I search for ""([^""]*)"" in the YouTube")]
        public void WhenISearchForInHeYouTube(string searchString)
        {
            this.searchString = searchString;
            // Find the search box element and send the search query
            IWebElement searchBox = chromeDriver.FindElement(By.Name("search_query"));
            searchBox.SendKeys(searchString);
            searchBox.Submit();

            // Wait for the search results to load
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains(searchString));

            //// Print the title of the search results page
            //Console.WriteLine(chromeDriver.Title);
        }


        [Then(@"I should see the YouTube web page")]
        public void ThenIShouldSeeTheYouTubeWebPage()
        {

        }

        [Then(@"the web page title should be ""([^""]*)""")]
        public void ThenTheWebPageTitleShouldBe(string title)
        {
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains(title));
        }


        public void Dispose()
        {
            ((IDisposable)chromeDriver).Dispose();
        }
    }
}
