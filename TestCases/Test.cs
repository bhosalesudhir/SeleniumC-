
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumwithDotNetCore.PageObject;
using SeleniumwithDotNetCore;
using System.Collections.Generic;

namespace SeleniumwithDotNetCore.TestCases
{
    [TestFixture]
    public class Tests : BaseClass
    {
        IWebDriver _driver;
        public TestPO _testpo;


        [SetUp] // hooks in Nunit
        public void Setup()
        {
            _driver = InitializeDriver();

            _testpo = PageFactory.InitElements<TestPO>(_driver); // from SeleniumExtras.PageObjects;
        }

        [Test]
        public void NavigateToGooglePage()
        {
            _testpo.NavigatetoURL(URL);
            IList<IWebElement> it=_driver.FindElements(By.Id("google"));
        }
        [Test]
        public void NavigateToGoogleTolocateID()
        {
            _testpo.NavigatetoURL(URL);
            _driver.FindElement(By.Id("Seach"));

        }
        [Test]
        public void NavigateToGooglePageAndSearch()
        {
            _testpo.NavigatetoURL(URL)
                   .SearchText("Java");
           
        }
        [Test]
        public void NavigateToGooglePage4()
        {
            _testpo.NavigatetoURL(URL);
            _driver.FindElement(By.Id("google"));
        }
        [Test]
        public void NavigateToGoogleTolocateID5()
        {
            _testpo.NavigatetoURL(URL);
            _driver.FindElement(By.Id("Seach"));
        }
        [Test]
        public void NavigateToGooglePageAndSearch6()
        {
            _testpo.NavigatetoURL(URL)
                   .SearchText("Java");
        }
        [TearDown]
        public void Teardown()
        {
            AfterTest();
        }

            
    }
}