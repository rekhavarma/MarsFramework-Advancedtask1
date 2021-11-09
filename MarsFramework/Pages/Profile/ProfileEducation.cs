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

namespace MarsFramework.Pages.Profile
{
    class ProfileEducation
    {
        [Obsolete]
        public ProfileEducation()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }

        #region  Initialize Web Elements 

        //Click on Educaiton Tab
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div//form//a[.='Education']")]
        private IWebElement EducationTab { get; set; }

        //Click on Add new to Educaiton
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[4]//table//div")]
        private IWebElement AddNewEducation { get; set; }

        //Enter university in the text box
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//input[@name='instituteName']")]
        private IWebElement EnterUniversity { get; set; }

        //Choose the country
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//select[@name='country']")]
        private IWebElement ChooseCountry { get; set; }

        //Choose the skill level option
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[2]/select/option[6]")]
        private IWebElement ChooseCountryOpt { get; set; }

        //Click on Title dropdown
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//select[@name='title']")]
        private IWebElement ChooseTitle { get; set; }

        //Choose title
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[1]/select/option[5]")]
        private IWebElement ChooseTitleOpt { get; set; }

        //Degree
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//input[@name='degree']")]
        private IWebElement Degree { get; set; }

        //Year of graduation
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//select[@name='yearOfGraduation']")]
        private IWebElement DegreeYear { get; set; }

        //Choose Year
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[3]/select/option[4]")]
        private IWebElement DegreeYearOpt { get; set; }

        //Click on Add
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//input[@value='Add']")]
        private IWebElement AddEdu { get; set; }


        #endregion


        public void AddEducation()
        {
            #region Add Education
            // Populate Login page test data collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileEducation");
            //click on Skill
            EducationTab.Click();
            Thread.Sleep(3000);

            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= 3; i++)
            {
                //Click on Add New button
                AddNewEducation.Click();
                Thread.Sleep(3000);
                //Enter the University
                EnterUniversity.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "University"));
                Thread.Sleep(3000);
                //Select the country.
                SelectElement selectcountry = new SelectElement(driver.FindElement(By.XPath("//select[@name='country']")));
                selectcountry.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(i + 1, "CountryOfCollege"));
                Thread.Sleep(3000);
                //Select the Title
                SelectElement selectTitle = new SelectElement(driver.FindElement(By.XPath("//select[@name='title']")));
                selectTitle.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Title"));
                Thread.Sleep(3000);
                //Select the Degree
                Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Degree"));
                Thread.Sleep(3000);
                //Select the YearOfPassing
                SelectElement selectYear = new SelectElement(driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
                selectYear.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(i + 1, "YearOfPassing"));
                Thread.Sleep(3000);
                //Click on Add
                AddEdu.Click();
                Thread.Sleep(3000);
            }
            #endregion

            #region Validate AddEducation
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileEducation");

            String ActualEducatn = driver.FindElement(By.XPath("//td[contains(text(),'B.Tech')]")).Text;
            String ActualUniversity = driver.FindElement(By.XPath("//td[contains(text(),'University of Queenstown')]")).Text;
            String ExpectedEducatn = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            String ExpectedUniversity = GlobalDefinitions.ExcelLib.ReadData(2, "University");


            String ActualEducatn1 = driver.FindElement(By.XPath("//td[contains(text(),'M.Tech')]")).Text;
            String ActualUniversity1 = driver.FindElement(By.XPath("//td[contains(text(),'University of Auckland')]")).Text;
            String ExpectedEducatn1 = GlobalDefinitions.ExcelLib.ReadData(3, "Title");
            String ExpectedUniversity1 = GlobalDefinitions.ExcelLib.ReadData(3, "University");
            

            String ActualEducatn2 = driver.FindElement(By.XPath("//td[contains(text(),'B.Sc')]")).Text;
            String ActualUniversity2 = driver.FindElement(By.XPath("//td[contains(text(),'Cambridge University')]")).Text;
            String ExpectedEducatn2 = GlobalDefinitions.ExcelLib.ReadData(4, "Title");
            String ExpectedUniversity2 = GlobalDefinitions.ExcelLib.ReadData(4, "University");

            try
            {
                Thread.Sleep(6000);
                test = extent.StartTest("Add Education");

                if (ActualEducatn == ExpectedEducatn && ActualUniversity == ExpectedUniversity && ActualEducatn1 == ExpectedEducatn1 && ActualUniversity1 == ExpectedUniversity1 && ActualEducatn2 == ExpectedEducatn2 && ActualUniversity2 == ExpectedUniversity2)
                {
                    Thread.Sleep(3000);
                    test.Log(LogStatus.Pass, "Test Passed, Education Added Successfully");
                    Assert.Pass("Test Passed, Education Added");
                    test.Log(LogStatus.Info, "Validating the Add Education");
                    Thread.Sleep(3000);
                    SaveScreenShotClass.SaveScreenshot(driver, "EducationAddedSuccessfully");

                }
                else
                {
                    Thread.Sleep(3000);
                    test.Log(LogStatus.Fail, "Test Failed, Education not Added");
                    Assert.Fail("Test Fail, Education not Added");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion


        }

        public void UpdateLanguage()
        {
            #region Update the given Education
            Thread.Sleep(3000);
            // Populate Login page test data collection  
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileEducation");
            String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            //Get the table list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Title
                String actualValue = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                //check if the editLanguage Parameter matches with ith row Title
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon
                    driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[1]/i")).Click();
                    //Send University name to update
                    IWebElement editRowValue = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    //Clear Previous text 
                    editRowValue.Clear();
                    editRowValue.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "UpdateUniversity"));
                    // update Country of College
                    SelectElement selectcountry = new SelectElement(driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[1]/div[2]/select")));
                    selectcountry.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(i + 1, "UpdateCountryOfCollege"));
                    // update Title
                    SelectElement Title = new SelectElement(driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[1]/select")));
                    Title.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(i + 1, "UpdateTitle"));
                    //update the Degree
                    IWebElement EditDegree = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[2]/input"));
                    // Clear Previous text
                    EditDegree.Clear();
                    EditDegree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "UpdateDegree"));
                    //update the Year of Passing.
                    SelectElement selectYear = new SelectElement(driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[3]/select")));
                    selectYear.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(i + 1, "UpdateYearOfPassing"));

                    // Click on update button
                    driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[3]/input[1]")).Click();
                    Thread.Sleep(5000);
                }
            }
            #endregion

           

            #region validate updated Education
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileEducation");
            String ActualEducation = driver.FindElement(By.XPath("//td[contains(text(),'M.B.A')]")).Text;
            String ActualUniversity = driver.FindElement(By.XPath("//td[contains(text(),'JNTU')]")).Text;
            String ExpectedEducation = GlobalDefinitions.ExcelLib.ReadData(2, "UpdateTitle");
            String ExpectedUniversity = GlobalDefinitions.ExcelLib.ReadData(2, "UpdateUniversity");
            try
            {
                Thread.Sleep(3000);
                test = extent.StartTest("Update Education");

                if (ActualEducation == ExpectedEducation && ActualUniversity == ExpectedUniversity)
                {
                    test.Log(LogStatus.Pass, "Test Passed, Education Updated Successfully");
                    Assert.Pass("Test Passed, Education Updated");
                    Thread.Sleep(3000);
                    test.Log(LogStatus.Info, "Validating the Update Education");
                    SaveScreenShotClass.SaveScreenshot(driver, "EducationUpdatedSuccessfully");
                   
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed, Education not Updated");
                    Assert.Fail("Test Fail, Education not Updated");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

        }


        public void DeleteEducation()
        {
            #region Delete given Education
            // Populate Login page test data collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileEducation");
            String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "DeleteUniversity");
            //Get the table row list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                Thread.Sleep(4000);

               
                //Get the xpath of ith row SkillName
                String actualValue = driver.FindElement(By.XPath("//div/div[2]/div/table/tbody[" + i + "]/tr/td[2]")).Text;
                
                ExtentionBase.WaitForWebElementToExist(driver, "//div/div[2]/div/table/tbody[" + i + "]/tr/td[2]", "XPath", 5);

                //check if the DeleteSkill parameter matches with ith Row SkillName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[2]/i")).Click();
                    Thread.Sleep(4000);
                    Base.wait(5);
                }
            }
            #endregion


            #region validate Delete Education
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileEducation");
            String ActualUniversity = driver.FindElement(By.XPath("//td[contains(text(),'JNTU')]")).Text;
            String ExpectedUniversity = GlobalDefinitions.ExcelLib.ReadData(2, "DeleteUniversity");
            try
            {
                Thread.Sleep(3000);
                test = extent.StartTest("Delete Education");

                if (ActualUniversity != ExpectedUniversity)
                {

                    test.Log(LogStatus.Fail, "Test Failed, Education not Deleted");
                    Assert.Fail("Test Fail, Education not Deleted");
                }
                else
                {
                    test.Log(LogStatus.Pass, "Test Passed, Education Delated Successfully");
                    test.Log(LogStatus.Info, "Validating the Delete Education");
                    Thread.Sleep(3000);
                    SaveScreenShotClass.SaveScreenshot(driver, "EducationDeletedSuccessfully");
                    Assert.Pass("Test Passed, Education Deleted");
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
