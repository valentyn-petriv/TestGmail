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
       // private string actualSubject;
        private readonly By _sendButton = By.XPath("//button[@class='button primary compose']");
        private readonly By _emailSubject = By.XPath("//a[@class='msglist__row_href']");
        private const string wrongSubject = "ththtrh";
        private const string wrongSubjectException = "Subject is wrong"; 

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
            WaitUntil.WaitElement(_webDriver, _emailSubject);
            var actualSubject = _webDriver.FindElement(_emailSubject).Text;          
            Assert.AreEqual(sendMsg.subject, actualSubject, wrongSubjectException);
            return new msgListPageObjects(_webDriver);
        }

       /* public bool CheckSubject()
        {
            try
            {
              
                
                return true;    
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }*/

    }
}
