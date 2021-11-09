using Excel.Log;
using MarsFramework.Config;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using MarsFramework.Pages.Profile;

namespace MarsFramework
{
    //[TestFixture(BrowserType.Firefox)]
    [TestFixture(BrowserType.Chrome)]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("Sprint1")]
    public class Program : Base

    {
        public Program(BrowserType browser) : base(browser)
        {
        }

        [Test, Order(1)]
        [Obsolete]
        public void CreateShareSkill()
        {

            test = extent.StartTest("Create ShareSkill");
            test.Log(LogStatus.Info, "ShareSkills");
            //taking Screenshots of adding skills
            SaveScreenShotClass.SaveScreenshot(driver, "ShareSkill");
            //Create Share Skills      
            ShareSkill skillObj = new ShareSkill();
            skillObj.AddShareSkill();
            skillObj.ValidateCreateListing();


        }
        [Test, Order(2)]
        [Obsolete]
        public void EditshareSkill()
        {

            test = extent.StartTest("Edit ShareSkill");
            test.Log(LogStatus.Info, "ShareSkills");
            //taking Screenshots of adding skills
            SaveScreenShotClass.SaveScreenshot(driver, "ShareSkill");

            //Edit Share Skills 

            ManageListings MLObj = new ManageListings();

            MLObj.EditshareSkill();
            MLObj.ValidateEditListing();
        }

        [Test, Order(3)]
        [Obsolete]
        public void ViewShareSkill()
        {

            test = extent.StartTest("View Manage Listing");
            test.Log(LogStatus.Info, "ManageListings");
            //taking Screenshots of adding skills
            SaveScreenShotClass.SaveScreenshot(driver, "ManageListngs");
            //View Share Skills
            ManageListings MLObj = new ManageListings();
            MLObj.ViewShareSkill();
            MLObj.ValidateViewListing();




        }
        [Test, Order(4)]
        [Obsolete]
        public void DeleteShareSkill()
        {

            test = extent.StartTest("Delete Manage Listing");
            test.Log(LogStatus.Info, "ManageListings");
            //taking Screenshots of ManageListing
            SaveScreenShotClass.SaveScreenshot(driver, "ManageListngs");
            //Delete Share Skills
            ManageListings MLObj = new ManageListings();
            MLObj.DeleteShareSkill();
            MLObj.ValidateDeleteListing();
        }
        [Test, Order(5)]
        [Obsolete]
        public void EditProfile()
        {
            test = extent.StartTest("Edit Profile");
            test.Log(LogStatus.Pass, "Password Changed and Saved Successfully");
            test.Log(LogStatus.Info, "Validating Profile");
            //taking Screenshots of profile
            SaveScreenShotClass.SaveScreenshot(driver, "Profile");

            Profile proObj = new Profile();
            proObj.EditProfile();
            proObj.ChangePassword();
            proObj.Chat();
        }
        [Test, Order(6)]
        [Obsolete]
        public void AddLanguage()
        {
            test = extent.StartTest("Languages");
            test.Log(LogStatus.Pass, "Languages Added, Updated and Deleted Succesfully");
            test.Log(LogStatus.Info, "Validating Languages");
            //taking Screenshots of adding Languages
            SaveScreenShotClass.SaveScreenshot(driver, "Languages");
            // create object for add language

            ProfileLanguage langObj = new ProfileLanguage();
            langObj.AddLanguage();
            langObj.UpdateLanguage();
            langObj.DeleteLang();
            langObj.ValidateDelLan();
        }
        [Test, Order(7)]
        [Obsolete]
        public void AddSkill()
        {
            test = extent.StartTest("Skills");
            test.Log(LogStatus.Pass, "Skills Added, Updated and Deleted Succesfully");
            test.Log(LogStatus.Info, "Validating Skills");
            //taking Screenshots of adding skills
            SaveScreenShotClass.SaveScreenshot(driver, "Skills");
            // create object for add Skills
            ProfileSkills skillObj = new ProfileSkills();
            skillObj.AddSkills();
            skillObj.UpdateSkills();
            skillObj.DeleteSkill();
            skillObj.ValidateDeleteSkills();

        }
        [Test, Order(8)]
        [Obsolete]
        public void AddEducation()
        {
            test = extent.StartTest("Education");
            test.Log(LogStatus.Pass, "Education Added, Updated and Deleted Succesfully");
            test.Log(LogStatus.Info, "Validating Education");
            //taking Screenshots of adding Education
            SaveScreenShotClass.SaveScreenshot(driver, "Education");
            // create object for add Education
            ProfileEducation eduObj = new ProfileEducation();
            eduObj.AddEducation();
            eduObj.UpdateLanguage();
            eduObj.DeleteEducation();


        }
        [Test, Order(9)]
        [Obsolete]
        public void AddCertificate()
        {
            test = extent.StartTest("Certificates");
            test.Log(LogStatus.Pass, "Certificates Added, Updated and Deleted Succesfully");
            test.Log(LogStatus.Info, "Validating Certificates");
            //taking Screenshots of adding Certification
            SaveScreenShotClass.SaveScreenshot(driver, "Certificates");
            // create object for add Certification

            ProfileCertification proObj = new ProfileCertification();
            proObj.AddCertificate();
            proObj.UpdateCertificate();
            proObj.DeleteCertificate();
        }
        [Test, Order(10)]
        [Obsolete]
        public void AcceptRecievedRequests()
        {
            test = extent.StartTest("AcceptRecievedRequests");
            test.Log(LogStatus.Pass, "AcceptedRecievedRequests");
            test.Log(LogStatus.Info, "Validating AcceptRecievedRequests");
            //taking Screenshots of ManageRequets
            SaveScreenShotClass.SaveScreenshot(driver, "AcceptRecievedRequets");
            // create object for ManageRequets
            ManageRequests manObj = new ManageRequests();
            manObj.RecievedRequests();

        }
        [Test, Order(11)]
        [Obsolete]
        public void SentserviceRequests()
        {
            test = extent.StartTest("SentRequests");
            test.Log(LogStatus.Pass, "SentRequests Completed Successfully");
            test.Log(LogStatus.Info, " Validating SentRequests");
            //taking Screenshots of ManageRequets
            SaveScreenShotClass.SaveScreenshot(driver, "SentRequets");
            // create object for ManageRequets
            ManageRequests manObj = new ManageRequests();
            manObj.SentRequests();

        }
        [Test, Order(12)]
        [Obsolete]
        public void SentServiceRequestReview()
        {
            test = extent.StartTest("ReviewRequest");
            test.Log(LogStatus.Pass, "ReviewRequest Reviewd Successfully");
            test.Log(LogStatus.Info, "Validate ReviewRequest");
            //taking Screenshots of ManageRequets
            SaveScreenShotClass.SaveScreenshot(driver, "ReviewRequest");
            // create object for ManageRequets
            ManageRequests manObj = new ManageRequests();
            manObj.Review();
        }
        [Test, Order(12)]
        [Obsolete]
        public void DeclineRecievedRequests()
        {

            test = extent.StartTest("DeclineRecievedRequests");
            test.Log(LogStatus.Pass, "Request Declined");
            test.Log(LogStatus.Info, "Validating DeclineRecievedRequests");
            //taking Screenshots of ManageRequets
            SaveScreenShotClass.SaveScreenshot(driver, "DeclineRecievedRequets");
            // create object for ManageRequets
            ManageRequests manObj = new ManageRequests();
            manObj.DeclineRequest();
        }
        [Test, Order(13)]
        [Obsolete]
        public void Notifications()
        {
            test = extent.StartTest("Notifications ");
            test.Log(LogStatus.Pass, "Notifications see all features Successfull");
            test.Log(LogStatus.Pass, "Notifications Update Test Successfull");
            test.Log(LogStatus.Info, "Validating Update Notifications");
            //taking Screenshots of Notifications
            SaveScreenShotClass.SaveScreenshot(driver, "Notifications");
            // create object for Notifications
            Notifications notObj = new Notifications();
            notObj.SeeNotifications();
        }
        [Test, Order(14)]
        [Obsolete]
        public void DeleteNotification()
        {
            test = extent.StartTest("Notifications ");
            test.Log(LogStatus.Pass, "Notifications see all features Successfull");
            test.Log(LogStatus.Pass, "Notifications Delete Test Successfull");
            test.Log(LogStatus.Info, "Validating Delete Notifications");
            //taking Screenshots of Notifications
            SaveScreenShotClass.SaveScreenshot(driver, "Notifications");
            // create object for Notifications
            Notifications notObj = new Notifications();
            notObj.DeleteNotification();
        }
        [Test, Order(15)]
        [Obsolete]
        public void SearchSkills()
        {
            test = extent.StartTest("SearchSkills ");
            test.Log(LogStatus.Pass, "Search Skills Page Visiible");
            test.Log(LogStatus.Pass, "SearchSkills Page");
            test.Log(LogStatus.Info, "Validating Search Skills");
            //taking Screenshots of SearchSkills
            SaveScreenShotClass.SaveScreenshot(driver, "SearchSkills");
            // create object for SearchSkills
            ProfileSearchSkills searchObj = new ProfileSearchSkills();
            searchObj.SearchSkills();
            
        }
        [Test, Order(16)]
        [Obsolete]
        public void RefineSearchSkills()
        {

            test = extent.StartTest("RefineSearchSkills ");
            test.Log(LogStatus.Pass, "RefineSearch Skills Visiible");
            test.Log(LogStatus.Pass, "RefineSearchSkills ");
            test.Log(LogStatus.Info, "Validating RefineSearch Skills");
            //taking Screenshots of SearchSkills
            SaveScreenShotClass.SaveScreenshot(driver, "RefineSearchSkills");
            // create object for SearchSkills
            ProfileSearchSkills searchObj = new ProfileSearchSkills();
            searchObj.RefineSearchSkills();
            searchObj.RefineFilterSearchSkills();
        }
        

    }
}