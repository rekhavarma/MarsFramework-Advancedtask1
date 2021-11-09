using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Global
{
    public enum BrowserType
    {
        Firefox,
        Chrome
    }
    [TestFixture]
    public class Base
    {
        private BrowserType _BrowserType;
        public Base(BrowserType browser)
        {
            _BrowserType = browser;
        }
        // Initialize the browser
        public static IWebDriver driver { get; set; }
        #region WaitforElement 
        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }
        #endregion
        [Obsolete]
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
        }

        #region To access Path from resource file

        // public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string ReportXMLPath = MarsResource.ReportXMLPath;
        #endregion
       

       




        

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;

        #endregion

        #region setup and tear down
        [SetUp]
        [Obsolete]
        public void InititalizeTest()
        {
            ChooseBrowser(_BrowserType);

            void ChooseBrowser(BrowserType browserType)
            {
                if (browserType == BrowserType.Firefox)
                {
                    driver = new FirefoxDriver();
                }
                else if (browserType == BrowserType.Chrome)
                {
                    driver = new ChromeDriver();
                }

            }

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(ReportXMLPath);

            #endregion


            
            #region          
            // Maximize browser
            driver.Manage().Window.Maximize();
            // Navigate to Url
            driver.Navigate().GoToUrl(MarsResource.Url);
            #endregion

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps(driver);
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }

        }
       
        [TearDown]
        public void TearDown()
        {

            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                // Screenshot
                String img = SaveScreenShotClass.SaveScreenshot(driver, "Report");
                //test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));
                test.Log(LogStatus.Error, "Image example: " + test.AddScreenCapture(img));
            }
            else
            {
                // Screenshot
                String img = SaveScreenShotClass.SaveScreenshot(driver, "Report");
                //test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));
                test.Log(LogStatus.Pass, "Image example: " + test.AddScreenCapture(img));
            }
            //end test. (Reports)
            //extent.RemoveTest(test);
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :)            
            driver.Close();
            driver.Quit();
        }
        #endregion

    }
}