using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

[assembly: Parallelizable(ParallelScope.Fixtures)]
//namespace SeleniumwithDotNetCore.TestCases
//{

    [SetUpFixture]
    public  class SetUpClass
    {
        public  String  screenshot="\\Screenshots";
        public  String report = "\\Test_Execution_Reports";
        public  static ExtentReports extent;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");

            ClearDirectory(Directory.GetParent(dir).Parent.ToString()+ screenshot, "*.png");
            ClearDirectory(dir + report , "*.html");
            extent = new ExtentReports();
            DirectoryInfo di = Directory.CreateDirectory(dir + TestContext.CurrentContext.Test.ClassName);

            var htmlReporter = new ExtentHtmlReporter(dir+ TestContext.CurrentContext.Test.ClassName +".html");

            extent.AddSystemInfo("Environment", "Journey of Quality");

            extent.AddSystemInfo("User Name", "Sudhir");

            extent.AttachReporter(htmlReporter);
          
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            extent.Flush();
        }

        public static void ClearDirectory(string path,string extension)
        {
            Directory.EnumerateFiles(path, extension).ToList().ForEach(file => { File.Delete(file);});
        }

    }
//}
