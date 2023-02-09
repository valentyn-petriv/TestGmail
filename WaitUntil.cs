using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGmail.PageObjects
{
    class WaitUntil
    {

        public static void WaitElement(IWebDriver webDriver, By locator, int seconds =20)
        {

            WebDriverWait wait= new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
