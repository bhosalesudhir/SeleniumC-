

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumwithDotNetCore.PageObject;


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
            try
            {
                _testpo.NavigatetoURL(URL);
                IList<IWebElement> it = _driver.FindElements(By.Id("google"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail("Exception : :" + e + ": : Retry :" + GetType().Name + ": :" + TestContext.CurrentContext.Test.Name);
            }
        }
        [Test]
        public void NavigateToGoogleTolocateID()
        {
            try
            {
                _testpo.NavigatetoURL(URL);
                _driver.FindElement(By.Id("Seach"));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Assert.Fail("Exception : :" + e + ": : Retry :" + GetType().Name + ": :" + TestContext.CurrentContext.Test.Name);
            }
        }
        [Test]
        public void NavigateToGooglePageAndSearch()
        {

            try
            {
                _testpo.NavigatetoURL(URL)
                   .SearchText("Java");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Assert.Fail("Exception : :" + e + ": : Retry :" + GetType().Name + ": :" + TestContext.CurrentContext.Test.Name);
            }
        }
        [Test]
        public void NavigateToGooglePage4()
        {

            try
            {
                _testpo.NavigatetoURL(URL);
                _driver.FindElement(By.Id("google"));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Assert.Fail("Exception : :" + e + ": : Retry :" + GetType().Name + ": :" + TestContext.CurrentContext.Test.Name);
            }
        }
        [Test]
        public void NavigateToGoogleTolocateID5()
        {

            try
            {
                _testpo.NavigatetoURL(URL);
                _driver.FindElement(By.Id("Seach"));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Assert.Fail("Exception : :" + e + ": : Retry :" + GetType().Name + ": :" + TestContext.CurrentContext.Test.Name);
            }
        }
        [Test]
        public void NavigateToGooglePageAndSearch6()
        {

            try
            {
                _testpo.NavigatetoURL(URL)
                 .SearchText("Java");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Assert.Fail("Exception : :" + e + ": : Retry :" + GetType().Name + ": :" + TestContext.CurrentContext.Test.Name);
            }
        }
        [TearDown]
        public void Teardown()
        {
            AfterTest();
        }


    }
}