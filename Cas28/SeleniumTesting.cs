using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
                //  Assert.Pass();

                //System.Threading.Thread.Sleep(8000);
            }


            IWebElement titleItem = driver.FindElement(By.XPath("//h5/a[@href='http://automationpractice.com/index.php?id_product=1&controller=product&search_query=faded&results=1']"));
            if (titleItem.Displayed && titleItem.Enabled)
            {
                titleItem.Click();
             //  Assert.Pass();

                System.Threading.Thread.Sleep(5000);
            }
            
            IWebElement buttonAdd = driver.FindElement(By.Name("Submit"));
            if (buttonAdd.Displayed && buttonAdd.Enabled) 
            { 

                 IWebElement quantityInput = driver.FindElement(By.Id("quantity_wanted"));
                 if (quantityInput.Displayed && quantityInput.Enabled)
                 {
                    quantityInput.Clear();
                    quantityInput.SendKeys("2");
                 }

                IWebElement sizeSelect = driver.FindElement(By.Name("group_1"));
                if (quantityInput.Displayed && quantityInput.Enabled)
                {
                    SelectElement size = new SelectElement(sizeSelect);
                    size.SelectByText("L");
                }

                buttonAdd.Click();
               // Assert.Pass();

                System.Threading.Thread.Sleep(5000);
            }

            //  "//div[@class='clearfix']/div[@class='layer_cart_product col-xs-12 col-md-6']/h2[]"

            //(By.XPath("//text()[contains(.,'Product successfully added to your shopping cart')]"));
            //(By.XPath("//*[text()='Product successfully added to your shopping cart']"));
            //(By.XPath("//*[contains(text(),'Product successfully added to your shopping cart')]"));

            IWebElement buttonContinue = driver.FindElement(By.XPath("//div[@class='button-container']/span[@title='Continue shopping']"));
            if (buttonContinue.Displayed && buttonContinue.Enabled)
            {/*
                IWebElement successAdd = driver.FindElement(By.XPath("//text()[contains(.,'Product successfully added to your shopping cart')]"));
                        if(successAdd.Displayed && successAdd.Enabled){
                                        
                          //Assert.Pass();
                                         
                          }
                */ 
               
                     buttonContinue.Click();
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
