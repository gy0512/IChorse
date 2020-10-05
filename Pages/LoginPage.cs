using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace IChorse.Pages
{
    class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
                Console.WriteLine("transaction-LoginSteps-start");
                // launch log in page
                driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

                // maximise web browser
                driver.Manage().Window.Maximize();

                // username
                driver.FindElement(By.Id("UserName")).SendKeys("hari");

                // password
                driver.FindElement(By.Id("Password")).SendKeys("123123");

                // click on log in
                driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();

                // validate log in             
                try
                {
                    IWebElement logIn = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
                    Assert.That(logIn.Text == "Hello hari!");
                    Console.WriteLine("transaction-LoginSteps-end");
                }
                catch (Exception ex)
                {
                    Assert.Fail($"{driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a")).Text} != \"Hello hari!\"", ex.Message);
                }
        }
    }
}
