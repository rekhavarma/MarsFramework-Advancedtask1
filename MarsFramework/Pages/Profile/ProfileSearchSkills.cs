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
using RelevantCodes.ExtentReports;
using NUnit.Framework;

namespace MarsFramework.Pages.Profile
{
    class ProfileSearchSkills
    {
        [Obsolete]
        public ProfileSearchSkills()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }

        #region  Initialize Web Elements 
        //Click on SearchTextBox
        [FindsBy(How = How.XPath, Using = "//div[@class='ui secondary menu']//input[@placeholder='Search skills']")]
        private IWebElement Searchtextbox { get; set; }
        //Click on refine search skills
        [FindsBy(How = How.XPath, Using = "/html//div[@id='service-search-section']/div[2]//section[@class='search-results']/div/div[1]/div[2]/input[@type='text']")]
        private IWebElement RefineSreachskills { get; set; }
        //click on refine search user textbox
        [FindsBy(How = How.XPath, Using = "/html//div[@id='service-search-section']/div[2]//section[@class='search-results']/div/div[1]/div[3]/div[1]/div//input")]
        private IWebElement RefineSearchUser { get; set; } 

        #endregion

        internal void SearchSkills()
        {
            #region
            // Populate Login page test data collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            //Click on Searchskills textbox
            Thread.Sleep(3000);
            Searchtextbox.WaitForElementClickable(driver, 60);
            Searchtextbox.Click();
            Searchtextbox.WaitForElementClickable(driver, 60);
            Searchtextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Searchskills"));
            Searchtextbox.WaitForElementClickable(driver, 60);
            Searchtextbox.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            //Validate Search Skills
            Base.wait(9);
            Thread.Sleep(3000);
            string actualPageTitle = Base.driver.Title;
            string expectedPageTitle = "Search";

            try
            {

                Thread.Sleep(3000);
                test = extent.StartTest("SearchSkills");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(LogStatus.Pass, "Test Passed, SearchSkills Page Visible");
                    test.Log(LogStatus.Info, "Validating the Searchskills Page");
                    SaveScreenShotClass.SaveScreenshot(driver, "SearchskillsPageVisible");
                    Assert.Pass("Test Passed, SearchSkills Page Visible");
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail("Test Failed, SearchSkills Page doesn't Exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(5000);
            #endregion
        }
          internal void RefineSearchSkills()
          { 
            #region Search Refine Skills
            // Populate Login page test data collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            //Click on Searchskills textbox
            Thread.Sleep(3000);
            Searchtextbox.WaitForElementClickable(driver, 60);
            Searchtextbox.Click();
            Searchtextbox.WaitForElementClickable(driver, 60);
            Searchtextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Searchskills"));
            Searchtextbox.WaitForElementClickable(driver, 60);
            Searchtextbox.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            //Click on Refine Search Skills
            RefineSreachskills.WaitForElementClickable(driver, 60);
            RefineSreachskills.Click();
            Thread.Sleep(2000);
            RefineSreachskills.WaitForElementClickable(driver, 60);
            RefineSreachskills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Refineskills"));
            Thread.Sleep(2000);
            Searchtextbox.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            //Click on Refine User
            RefineSearchUser.Click();
            Thread.Sleep(2000);
            RefineSearchUser.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "RefineSearchUser"));
            Thread.Sleep(2000);
            RefineSearchUser.SendKeys(Keys.ArrowDown + Keys.Enter);
            Thread.Sleep(6000);
            //Validate TefineSearchSkills

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            Thread.Sleep(3000);
            String ActualUser = driver.FindElement(By.LinkText("rekha p")).Text;
            String ActualSkill = driver.FindElement(By.LinkText("Automating")).Text;
            Thread.Sleep(3000);
            String ExpectedUser = GlobalDefinitions.ExcelLib.ReadData(2, "RefineSearchUser");
            String ExpectedSkill = GlobalDefinitions.ExcelLib.ReadData(2, "Searchskills");
            Thread.Sleep(5000);

            try
            {
                Thread.Sleep(3000);
                test = extent.StartTest("SearchSkills");

                if (ActualUser == ExpectedUser && ActualSkill == ExpectedSkill)
                {
                    Thread.Sleep(3000);
                    test.Log(LogStatus.Info, "Validating the SearchSkills");
                    SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");
                    test.Log(LogStatus.Pass, "Test Passed, SearchSkills Visible");
                    Assert.Pass("Test Passed, SearchSkills Visible");
                }
                else
                {
                    Thread.Sleep(3000);
                    test.Log(LogStatus.Fail, "Test Failed, SearchSkills doesn't Exists ");
                    Assert.Fail("Test Fail, SearchSkills doesn't Exists");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
            Thread.Sleep(5000);
        }

        internal void RefineFilterSearchSkills()
        {
            #region Filter Search Skills
            // Populate Profile page test data collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Search skills using filter
            string value1 = GlobalDefinitions.ExcelLib.ReadData(2, "FilterButtons");
            string value2 = GlobalDefinitions.ExcelLib.ReadData(3, "FilterButtons");
            string value3 = GlobalDefinitions.ExcelLib.ReadData(4, "FilterButtons");
            // Click on button
            string Button = driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]")).Text;


            Thread.Sleep(3000);

            for (int i = 1; i <= 3; i++)
            {
                // Click on ith button
                string actualvalue = driver.FindElement(By.XPath("//div/section/div/div[1]/div[5]/button[" + i + "]")).Text;
                if (actualvalue == value1)
                {
                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("//button[normalize-space()='Online']")).Click();
                    Console.WriteLine("Test Passed for Online Filter");
                    Thread.Sleep(2000);
                }
                else if (actualvalue == value2)
                {
                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("//button[normalize-space()='Onsite']")).Click();
                    Console.WriteLine("Test Passed for Onsite Filter");
                    Thread.Sleep(2000);
                }
                else if (actualvalue == value3)
                {
                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("//button[normalize-space()='ShowAll']")).Click();
                    Console.WriteLine("Test Passed for ShowAll Filter");
                    Thread.Sleep(2000);
                }
            }

            #endregion
        }

    }
}
