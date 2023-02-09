using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestGmail.PageObjects
{
    class sendMsg
    {
        private readonly By _toInput = By.XPath("//input[@name='toFieldInput']");
        public const string _login2 = "testeremail2@ukr.net";
        private readonly By _subjectInput = By.XPath("//input[@name='subject']");
        // private readonly By _textInput = By.XPath("//span[@id='_mce_caret']");
        private readonly By _sendButton = By.XPath("//button[@class='button primary send']");
        public const string subject = "Тестування";
        public const string text = "Hello";
        private readonly By _controlButton = By.XPath("//button[@class='login-button__control']");
        private readonly By _logoutButton = By.XPath("//a[@href='/q/logout']");

        private IWebDriver _webDriver;

        public sendMsg(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public sendMsg SendMessage()
        {
            WaitUntil.WaitElement(_webDriver, _toInput);
            _webDriver.FindElement(_toInput).SendKeys(_login2);
            _webDriver.FindElement(_subjectInput).SendKeys(subject);
            // _webDriver.FindElement(_textInput).SendKeys(text);   // Не працює тег шукаю інший спосіб
            _webDriver.FindElement(_sendButton).Click();
            return new sendMsg(_webDriver);
        }
        public AuthorizationPageObjects Logout()
        {
            WaitUntil.WaitElement(_webDriver, _controlButton);
            _webDriver.FindElement(_controlButton).Click();
            WaitUntil.WaitElement(_webDriver, _logoutButton);
            _webDriver.FindElement(_logoutButton).Click();

            return new AuthorizationPageObjects(_webDriver);
        }
    }
}
