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
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages.Profile
{
    class ProfileCertification
    {
        [Obsolete]
        public ProfileCertification()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }
        #region  Initialize Web Elements 
        //Click on CertificateTab
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div//form//a[.='Certifications']")]
        private IWebElement CertificateTab { get; set; }
        //Add new Certificate
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[5]//table//div[.='Add New']")]
        private IWebElement AddNewCerti { get; set; }

        //Enter Certification Name
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//input[@name='certificationName']")]
        private IWebElement EnterCerti { get; set; }

        //Certified from
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//input[@name='certificationFrom']")]
        private IWebElement CertiFrom { get; set; }

        //Year
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//select[@name='certificationYear']")]
        private IWebElement CertiYear { get; set; }

        //Choose Opt from Year
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[2]/select/option[5]")]
        private IWebElement CertiYearOpt { get; set; }

        //Add Ceritification
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[5]//input[@value='Add']")]
        private IWebElement AddCerti { get; set; }

        //Edit Certificate
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//table/tbody/tr/td[4]/span[1]/i")]
        private IWebElement EditCerti { get; set; }

        //Edit Certificate
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//table//input[@value='Update']")]
        private IWebElement UpdateCerti { get; set; }

        //Delete Ceritification
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//table/tbody[1]/tr/td[4]/span[2]/i")]
        private IWebElement DeleteCerti { get; set; }


        #endregion

        public void AddCertificate()
        {
            #region Add Certificate

            // Populate Login page test data collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileCertificate");

            CertificateTab.WaitForElementClickable(driver, 60);
            CertificateTab.Click();


            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            var rowCount = Tablerows.Count;

            for (int i = 1; i <= 3; i++)
            {
                //Click on Add New button
                AddNewCerti.WaitForElementClickable(driver, 60);
                AddNewCerti.Click();
                Thread.Sleep(3000);
                // Enter Certificate Name
                EnterCerti.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Certificate"));
                // Enter Certified from
                Thread.Sleep(3000);
                CertiFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "CertifiedFrom"));
                // Select Year
                Thread.Sleep(3000);
                SelectElement year = new SelectElement(driver.FindElement(By.XPath("//select[@name ='certificationYear']")));
                year.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Year"));
                AddCerti.Click();
            }

            #endregion

            #region

            Thread.Sleep(3000);
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileCertificate");
                String ActualCert = driver.FindElement(By.XPath("//td[contains(text(),'ISTQB')]")).Text;
                String ExpectedCert = GlobalDefinitions.ExcelLib.ReadData(2, "Certificate");
                Thread.Sleep(3000);
                String ActualCert1 = driver.FindElement(By.XPath("//td[contains(text(),'TestAnalyst')]")).Text;
                String ExpectedCert1 = GlobalDefinitions.ExcelLib.ReadData(3, "Certificate");

                Thread.Sleep(3000);
                String ActualCert2 = driver.FindElement(By.XPath("//td[contains(text(),'ScrumMaster')]")).Text;
                String ExpectedCert2 = GlobalDefinitions.ExcelLib.ReadData(4, "Certificate");
               

                try
                {
                    Thread.Sleep(3000);
                    test = extent.StartTest("Add Certificate");

                    if (ActualCert == ExpectedCert && ActualCert1 == ExpectedCert1 && ActualCert2 == ExpectedCert2)
                    {
                     
                        test.Log(LogStatus.Info, "Validating the Add Certificate");
                        Thread.Sleep(3000);
                        SaveScreenShotClass.SaveScreenshot(driver, "CertificateAddedSuccessfully");
                        test.Log(LogStatus.Pass, "Test Passed, Certificate Added Successfully");
                        Assert.Pass("Test Passed, Certificate Added");
                    }
                    else
                    {
                        test.Log(LogStatus.Fail, "Test Failed, Certificate not Added ");
                        Assert.Fail("Test Fail, Certificate not Added");
                    }
                }


                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



             #endregion
            

        }

        public void UpdateCertificate()
        {
            #region Update Certificate
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileCertificate");
            //click on Skill
            EditCerti.WaitForElementClickable(driver, 60);
            EditCerti.Click();
            Thread.Sleep(3000);
            // Enter Certificate Name
            EnterCerti.Clear();
            EnterCerti.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "UpdateCertificate"));
            // Enter Certified from
            Thread.Sleep(3000);
            CertiFrom.Clear();
            CertiFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "UpdateCertifiedFrom"));
            // Select Year
            Thread.Sleep(3000);
            SelectElement year = new SelectElement(driver.FindElement(By.XPath("//select[@name ='certificationYear']")));
            year.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(2, "UpdateYear"));
            UpdateCerti.WaitForElementClickable(driver, 60);
            UpdateCerti.Click();
            Thread.Sleep(4000);
            #endregion

            #region Validate Certificate
            

            Thread.Sleep(3000);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileCertificate");
            String ActualCert = driver.FindElement(By.XPath("//td[contains(text(),'ISTQBExpert')]")).Text;
            String ExpectedCert = GlobalDefinitions.ExcelLib.ReadData(2, "UpdateCertificate");


            try
            {
                Thread.Sleep(3000);
                test = extent.StartTest("Update Certificate");

                if (ActualCert == ExpectedCert)
                {

                    test.Log(LogStatus.Info, "Validating the Update Certificate");
                    Thread.Sleep(3000);
                    SaveScreenShotClass.SaveScreenshot(driver, "CertificateUpdatedSuccessfully");
                    test.Log(LogStatus.Pass, "Test Passed, Certificate Updated Successfully");
                    Assert.Pass("Test Passed, Certificate Updated");
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed, Certificate not Updated ");
                    Assert.Fail("Test Fail, Certificate not Updated");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
        }

        public void DeleteCertificate()
        {
            #region Delete given Education
            // Populate Login page test data collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileCertificate");
            String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "DeleteCertificate");
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


            #region validate Delete Certificate
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileCertificate");
            Thread.Sleep(3000);
            String ActualCertificate = driver.FindElement(By.XPath("//td[contains(text(),'ISTQBExpert')]")).Text;
            Thread.Sleep(3000);
            String ExpectedCertificate = GlobalDefinitions.ExcelLib.ReadData(2, "DeleteCertificate");
            try
            {
                Thread.Sleep(3000);
                test = extent.StartTest("Delete Certificate");

                if (ActualCertificate != ExpectedCertificate)
                {

                    test.Log(LogStatus.Fail, "Test Failed, Certificate not Deleted");
                    Assert.Fail("Test Fail, Certificate not Deleted");
                }
                else
                {
                    test.Log(LogStatus.Pass, "Test Passed, Certificate Delated Successfully");
                    test.Log(LogStatus.Info, "Validating the Delete Certificate");
                    Thread.Sleep(3000);
                    SaveScreenShotClass.SaveScreenshot(driver, "CertificateDeletedSuccessfully");
                    Assert.Pass("Test Passed, Certificate Deleted");
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






