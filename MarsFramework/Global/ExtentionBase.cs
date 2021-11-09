using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MarsFramework.Global
{
    public static class ExtentionBase
    {
        #region WaitforElement


        #endregion

        public static bool WaitForElementDisplayed(this IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)).Displayed);
        }

        public static IWebElement WaitForElementClickable(this IWebElement element, IWebDriver driver, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForWebElementToExist(IWebDriver driver, string attributevalue, string attribute, int secondsToWait)

        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, secondsToWait));
            if (attribute == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(attributevalue)));
            }
            if (attribute == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(attributevalue)));
            }
            if (attribute == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(attributevalue)));
            }

        }
    }
}