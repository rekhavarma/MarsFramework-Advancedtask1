using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using OpenQA.Selenium;
using MarsFramework.Global;
using System.Threading;
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    class ManageRequests
    {
        [Obsolete]
        public ManageRequests()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }

        #region  Initialize Web Elements 
        //Click on ManageRequestsTab
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']//section[@class='nav-secondary']/div/div[1]")]
        private IWebElement ManageRequestsTab { get; set; }
        //Click on RecievedRequestDropdown
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Received Requests']")]  
        private IWebElement RecievedRequestdrop { get; set; }
        //Click on ActiveButton
        [FindsBy(How = How.XPath, Using = "/html//div[@id='received-request-section']/div[2]//table/tbody/tr[1]/td[8]/button[1]")] 
        private IWebElement Acceptbutton { get; set; }
        //Click on Completebutton
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Complete']")]
        private IWebElement Completebutton { get; set; }
        //Click on Decline
        [FindsBy(How = How.XPath, Using = "/html//div[@id='received-request-section']/div[2]//table/tbody/tr[1]/td[8]/button[2]")]
        private IWebElement DeclineTab { get; set; }
        //Click on SentRequest
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Sent Requests']")]
        private IWebElement sentrequestTab { get; set; }
        //Click on completedtab
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Completed']")]
        private IWebElement Completedtab { get; set; }
        //Click on reviewTab
        [FindsBy(How = How.XPath, Using = "//tbody/tr[2]/td[8]/button[1]")]
        private IWebElement Reviewtab { get; set; }
        //Click on reviewMessage
        [FindsBy(How = How.XPath, Using = "/html//textarea[@id='reviewCommentInput']")]
        private IWebElement reviewtextbox { get; set; }
        //Click on savebutton
        [FindsBy(How = How.XPath, Using = "/html/body[@class='dimmable dimmed']/div[2]//div[@class='content']/div/div[4]/div")]
        private IWebElement savetab { get; set; }
        //Click on withdraw
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Withdraw']")]
        private IWebElement withdrawtab { get; set; }
        
        #endregion


        internal void RecievedRequests()
        {
            #region Recieved requests

            //Click on ManageRequests tab
            ManageRequestsTab.WaitForElementClickable(driver, 30);
            ManageRequestsTab.Click();
            Base.wait(3);
            //Click on Recieved Requests from dropdown menu
            RecievedRequestdrop.WaitForElementClickable(driver, 60);
            RecievedRequestdrop.Click();
            Base.wait(3);
            //Click on the Activebutton
            Acceptbutton.WaitForElementClickable(driver, 60);
            Acceptbutton.Click();
            Base.wait(4);
            //Click on the Complete Button
            Completebutton.WaitForElementClickable(driver, 60);
            Completebutton.Click();
            Base.wait(6);
            #endregion

          #region  Validating Recieved Request Page
            Base.wait(2);

            string actualPageTitle = driver.Title;
            string expectedPageTitle = "ReceivedRequest";
            Assert.AreEqual(actualPageTitle, "ReceivedRequest");

            try
            {

                Base.wait(2);
                test = extent.StartTest("View RecievedRequests");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(LogStatus.Pass, "Test Passed, RecievedRequests Visible Successfully");
                    test.Log(LogStatus.Info, "Validating the RecievedRequests");
                    SaveScreenShotClass.SaveScreenshot(driver, "RecievedRequestsViewedSuccessfully");
                    Assert.Pass("Test Passed, RecievedRequests Page Visible");
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail("Test Failed, RecievedRequestsPage not Visible");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Base.wait(5);
            #endregion

            #region Validate Recieved Requests 
            bool isPresent = Completebutton.Displayed;
            #endregion
            Base.wait(5);
        }
        internal void DeclineRequest()
        {
            #region Decline request
            //Click on ManageRequests tab
            ManageRequestsTab.WaitForElementClickable(driver, 30);
            ManageRequestsTab.Click();
            Thread.Sleep(3000);
            Base.wait(3);
            //Click on Recieved Requests from dropdown menu
            RecievedRequestdrop.WaitForElementClickable(driver, 60);
            RecievedRequestdrop.Click();
            Base.wait(2);
            //click on decline button
            DeclineTab.WaitForElementClickable(driver, 60);
            DeclineTab.Click();
            Base.wait(1);
            //Validate declinetab
            bool isNotPresent = DeclineTab.Enabled;
           #endregion

        }


        internal void SentRequests()
        {
            #region Send request to the seller
            //Click on ManageRequests tab
            ManageRequestsTab.WaitForElementClickable(driver, 30);
            ManageRequestsTab.Click();
            Thread.Sleep(3000);
            Base.wait(3);
            //Click on send requests from dropdown list
            sentrequestTab.WaitForElementClickable(driver, 60);
            sentrequestTab.Click();
            Base.wait(4);
            //Click on withdraw button
             withdrawtab.WaitForElementClickable(driver, 60);
             withdrawtab.Click();
            Base.wait(3);
            //Click on Completedtab
            Completedtab.WaitForElementClickable(driver, 60);
            Completedtab.Click();
            Base.wait(2);
            
            #endregion

            #region  Validating Sent Request Page
            Base.wait(2);

            string actualPageTitle = driver.Title;
            string expectedPageTitle = "SentRequest";
            Assert.AreEqual(actualPageTitle, "SentRequest");

            try
            {

                Base.wait(2);
                test = extent.StartTest("View SentRequests");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(LogStatus.Pass, "Test Passed, SentRequests Visible Successfully");
                    test.Log(LogStatus.Info, "Validating the SentRequests");
                    SaveScreenShotClass.SaveScreenshot(driver, "SentRequestsViewedSuccessfully");
                    Assert.Pass("Test Passed, SentRequests Page Visible");
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail("Test Failed, SentRequestsPage not Visible");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region Validate Sent Request
            //Validate Completedtab
            bool isPresent = Reviewtab.Displayed;

            #endregion
        }

        public void Review()
            {
            #region Reviewtab
            //Click on ManageRequests tab
            ManageRequestsTab.WaitForElementClickable(driver, 30);
            ManageRequestsTab.Click();
            Thread.Sleep(3000);
            Base.wait(3);
            //Click on send requests from dropdown list
            sentrequestTab.WaitForElementClickable(driver, 60);
            sentrequestTab.Click();
            Base.wait(4);
            //Click on Reviewtab
            Reviewtab.WaitForElementClickable(driver, 60);
            Reviewtab.Click();
            Base.wait(5);
            //Click on Reviewtextbox
            reviewtextbox.Click();
            reviewtextbox.SendKeys("You done an Increadible job");
            Base.wait(3);
            //Click on save tab
            savetab.Click();
            Base.wait(5);
            //Validate tab
            bool isPresent = Reviewtab.Displayed;
            #endregion
        }
        
    }
}
