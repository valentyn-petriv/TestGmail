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

         private const string URL = "https://accounts.ukr.net/login?lang=uk";



        [SetUp]
        public void Setup()
        {
     
            driver = new ChromeDriver("D:\\chromedriver_win32\\chromedriver");
           
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            
        }

        [Test]
        public void Test1()
        {
            var authorization = new AuthorizationPageObjects(driver);
            authorization.Login(UserData._login, UserData._password);
            var send = new msgListPageObjects(driver);
            send.SendMessage();

            var sendMsg = new sendMsg(driver);
            sendMsg.SendMessage();
            sendMsg.Logout();
            Thread.Sleep(1000);
            authorization.Login(UserData._login2, UserData._password);
            send.Email();
        }


        [Test]
        public void Test2()
        {
            var authorization = new AuthorizationPageObjects(driver);
            authorization.negativTestLogin(UserData._login, GenerateData.RandomString(6));

        }

        [TearDown]
        public void TearDown()
        {
            
        }
    }
}