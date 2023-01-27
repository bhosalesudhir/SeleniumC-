using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using NUnit.Framework.Interfaces;
using NUnit.Framework;
using SeleniumwithDotNetCore.CommanUtils;

namespace SeleniumwithDotNetCore.TestCases
{
  
    public class BaseClass : CommanUtillity
    {
        public IWebDriver driver;
        public ExtentTest test;
        public String URL = "https://google.com/";//GetConfiguration("URL");

        
        public IWebDriver InitializeDriver()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddUserProfilePreference("download.default_directory", @"C:\temp\");
            option.AddUserProfilePreference("disable-popup-blocking", "true");
            option.AddArgument("--no-sandbox");
            //if (headless)
            //    option.AddArguments(new List<string>() { "headless" });

            driver = new ChromeDriver(option);
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Driver");
            //driver = new ChromeDriver(path, option,TimeSpan.FromSeconds(180));
            

            test = SetUpClass.extent.CreateTest(TestContext.CurrentContext.Test.Name,""); // provide info about current test
            return driver;
        }

        
        public void AfterTest()
        {
            try {
                var status = TestContext.CurrentContext.Result.Outcome.Status;

                var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace == null ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace));

                Status logStatus;

                switch (status)
                {
                    case TestStatus.Failed:
                        logStatus = Status.Fail;
                        DateTime time = DateTime.Now;
                        String fileName = TestContext.CurrentContext.Test.MethodName+"_"+ DateTime.Now.ToString("dd-MM-yyyy");
                        String screenShotPath = BaseClass.Capture(driver,fileName);
                        test.Log(Status.Error, GetType().Name +": :"+TestContext.CurrentContext.Test.Name+": :"+TestContext.CurrentContext.Result.Message);                     
                        break;
                    default:

                        logStatus = Status.Pass;

                        break; 

                }
                test.Log(logStatus, "Test Ended With :" + logStatus + stacktrace);
            }
            catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
            finally{
                //driver.Close();
                driver.Quit();
            }

          
        }


        private static string Capture(IWebDriver driver, string screenShotName)
        {

            ITakesScreenshot ss = (ITakesScreenshot)driver;

            Screenshot screenshot = ss.GetScreenshot();
            var pth = AppDomain.CurrentDomain.BaseDirectory;

            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            var reportPath = new Uri(actualPath).LocalPath;

            if (!Directory.Exists(reportPath + "\\Screenshots"))
                  Directory.CreateDirectory(reportPath + "\\Screenshots");

            var finalpth = reportPath + "Screenshots\\";
            var localpath = new Uri(finalpth).LocalPath;

            screenshot.SaveAsFile(localpath + screenShotName + ".png");

            return localpath;
            
        }

        
    }
}
