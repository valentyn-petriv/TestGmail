using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestGmail.PageObjects
{
    class msgListPageObjects
    {
        private IWebDriver _webDriver;
        private readonly By _sendButton = By.XPath("//button[@class='button primary compose']");
        private readonly By _emailSubject = By.XPath("//a[@class='msglist__row_href']");
        private const string wrongSubject = "ththtrh";

        public msgListPageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public sendMsg SendMessage()
        {

            WaitUntil.WaitElement(_webDriver, _sendButton);
            _webDriver.FindElement(_sendButton).Click();
            return new sendMsg(_webDriver);

        }

        public msgListPageObjects Email() 
            {
            var actualSubject = _webDriver.FindElement(_emailSubject).Text;
            Assert.AreEqual(sendMsg.subject, actualSubject, "subject is wrong");
            return new msgListPageObjects(_webDriver);
            } 

        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

    }
}
