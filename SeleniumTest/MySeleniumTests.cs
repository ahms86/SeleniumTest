using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumTest
{
    [TestClass]
    public class MySeleniumTests
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public MySeleniumTests()
        {
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void TheBingSearchTest()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.Id("sb_form_q")).SendKeys("Azure Pipelines");
            driver.FindElement(By.Id("sb_form_go")).Click();
            //  driver.FindElement(By.XPath("//ol[@id='b_results']/li[1]/h2/a[1])")).Click();
            // driver.FindElement(By.XPath("//ol[@id='b_results']/li[2]/div/h2/a[2]")).Click();
           // var firstresult = driver.FindElement(By.CssSelector("#b_contents b._results li.b_algo h2 a"));
            driver.FindElement(By.XPath("//*[@id=\"b_results\"]/li[@class=\"b_algo\"]")).Click();

           // firstresult.Click();
             
                Assert.IsTrue(driver.Title.Contains("Azure Pipelines"), "Verified title of the page");
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://www.bing.com/";

            string chromepath= Environment.GetEnvironmentVariable("ChromeWebDriver");
            string chromeexe = "chromedriver.exe";
            string fullchromeexe = chromepath + chromeexe;
            fullchromeexe = @"C:\SeleniumWebDrivers\ChromeDriver\chromedriver.exe";
            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver(fullchromeexe);
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
