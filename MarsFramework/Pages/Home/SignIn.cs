using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports.Model;
using System;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    class SignIn 
    {
        [Obsolete]
        public SignIn()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }

        #region  Initialize Web Elements with pagefactory
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Sign In']")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps(IWebDriver Driver)
        {


            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResource.ExcelPath, "SignIn");
            
            Thread.Sleep(1000);
            
            SignIntab.Click();

            //Enter Email
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            LoginBtn.Click();
            Thread.Sleep(2000);
            if (Driver.WaitForElementDisplayed(By.XPath("//a[contains(text(),'Mars Logo')]"), 60))
            {
                test = extent.StartTest("Login Test");
                SaveScreenShotClass.SaveScreenshot(Driver, "Login");
                test.Log(LogStatus.Pass, "Login Successful");
            }
            else
            {
                test = extent.StartTest("Login Failed");
                SaveScreenShotClass.SaveScreenshot(Driver, "LoginFailed");
                test.Log(LogStatus.Fail, "Login failed");
            }

        }
    }
}