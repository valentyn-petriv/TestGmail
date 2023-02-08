using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TestGmail.PageObjects;
using WebDriverManager;

namespace TestGmail
{
    public class Tests
    {
        private IWebDriver driver;
       
       // private const string _ = "testeremail@ukr.net";



        [SetUp]
        public void Setup()
        {
     
            driver = new ChromeDriver("D:\\chromedriver_win32\\chromedriver");
           
            driver.Navigate().GoToUrl("https://accounts.ukr.net/login?lang=uk");
            driver.Manage().Window.Maximize();
            
        }

        [Test]
        public void Test1()
        {
            var authorization = new AuthorizationPageObjects(driver);
            authorization.Login(AuthorizationPageObjects._login, AuthorizationPageObjects._password);
            var send = new msgListPageObjects(driver);
            send.SendMessage();

            var sendMsg = new sendMsg(driver);
            sendMsg.SendMessage();
            sendMsg.Logout();
            Thread.Sleep(1000);
            authorization.Login(AuthorizationPageObjects._login2, AuthorizationPageObjects._password);

        }


        [TearDown]
        public void TearDown()
        {
            
        }
    }
}