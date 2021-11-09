using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using MarsFramework.Global;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using NUnit.Framework;

namespace MarsFramework.Pages
{
    class ProfileSkills
    {
        [Obsolete]
        public ProfileSkills()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }

        #region  Initialize Web Elements 
        //Add Skill
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div//form//a[.='Skills']")]
        private IWebElement SkillsTab { get; set; }

        //Click on Add new to add new skill
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[3]//table//div[.='Add New']")]
        private IWebElement AddNewSkillBtn { get; set; }

        //Enter the Skill on text box
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[3]//input[@name='name']")]
        private IWebElement AddSkillText { get; set; }

        //Choose the skill level option
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[3]//select[@name='level']")]
        private IWebElement ChooseSkilllevel { get; set; }

        //Click on AddSkil
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[3]//input[@value='Add']")]
        private IWebElement AddSkill { get; set; }

        //Click on editskil
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[3]//table/tbody/tr/td[3]/span[1]/i")]
        private IWebElement Editskill { get; set; }

        //Click on AddSkil
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[3]//table//input[@value='Update']")]
        private IWebElement updateskill { get; set; }



        #endregion


        public void AddSkills()
        {

            #region Add New Skill

            // Populate Login page test data collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileSkills");
            //click on Skill
            SkillsTab.Click();
            Thread.Sleep(3000);


            for (int i = 1; i <= 3; i++)
            {
                //Click on Add New button
                AddNewSkillBtn.Click();
                Thread.Sleep(3000);
                //Enter the Skill
                AddSkillText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Skill"));
                //Select the Skill level.
                SelectElement select = new SelectElement(driver.FindElement(By.XPath("//select[@name ='level']")));
                select.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(i + 1, "SkillLevel"));
                //Click on Add
                AddSkill.Click();
                Thread.Sleep(4000);
            }
            #endregion

            #region Validate the Skill is added sucessfully 
            try
            {
                //Start the Reports
                test = extent.StartTest("Add Skill");
                test.Log(LogStatus.Info, "Adding Skill");
                String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Skill");
                //Get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var rowCount = Tablerows.Count;
                for (var i = 1; i < rowCount; i++)
                {
                    Thread.Sleep(3000);
                    string actualValue = driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        test.Log(LogStatus.Pass, "Skill added Successful");
                        SaveScreenShotClass.SaveScreenshot(driver, "AddSkill");
                        Assert.IsTrue(true);
                        Assert.Pass("Test Passed, Skills Added Successfully");
                    }
                    else
                        test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail("Test Failed, Skills doesnt Exists");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion

        }


        public void UpdateSkills()
        {
            #region Update the given Skills
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileSkills");
            //click on Skill
            Editskill.WaitForElementClickable(driver, 60);
            Editskill.Click();
            Thread.Sleep(3000);
            // Enter Add skill
            AddSkillText.Clear();
            AddSkillText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "UpdateSkill"));
            // Enter Skill level
            Thread.Sleep(3000);
            SelectElement skilllevel = new SelectElement(driver.FindElement(By.XPath("//select[@name='level']")));
            skilllevel.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(2, "UpdateSkillLevel"));
            updateskill.WaitForElementClickable(driver, 60);
            updateskill.Click();
            Thread.Sleep(4000);
            #endregion

            #region validate updated Skill
            Thread.Sleep(3000);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileSkills");
            String Actualskill = driver.FindElement(By.XPath("//td[contains(text(),'Jmeter')]")).Text;
            String Expectedskill = GlobalDefinitions.ExcelLib.ReadData(2, "UpdateSkill");


            try
            {
                Thread.Sleep(3000);
                test = extent.StartTest("Update Skill");

                if (Actualskill == Expectedskill)
                {

                    test.Log(LogStatus.Info, "Validating the Update Skill");
                    Thread.Sleep(3000);
                    SaveScreenShotClass.SaveScreenshot(driver, "SkillUpdatedSuccessfully");
                    test.Log(LogStatus.Pass, "Test Passed, skill Updated Successfully");
                    Assert.Pass("Test Passed, Skill Updated");
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed, Skill not Updated ");
                    Assert.Fail("Test Fail, skill not Updated");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(4000);
            #endregion

        }

        public void DeleteSkill()
        {
            #region Delete given Skill
            // Populate Login page test data collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileSkills");
            Thread.Sleep(3000);
            String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "DeleteSkill");
            //Get the table row list
            Thread.Sleep(3000);
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                Thread.Sleep(5000);
                String actualValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the DeleteSkill parameter matches with ith Row SkillName
                Thread.Sleep(3000);
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();
                    Thread.Sleep(7000);
                }
            }
            #endregion
        }    

            public void ValidateDeleteSkills()
            {
              #region Valdidate deleted Skill
                try
                {
                    //Start the Reports
                    test = extent.StartTest("Delete Skill");
                    test.Log(LogStatus.Info, "Deleting Skill");
                    String expectedValue1 = GlobalDefinitions.ExcelLib.ReadData(2, "DeleteSkill");
                    //Get the table list
                    IList<IWebElement> Tablerows1 = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
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
                            Thread.Sleep(3000);
                            test.Log(LogStatus.Pass, "Skill deleted Successful");
                            test.Log(LogStatus.Info, "Validating Delete Skills");
                            SaveScreenShotClass.SaveScreenshot(driver, "DeleteSkill");
                            Thread.Sleep(3000);
                            Assert.Pass("Test Passed, Skill deleted Successfully");
                        }
                        else
                            test.Log(LogStatus.Fail, "Test Failed");
                            Thread.Sleep(3000);
                            Assert.Fail("Test Failed, Skill not deleted");
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



