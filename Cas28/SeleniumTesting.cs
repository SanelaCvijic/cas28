using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace Cas28
{
    class SeleniumTesting
    {
        IWebDriver driver;

        [Test]
        public void TestHomePage()
        {
            IWebElement logo = driver.FindElement(By.ClassName("logo"));
            if (logo.Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
           System.Threading.Thread.Sleep(3000);
        }

        [Test]
        public void Search()
        {   
            IWebElement buttonSearch = driver.FindElement(By.Name("submit_search"));
            if (buttonSearch.Displayed && buttonSearch.Enabled)
            {
                IWebElement searchInput = driver.FindElement(By.Name("search_query"));
                if (searchInput.Displayed && searchInput.Enabled)
                {
                    searchInput.SendKeys("faded");
                }

                buttonSearch.Click();
                Assert.Pass();

                System.Threading.Thread.Sleep(5000);
            }
        }
        
        [Test]
        public void Choice()
        {
            IWebElement titleItem = driver.FindElement(By.ClassName("product-name"));
            if (titleItem.Displayed && titleItem.Enabled)
            {
                titleItem.Click();
                Assert.Pass();

                System.Threading.Thread.Sleep(5000);
            }
        }
       


        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
