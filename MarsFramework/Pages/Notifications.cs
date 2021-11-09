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
    class Notifications
    {
        [Obsolete]
        public Notifications()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }

        #region Initialize Web Elements

        //Click on Notifications dropdown
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div[2]/div/div")]
        private IWebElement Notificationsdropdown { get; set; }
        //Click on See all notifications
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='See All...']")]
        private IWebElement SeeAllNotificationsTab { get; set; }
        //Click on SelectallTab
        [FindsBy(How = How.XPath, Using = "//i[@class='mouse pointer icon']")]
        private IWebElement SelectAllTab { get; set; }
        //Click on Markallselectiontab
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Mark selection as read']")]
        private IWebElement MarkSelectionTab { get; set; }
        //Click on selectonecheck
        [FindsBy(How = How.XPath, Using = "//input[@value='0']")] 
        private IWebElement SelectoneCheck { get; set; }
        //Click on selectonothercheckbox
        [FindsBy(How = How.XPath, Using = "//input[@value='1']")]
        private IWebElement SelecttwoCheck { get; set; }
        //Click on clickonDeleteSelectiontab
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Delete selection']")]
        private IWebElement DeleteSelectionTab { get; set; }
        //Click on Unselect all
        [FindsBy(How = How.XPath, Using = "//i[@class='ban icon']")]
        private IWebElement UnSelectAllTab { get; set; }
        //Click on Popupmessage
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")]
        private IWebElement popUpMessageSelectionRead { get; set; }


        #endregion


        internal void SeeNotifications()
        {
            #region See all notifications
            //Click on the notifications dropdown list
            Notificationsdropdown.WaitForElementClickable(driver, 60);
            Notificationsdropdown.Click();
            Base.wait(3);
            Thread.Sleep(3000);
            //Click on SeeAll 
            SeeAllNotificationsTab.WaitForElementClickable(driver, 60);
            SeeAllNotificationsTab.Click();
            Base.wait(4);
            Thread.Sleep(3000);
            //Click on SelectAllTab
            SelectAllTab.WaitForElementClickable(driver, 60);
            SelectAllTab.Click();
            Base.wait(4);
            Thread.Sleep(3000);
            //Click on UnselectAllTab
            UnSelectAllTab.WaitForElementClickable(driver, 60);
            UnSelectAllTab.Click();
            Base.wait(3);
            Thread.Sleep(3000);
            //Click on more Checkbox
            SelectoneCheck.WaitForElementClickable(driver, 60);
            SelectoneCheck.Click();
            Base.wait(3);
            Thread.Sleep(3000);
            SelecttwoCheck.WaitForElementClickable(driver, 60);
            SelecttwoCheck.Click();
            Base.wait(3);
            Thread.Sleep(3000);
            //Click on MarkSelectionTab
            MarkSelectionTab.WaitForElementClickable(driver, 60);
            MarkSelectionTab.Click();
            Base.wait(4);
            Thread.Sleep(2000);
            //Validate MarkAsreach
            Thread.Sleep(3000);
            test = extent.StartTest("Update Notification");

            if (popUpMessageSelectionRead.Text == "Notification updated")
            {
                Thread.Sleep(3000);
                test.Log(LogStatus.Info, "Validating the Update Notification");
                SaveScreenShotClass.SaveScreenshot(driver, "NotificationUpdatedSuccessfully");
                test.Log(LogStatus.Pass, "Test Passed, Notification Updated Successfully");
                Assert.Pass("Notification record updated successfully!");
            }
            else
            {
                Thread.Sleep(3000);
                test.Log(LogStatus.Fail, "Test Failed, Notification not Updated ");
                Assert.Fail("Notification record not updated!");
            }
            #endregion
        }

        internal void DeleteNotification()
        {
            #region
            //Click on the notifications dropdown list
            Notificationsdropdown.WaitForElementClickable(driver, 60);
            Notificationsdropdown.Click();
            Base.wait(3);
            Thread.Sleep(3000);
            //Click on SeeAll 
            SeeAllNotificationsTab.WaitForElementClickable(driver, 60);
            SeeAllNotificationsTab.Click();
            Base.wait(4);
            Thread.Sleep(3000);
            //Click on Selectone checkbox
            SelectoneCheck.WaitForElementClickable(driver, 60);
            SelectoneCheck.Click();
            Base.wait(4);
            Thread.Sleep(3000);
            //Click on deletetab
            DeleteSelectionTab.WaitForElementClickable(driver, 60);
            DeleteSelectionTab.Click();
            Base.wait(3);
            Thread.Sleep(3000);
            //Validate MarkAsreach
            Thread.Sleep(3000);
            test = extent.StartTest("Delete Notification");
            if (popUpMessageSelectionRead.Text == "Notification updated")
            {
                Thread.Sleep(3000);
                test.Log(LogStatus.Info, "Validating the Delete Notification");
                SaveScreenShotClass.SaveScreenshot(driver, "NotificationDeletedSuccessfully");
                test.Log(LogStatus.Pass, "Test Passed, Notification Deleted Successfully");
                Assert.Pass("Notification record Deleted successfully!");
            }
            else
            {
                Thread.Sleep(3000);
                test.Log(LogStatus.Fail, "Test Failed, Notification not Deleted ");
                Assert.Fail("Notification record not Deleted!");
            }

            #endregion
        }
        
    }
}
