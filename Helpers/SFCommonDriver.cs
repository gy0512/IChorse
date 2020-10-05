using IChorse.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Reflection;

namespace IChorse.Helpers
{
    class SFCommonDriver
    {
        // init webdriver
        public static IWebDriver driver;

        [OneTimeSetUp] //[SetUp]
        public void LoginToTurnUp()
        {
            // define webdriver
            /*var option = new ChromeOptions();
            option.AddArgument("--headless");
            driver = new ChromeDriver(option);*/
            driver = new ChromeDriver();

            // Object init and define for login page
            SFLoginPage loginObj = new SFLoginPage();
            loginObj.LoginSteps(driver);
        }

        [OneTimeTearDown] //[TearDown]
        public void TestClosure()
        {
            Thread.Sleep(3000);
            // close instances of open chrome driver
            driver.Quit();

        }
    }
}
