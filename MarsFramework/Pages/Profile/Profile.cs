using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace MarsFramework
{
    internal class Profile
    {

        [Obsolete]
        public Profile()
        {

            PageFactory.InitElements(Global.Base.driver, this);
        }

        #region  Initialize Web Elements 


        //Click on Edit button
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[2]/div/div[@class='content']//div[@class='column']/div/div[3]/div/div[2]/div/span/i")]
        private IWebElement AvailabilityTimeEdit { get; set; }

        //Click on Availability Time dropdown
        [FindsBy(How = How.Name, Using = "//select[@name='availabiltyType']")]
        private IWebElement AvailabilityTime { get; set; }

        //Click on Availability Time option
        [FindsBy(How = How.XPath, Using = "//option[@value='1']")]
        private IWebElement AvailabilityTimeOpt { get; set; }

        //Click on Availability Hour dropdown
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[2]/div/div[@class='content']//div[@class='column']/div/div[3]/div/div[3]/div/span/i")]
        private IWebElement AvailabilityHours { get; set; }

        //Click on Earn Target
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[2]/div/div[@class='content']//div[@class='column']/div/div[3]/div/div[4]/div/span/i")]
        private IWebElement EarnTarget { get; set; }

        //Click on Description
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//span[@class='button']/i")]
        private IWebElement Description { get; set; }
        //Enter Description 
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[3]/div/div[@class='content']/form//textarea[@name='value']")]
        private IWebElement DescriptionTxtBox { get; set; }
        //Save Description 
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[3]/div/div[@class='content']/form//button[@type='button']")]
        private IWebElement DescriptionSave { get; set; }
        //Click on Welcome Tab Button
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement WelcomeTab { get; set; }

        //Click on Change Password dropdown
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/div[1]/div[2]/div/span/div[@class='menu transition visible']/a[.='Change Password']")]
        private IWebElement ChangPassDropdow { get; set; }

        //Click on Current Password
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div[4]//form//input[@name='oldPassword']")]
        private IWebElement CurrPass { get; set; }
        //Click on Current Password
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div[4]//form//input[@name='newPassword']")]
        private IWebElement NewPass { get; set; }
        //Click on Current Password
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div[4]//form//input[@name='confirmPassword']")]
        private IWebElement ConfirmPass { get; set; }
        //Click on Current Password
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div[4]//form//button[@role='button']")]
        private IWebElement SaveButton { get; set; }
        //Click on Chat
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Chat']")]
        private IWebElement Chaticon { get; set; }
        //Click on Chatsearch
        [FindsBy(How = How.XPath, Using = "/html//div[@id='chatRoomContainer']/div[@class='chatRoom']//input[@class='prompt']")]
        private IWebElement ChatSearch { get; set; }
        //Click on Chatname
        [FindsBy(How = How.XPath, Using = "/html//div[@id='chatList']/div[1]/div[@class='content']/div[@class='header']")]
        private IWebElement Chatname { get; set; }
        //Click on Chattextbox
        [FindsBy(How = How.XPath, Using = "/html//input[@id='chatTextBox']")]
        private IWebElement Chattextbox { get; set; }
        //Click on Chattextbox
        [FindsBy(How = How.XPath, Using = "/html//button[@id='btnSend']")]
        private IWebElement chatsendtab { get; set; }




        #endregion

        internal void EditProfile()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            Base.wait(3);
            #region Select Availability from dropdown
            //Click on Edit button
            AvailabilityTimeEdit.WaitForElementClickable(driver, 60);
            AvailabilityTimeEdit.Click();
            //Availability Time option
            Thread.Sleep(1500);
            var Worktype = driver.FindElement(By.Name("availabiltyType"));
            var selectElementh = new SelectElement(Worktype);
            selectElementh.SelectByValue("1");
            Thread.Sleep(5000);
            #endregion

            #region select hours from dropdown list
            AvailabilityHours.WaitForElementClickable(driver, 60);
            AvailabilityHours.Click();
            var Workhour = driver.FindElement(By.Name("availabiltyHour"));
            var selectElement = new SelectElement(Workhour);
            selectElement.SelectByValue("0");
            Thread.Sleep(5000);
            #endregion

            #region select earntarget from dropdown
            EarnTarget.WaitForElementClickable(driver, 60);
            EarnTarget.Click();
            var Target = driver.FindElement(By.Name("availabiltyTarget"));
            var selectElementt = new SelectElement(Target);
            selectElementt.SelectByValue("0");
            Thread.Sleep(5000);
            #endregion

            #region Enter description 
            Description.WaitForElementClickable(driver, 60);
            Description.Click();
            Base.wait(3);
            Thread.Sleep(2000);
            DescriptionTxtBox.WaitForElementClickable(driver, 60);
            DescriptionTxtBox.SendKeys(Keys.Control + "a");
            DescriptionTxtBox.SendKeys(Keys.Delete);
            Base.wait(3);
            Thread.Sleep(2000);
            DescriptionTxtBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Base.wait(3);
            Thread.Sleep(2000);
            DescriptionSave.WaitForElementClickable(driver, 60);
            DescriptionSave.Click();
            Thread.Sleep(3000);

            #endregion


        }


       internal void ChangePassword()
        {
            #region Change Password
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            Thread.Sleep(1000);
            //click on dropdown
            Thread.Sleep(2000);
            WelcomeTab.WaitForElementClickable(driver, 60);
            WelcomeTab.Click();
            //select change password from dropdown
            Thread.Sleep(2000);
            Base.wait(3);
            ChangPassDropdow.WaitForElementClickable(driver, 60);
            ChangPassDropdow.Click();
            //click on Current Password
            Base.wait(3);
            CurrPass.WaitForElementClickable(driver, 60);
            CurrPass.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CurrentPassword"));
            //click on New Password
            Base.wait(3);
            NewPass.WaitForElementClickable(driver, 60);
            NewPass.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"));
            //Click On ConfirmPassword
            Base.wait(3);
            ConfirmPass.WaitForElementClickable(driver, 60);
            ConfirmPass.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPassword")); 
            //click on save button
            Thread.Sleep(2000);
            SaveButton.Click();
            #endregion
        }

        internal void Chat()
        {
            #region Chat
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            Thread.Sleep(1000);
            //click on Chaticon
            Chaticon.WaitForElementClickable(driver, 60);
            Chaticon.Click();
            Base.wait(3);
            //Click on Search
            ChatSearch.Click();
            ChatSearch.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ChatSearch"));
            Base.wait(3);
            Thread.Sleep(2000);
            //Click on ChatName
            Chatname.WaitForElementClickable(driver, 60);
            Chatname.Click();
            Thread.Sleep(2000);
            Base.wait(3);
            //Click on Chat Text Box
            Chattextbox.Click();
            Chattextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ChatTextBox"));
            Base.wait(3);
            Thread.Sleep(2000);
            //Click On Send Button
            chatsendtab.WaitForElementClickable(driver, 60);
            chatsendtab.Click();
            Thread.Sleep(6000);
            #endregion

            #region Validate Chat
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            String ActualChat= driver.FindElement(By.XPath("//span[normalize-space()='Hi, My Name is rekha']")).Text;
            Base.wait(3);
            Thread.Sleep(2000);
            String ExpectedChat = GlobalDefinitions.ExcelLib.ReadData(2, "ChatTextBox");
            try
            {
                Thread.Sleep(3000);
                test = extent.StartTest("Chat");

                if (ActualChat == ExpectedChat)
                {
                    test.Log(LogStatus.Pass, "Test Passed, Message Visible");
                    test.Log(LogStatus.Info, "Validating the Chat");
                    SaveScreenShotClass.SaveScreenshot(driver, "Chat Visible");
                    Assert.Pass("Test Passed, Chat Visible");
                    
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed, Chat not Visible");
                    Assert.Fail("Test Fail, Chat not Visible");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
        }
    }
}
    
