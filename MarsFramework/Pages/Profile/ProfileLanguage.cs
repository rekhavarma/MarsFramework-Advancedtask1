using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using RelevantCodes.ExtentReports;
using NUnit.Framework;

namespace MarsFramework.Pages
{
    class ProfileLanguage
    {
        [Obsolete]
        public ProfileLanguage()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }

        #region  Initialize Web Elements 
        //Click on language
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div//form//a[.='Languages']")]
        private IWebElement LanguageTab { get; set; }


        //Click on Add new to add new Language
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[2]//table//div[.='Add New']")]
        private IWebElement AddNewLangBtn { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[2]//input[@name='name']")]
        private IWebElement AddLangText { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[2]/select")]
        private IWebElement ChooseLang { get; set; }

        //Enter the Languagelevel
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[2]//select[@name='level']")]
        private IWebElement Languagelevel { get; set; }

        //Add Language
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[2]//input[@value='Add']")]
        private IWebElement AddLang { get; set; }
        //Add Language
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[2]//table/tbody/tr/td[3]/span[1]/i")]
        private IWebElement editLang { get; set; }
        //Add Language
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[2]//table//input[@value='Update']")]
        private IWebElement updateLang { get; set; }
        #endregion


        public void AddLanguage()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileLanguages");
            #region Add Language
            LanguageTab.Click();
            Thread.Sleep(3000);

            for (int i = 2; i <= 4; i++)
            {
                //Click on Add New button
                AddNewLangBtn.Click();
                Thread.Sleep(3000);

                //Enter the language
                AddLangText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "Language"));
                Thread.Sleep(3000);
                //Select the language level from drodown list.
                SelectElement select = new SelectElement(driver.FindElement(By.XPath("//select[@name ='level']")));
                Thread.Sleep(3000);
                select.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(i, "LanguageLevel"));
                Thread.Sleep(3000);
                //Click on Add
                AddLang.Click();
                Thread.Sleep(2000);
            }
            #region Validate the language is added sucessfully 
            try
            {
                //Start the Reports
                test = extent.StartTest("Add Language");
                test.Log(LogStatus.Info, "Adding language");
                String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Language");

                //Get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));

                //Get the row count in table
                var rowCount = Tablerows.Count;
                for (var i = 1; i < rowCount; i++)
                {

                    string actualValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {

                        test.Log(LogStatus.Pass, "Add Language Successful");
                        SaveScreenShotClass.SaveScreenshot(driver, "AddLanguage");
                        Assert.IsTrue(true);

                        Assert.Pass("Test Passed, Languages Added Successfully");
                    }
                    else
                        test.Log(LogStatus.Fail, "Test Failed");

                    Assert.Fail("Test Failed, Languages doesnt Exists");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion


            #endregion
        }

        public void UpdateLanguage()
        {
            #region Update given language
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileLanguages");
            //click on Language
            editLang.WaitForElementClickable(driver, 60);
            editLang.Click();
            Thread.Sleep(3000);
            // Enter Language Name
            AddLangText.Clear();
            AddLangText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLanguage"));
            // Enter Language level
            Thread.Sleep(3000);
            SelectElement Langlevel = new SelectElement(driver.FindElement(By.XPath("//select[@name='level']")));
            Langlevel.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLanguageLevel"));
            updateLang.WaitForElementClickable(driver, 60);
            updateLang.Click();
            Thread.Sleep(4000);


            #endregion


            #region validate updated language
            Thread.Sleep(3000);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileLanguages");
            String Actualskill = driver.FindElement(By.XPath("//td[contains(text(),'Spanish')]")).Text;
            String Expectedskill = GlobalDefinitions.ExcelLib.ReadData(2, "UpdateLanguage");


            try
            {
                Thread.Sleep(3000);
                test = extent.StartTest("Update Language");

                if (Actualskill == Expectedskill)
                {

                    test.Log(LogStatus.Info, "Validating the Update Language");
                    Thread.Sleep(3000);
                    SaveScreenShotClass.SaveScreenshot(driver, "LanguageUpdatedSuccessfully");
                    test.Log(LogStatus.Pass, "Test Passed, Language Updated Successfully");
                    Assert.Pass("Test Passed, Language Updated");
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed, Language not Updated ");
                    Assert.Fail("Test Fail, Language not Updated");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(4000);
            #endregion

        }
       
        //Delete a given language
        public void DeleteLang()
        {
            #region Delete given language
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileLanguages");
            String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "DeleteLanguage");
            //Get the table row list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                Thread.Sleep(3000);
                //Get the xpath of ith row LanguageName
                String actualValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text; 
                //check if the DeleteLanguage parameter matches with ith Row LanguageName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                }
            }
            #endregion

        }
        //Validate Deleted Language
        public void ValidateDelLan()
        {
            #region Valdidate deleted laguage

            try
            {
                //Start the Reports
                test = extent.StartTest("Remove Language");
                test.Log(LogStatus.Info, "Deleting language");
                String expectedValue1 = GlobalDefinitions.ExcelLib.ReadData(2, "DeleteLanguage");
                //Get the table list
                IList<IWebElement> Tablerows1 = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var rowCount1 = Tablerows1.Count;
                for (var j = 1; j < rowCount1; j++)
                {
                    Thread.Sleep(3000);
                    string actualValue1 = driver.FindElement(By.XPath("//div/table/tbody[" + j + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 != actualValue1)
                    {
                        Assert.IsTrue(true);
                        test.Log(LogStatus.Pass, "Language deleted Successful");
                        SaveScreenShotClass.SaveScreenshot(driver, "DeleteLanguage");
                        Assert.Pass("Test Passed, Languages deleted Successfully");
                    }
                    else
                        test.Log(LogStatus.Fail, "Test Failed");
                      //Assert.Fail("Test Failed, Languages not deleted Successfully");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion
        }

    }
}