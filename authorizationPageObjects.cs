using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestGmail.PageObjects
{
    class AuthorizationPageObjects
    {
        private IWebDriver _webDriver;
        private readonly By _loginInput= By.XPath("//input[@name='login']");
        private readonly By _passwordInput = By.XPath("//input[@name='password']");
        private readonly By _continueButton = By.XPath("//button[@class='Ol0-ktls jY4tHruE _2yaudugp']");
        private readonly By _loginUser = By.XPath("//p[@class = 'login-button__user']");
        public const string _login = "testeremail@ukr.net";
        public const string _login2 = "testeremail2@ukr.net";
        public const string _password = "test1234";
        public AuthorizationPageObjects(IWebDriver webDriver)
            
        {
            _webDriver = webDriver;
        }

        public msgListPageObjects Login(string login, string password)
        {
            _webDriver.FindElement(_loginInput).SendKeys(login);
            _webDriver.FindElement(_passwordInput).SendKeys(password);
            Thread.Sleep(400);
            _webDriver.FindElement(_continueButton).Click();
            Thread.Sleep(1000);
            var actualLogin = _webDriver.FindElement(_loginUser).Text;
            Thread.Sleep(1000);
            Assert.AreEqual(login, actualLogin, "login is wrong");
            //Console.WriteLine("qqq");
;            return new msgListPageObjects(_webDriver);

        }
       
    }
}
