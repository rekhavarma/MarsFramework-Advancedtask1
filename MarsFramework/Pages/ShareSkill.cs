
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
using AutoIt;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
   public class ShareSkill 
    {
        public enum BrowserType
        {
            Firefox,
            Chrome,

        }


        [Obsolete]
        public ShareSkill()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        public IWebElement ShareSkillTab { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        public IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        public IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        public IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        public IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        public IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        public IWebElement ServiceTypeOptions { get; set; }
        //Select the Hourly Service Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        public IWebElement HourlyServiceType { get; set; }

        //Select On-Off Service Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        public IWebElement OneOffServiceType { get; set; }
        //Select On-Site Location Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        public IWebElement OnSiteLocationType { get; set; }

        //Select Online Location Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        public IWebElement OnlineLocationType { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        public IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        public IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        public IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        public IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        public IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        public IWebElement StartTimeDropDown { get; set; }

        //Click on end time
        [FindsBy(How = How.XPath, Using = "//div[5]//div[2]//div[1]//div[1]//div[1]//input[1]")]
        public IWebElement Endtime { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        public IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        public IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "/html//div[@id='service-listing-section']/div[2]/div[@class='listing']/form/div[8]/div[2]/div/div[1]/div/input[@name='skillTrades']")]
        public IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "/html//div[@id='service-listing-section']/div[2]/div[@class='listing']/form//label[.='Credit']")]
        public IWebElement Credit { get; set; }
        //Slelect the Skill Exchange Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        public IWebElement SkillExchangeType { get; set; }

        //Select the Credit Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        public IWebElement CreditsType { get; set; }

        //Enter Skill Exchange Tag
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        public IWebElement SkillExchangeTag { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='charge']")]
        public IWebElement CreditAmount { get; set; }

        // Enter Skill-Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        public IWebElement RequiredSkills { get; set; }

        // Upload work samples
        [FindsBy(How = How.XPath, Using = "/html//div[@id='service-listing-section']/div[2]//form//section//label[@class='worksamples-file']//i")]
        public IWebElement FileUpload { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        public IWebElement ActiveOption { get; set; }
        //Select Active Button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        public IWebElement ActiveButton { get; set; }

        //Select Hidden Button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        public IWebElement HiddenButton { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement Save { get; set; }

        //Click on camcel button
        [FindsBy(How = How.XPath, Using = "//html//div[@id='service-listing-section']//form//input[@value='Cancel']")]
        public IWebElement cancel { get; set; }


        public void AddShareSkill()
        {
            #region navigate to shareskill page
            //click on the shareskill page
            ShareSkillTab.WaitForElementClickable(driver, 60);
            ShareSkillTab.Click();
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResource.ExcelPath, "ShareSkill");
            #endregion

            #region Enter Title
            Base.wait(3);
            //Enter data in Title text box
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            #endregion

            #region Enter Description
            Base.wait(2);
            //Enter data in Description text box
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            #endregion

            #region Select Category 
            Base.wait(2);
            //click on category dropdown menu
            CategoryDropDown.Click();
            //Select Category from dropdown menu
            var selectElement = new SelectElement(CategoryDropDown);
            selectElement.SelectByText((GlobalDefinitions.ExcelLib.ReadData(2, "Category")));
            ShareSkillTab.WaitForElementClickable(Global.Base.driver, 60);
            //click on subcategory dropdown menu
            SubCategoryDropDown.Click();
            //Select subCategory from dropdown menu
            var Selectelement = new SelectElement(SubCategoryDropDown);
            Selectelement.SelectByText((GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory")));
            #endregion

            #region Enter tags
            Base.wait(2);
            //click on tags
            Tags.Click();
            //Enter a tag
            Tags.SendKeys((GlobalDefinitions.ExcelLib.ReadData(2, "Tags")));
            Tags.SendKeys(Keys.Enter);
            Base.wait(2);
            #endregion

            #region select service type
            Base.wait(2);
            //Select ServiceType 
            String ServiceType = ((GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType")));
            if (ServiceType.Equals("Hourly basis service"))
            {
                HourlyServiceType.Click();
            }
            else if (ServiceType.Equals("One-off service"))
            {
                OneOffServiceType.Click();
            }
            #endregion

            #region select Location Type
            Base.wait(2);
            //Select Location Type
            String LocationType = ((GlobalDefinitions.ExcelLib.ReadData(2, "LocationType")));
            if (LocationType.Equals("On-site"))
            {
                OnSiteLocationType.Click();
            }
            else if (LocationType.Equals("Online"))
            {
                OnlineLocationType.Click();
            }
            #endregion

            #region Select Available days
            //select start date
            Base.wait(2);
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            //select end date
            Base.wait(2);
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            //select available days and start time and end time

            IList<IWebElement> Starttime = Base.driver.FindElements(By.Name("StartTime"));

            IList<IWebElement> Endtime = Base.driver.FindElements(By.Name("EndTime"));

            IList<IWebElement> Checkbox = Base.driver.FindElements(By.XPath("(//input[@name='Available'])"));

            if (Checkbox.Count != 0)
            {
                //selecting checkboxs from monday to friday

                for (int i = 1; i <= Checkbox.Count - 2; i++)
                {
                    //verify whether checkbox is not selecte

                    if (!Checkbox.ElementAt(i).Selected)
                    {
                        Checkbox.ElementAt(i).Click();
                    }
                    Console.WriteLine(Base.driver);

                    //validating the count
                    Base.wait(2);

                    Starttime.ElementAt(i).SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Starttime"));

                    Thread.Sleep(2000);

                    Endtime.ElementAt(i).SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Endtime"));

                    Base.wait(2);
                }
            }

            #endregion

            #region select skill trade

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
            //Add Skill Exchange Tag
            SkillExchangeTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchangeTab"));
            SkillExchangeTag.SendKeys(Keys.Enter);



            #endregion

            #region Upload Work Sample

            //Upload file
            Base.wait(3);
            FileUpload.Click();
            Thread.Sleep(2000);
            //Activate Browser Window
            AutoItX.WinWaitActive("Open");
            Thread.Sleep(2000);
            //sets input focus to a given control on open window
            AutoItX.ControlFocus("Open", "", "Edit1");
            //sets text of a control
            AutoItX.ControlSetText("Open", "", "Edit1", @"C:\Users\Rekha\Desktop\MyGitHub\Standard_Task2-main\StandardTask2\Test.txt"); 
            Base.wait(4);
            AutoItX.ControlClick("Open", "", "Button1");
            Base.wait(4);

            #endregion

            #region select Active
            //Select Status
            Base.wait(2);
            String ActiveType = (GlobalDefinitions.ExcelLib.ReadData(2, "ActiveType"));
            if (ActiveType.Equals("Active"))
            {
                ActiveButton.Click();
            }
            else if (ActiveType.Equals("Hidden"))
            {
                HiddenButton.Click();
            }
            #endregion

            #region save Shareskill
            Save.Click();
            Base.wait(2);
            #endregion
        }
        public void ValidateCreateListing()
        {
            #region  Check if skill created successfully
            Thread.Sleep(3000);
            string actualPageTitle = Base.driver.Title;
            string expectedPageTitle = "ListingManagement";

            try
            {
                //Start the Reports

                Thread.Sleep(1000);
                test = extent.StartTest("Add a Service Listing");
                if (expectedPageTitle == actualPageTitle)
                {
                    test.Log(LogStatus.Pass, "Test Passed, Service listing added Successfully");
                    test.Log(LogStatus.Info, "Validating the Create Share Skill");
                    SaveScreenShotClass.SaveScreenshot(Base.driver, "SkillsAddedSuccessfully");
                    Assert.Pass("Test Passed, Skills saved");
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail("Test Failed, Skill not saved");
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






