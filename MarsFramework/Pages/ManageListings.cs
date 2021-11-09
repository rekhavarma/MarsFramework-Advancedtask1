using MarsFramework.Config;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
     class ManageListings : ShareSkill
    {


        [Obsolete]
        public ManageListings()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }
        #region  Initialize Web Elements 

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement ManageListingsLink { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement ClickActionsButton { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement Edit { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement View { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "/html//div[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i")]
        private IWebElement Delete { get; set; }

        // Click on Popup Yes button
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div[2]//div[@class='actions']/button[2]")]
        private IWebElement ClickYes { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[first()]/td[2]")]
        private IWebElement categoryType { get; set; }
        //Select the title
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[last()]/td[3]")]
        private IWebElement titleText { get; set; }
        //Select description
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]")]
        private IWebElement descriptionText { get; set; }
        //Select service type
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[first()]/td[5]")]
        private IWebElement serviceType { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service - detail - section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")]
        private IWebElement DescriptionText { get; set; }
        //Select service type
        [FindsBy(How = How.XPath, Using = "//*[@id='service - detail - section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]")]
        private IWebElement Header { get; set; }
        //Find Service Detail Page
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']")]
        private IWebElement ServiceDetailPage { get; set; }




        #endregion

        [Obsolete]
        public void ManageListing()
        {
            // navigate to ManageListings page
            ManageListingsLink.WaitForElementClickable(driver, 60);
            ManageListingsLink.Click();
            Base.wait(2);

            ClickActionsButton.WaitForElementClickable(driver, 60);
            ClickActionsButton.Click();

            Base.wait(2);

        }

        [Obsolete]
        public void EditshareSkill()
        {
            // navigate to ManageListings page
            // ManageListingsLink.WaitForElementClickable(driver, 60);
            ManageListingsLink.Click();
            Base.wait(2);
            Edit.WaitForElementClickable(driver, 60);
            Edit.Click();
            Base.wait(2);
           //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResource.ExcelPath, "ManageListings");
            
            #region Enter Title
            //Enter data in Title text box
            Base.wait(3);
            Title.Clear();
            Base.wait(2);
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            #endregion

            #region Enter Description
            Base.wait(2);
            //Enter data in Description text box
            Description.Clear();
            Base.wait(2);
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            #endregion

            #region Select Category 
            Base.wait(2);
            //click on category dropdown menu
            CategoryDropDown.Click();
            //Select Category from dropdown menu
            var selectElement = new SelectElement(CategoryDropDown);
            selectElement.SelectByText((GlobalDefinitions.ExcelLib.ReadData(2, "Category")));
            Base.wait(2);
            //click on subcategory dropdown menu
            SubCategoryDropDown.Click();
            //Select subCategory from dropdown menu
            var Selectelement = new SelectElement(SubCategoryDropDown);
            Selectelement.SelectByText((GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory")));
            #endregion

            #region Select Available days
            //select start date
            Base.wait(2);
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            //select end date
            Base.wait(2);
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            //select available days and start time and end time

            IList<IWebElement> Starttime = driver.FindElements(By.Name("StartTime"));

            IList<IWebElement> Endtime = driver.FindElements(By.Name("EndTime"));

            IList<IWebElement> Checkbox = driver.FindElements(By.XPath("(//input[@name='Available'])"));

            if (Checkbox.Count != 0)
            {
                //selecting checkboxs from monday to friday

                for (int i = 1; i <= Checkbox.Count - 2; i++)
                {
                    //verify whether checkbox is not selected

                    if (!Checkbox.ElementAt(i).Selected)
                    {
                        Checkbox.ElementAt(i).Click();
                    }
                    Console.WriteLine(driver);

                    //validating the count
                    Base.wait(2);

                    Starttime.ElementAt(i).SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Starttime"));

                    Thread.Sleep(2000);

                    Endtime.ElementAt(i).SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Endtime"));

                    Base.wait(2);
                }
            }

            #endregion

            #region Enter tags

            //click on tags
            Base.wait(2);
            Tags.Click();
            //Enter a tag
            Base.wait(2);
            Tags.SendKeys((GlobalDefinitions.ExcelLib.ReadData(2, "Tags")));
            Base.wait(2);
            Tags.SendKeys(Keys.Enter);
            Base.wait(2);
            #endregion

            #region select skill trade
            //select skilltrade
            Base.wait(4);
            String SkillTradeType = ((GlobalDefinitions.ExcelLib.ReadData(2, "SkillTradeType")));
            if (SkillTradeType.Equals("Skill-exchange"))
            {
                SkillExchangeType.Click();
            }
            else if (SkillTradeType.Equals("Credit"))
            {
                CreditsType.Click();
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CreditsAmount"));

            }
            //Add Credit Tag
            CreditsType.Click();
            CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CreditsAmount"));
            CreditAmount.SendKeys(Keys.Enter);

            #endregion

            #region
            Save.Click();
            Base.wait(1);
            #endregion
        }

        public void ValidateEditListing()
        {

            #region  Check if skill Updated successfully
            Base.wait(9);
            Thread.Sleep(3000);
            string actualPageTitle = Base.driver.Title;
            string expectedPageTitle = "ListingManagement";

            try
            {

                Thread.Sleep(3000);
                test = extent.StartTest("Edit Service Listing");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(LogStatus.Pass, "Test Passed, Service listing updated Successfully");
                    test.Log(LogStatus.Info, "Validating the edit Share Skill");
                    SaveScreenShotClass.SaveScreenshot(driver, "SkillsUpdatedSuccessfully");
                    Assert.Pass("Test Passed, Skills Updated");
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail("Test Failed, Skill not Updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        } 

        [Obsolete]
        public void ViewShareSkill()
        {
            // navigate to ManageListings page
            ManageListingsLink.WaitForElementClickable(driver, 60);
            ManageListingsLink.Click();

            //Identify and Click on View Button
            View.WaitForElementClickable(driver, 60);
            View.Click();
            Base.wait(3);  

        }

        public void ValidateViewListing()
        {
            #region  Check if skill created successfully
            Base.wait(2);
            
             string actualPageTitle = driver.Title;
             string expectedPageTitle = "Service Detail";
             Assert.AreEqual(actualPageTitle, "Service Detail");

             try
             {

                Base.wait(2);
                 test = extent.StartTest("View Service Listing");
                 if (expectedPageTitle == actualPageTitle)
                 {
                     test.Log(LogStatus.Pass, "Test Passed, Service listing Visible Successfully");
                     test.Log(LogStatus.Info, "Validating the View Share Skill");
                     SaveScreenShotClass.SaveScreenshot(driver, "SkillsViewedSuccessfully");
                     Assert.Pass("Test Passed, Skills Visible");
                 }
                 else
                 {
                     test.Log(LogStatus.Fail, "Test Failed");
                     Assert.Fail("Test Failed, Skill not Visible");
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
             #endregion
           
        }
        
            [Obsolete]
           public void DeleteShareSkill()
        {
            // navigate to ManageListings page
            ManageListingsLink.WaitForElementClickable(driver, 60);
            ManageListingsLink.Click();

            //Identify and click on delete button
            Delete.WaitForElementClickable(driver, 60);
            Delete.Click();
            Base.wait(2);
            // Switch to Popup button
            ClickYes.WaitForElementClickable(driver, 60);
            ClickYes.Click();
            Base.wait(2);
        }

        public void ValidateDeleteListing()

        {
             #region  Check if skill created successfully
             Thread.Sleep(3000);
             string actualPageTitle = driver.Title;
             string expectedPageTitle = "ListingManagement";
          
             try
             {
                 Thread.Sleep(1000);
                 test = extent.StartTest("Delete Service Listing");
                 if (expectedPageTitle == actualPageTitle)
                 {
                     test.Log(LogStatus.Pass, "Test Passed, Service listing Deleted Successfully");
                     test.Log(LogStatus.Info, "Validating the Delete Share Skill");
                     SaveScreenShotClass.SaveScreenshot(driver, "SkillsDeletedSuccessfully");
                     Assert.Pass("Test Passed, Skills Deleted");
                 }
                 else
                 {
                     test.Log(LogStatus.Fail, "Test Failed");
                     Assert.Fail("Test Failed, Skill not Deleted");
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
    

