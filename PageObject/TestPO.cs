using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumwithDotNetCore.PageObject
{
    public class TestPO 
    {
        IWebDriver driver;

        public TestPO(IWebDriver driver)
        {
            this.driver = driver;
        }

        [FindsBy(How =How.XPath,Using =("//input[@title='Search']"))]
        IWebElement googleSearch { get; set; }

        public TestPO NavigatetoURL(string URL)
        {
            driver.Navigate().GoToUrl(URL);

            return this;
        }

        public TestPO SearchText(String text)
        {
            googleSearch.SendKeys(text);
            return this;
        }

    }
}
