using IChorse.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace IChorse.Pages
{
    class SFTMPage
    {
        //private object code;
        //private object price;

        public string CreateRandomPrice()
        {
            var r = new Random();
            return $"{r.Next(1, 99)}";
        }

        public string CreateRandomCode()
        {
            var dt = DateTime.Now.ToString("yyyyMMddHHmmss");
            return dt;
        }

        //// using current datetime or random number as dynamic parameter
        //private static string randDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        ////private static Random rd = new Random();

        //public static string CurrentDateTime => randDateTime;
        ////public static int randNum = rd.Next(1, 99);

        public void CreateTM(IWebDriver driver)
        {
            // click on createnew
            driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();

            // validate create new
            try
            {
                IWebElement timeMaterials = driver.FindElement(By.XPath("//*[@id=\"container\"]/h2"));
                Assert.That(timeMaterials.Text == "Time and Materials");
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"container\"]/h2")).Text} != Time and Materials", ex.Message);
            }
        }

        //internal void CreateTMWithValues(IWebDriver driver, string code, string price)
        //{
        //    //var randNum = CreateRandomCode();
        //    //throw new NotImplementedException();
        //}

        public void InputForSaveTM(string CurrentDateTime, string randNum, IWebDriver driver)
        {

            // typecode
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]")).Click();

            // code
            driver.FindElement(By.Id("Code")).SendKeys(CurrentDateTime);
            Wait.WaitForElement(driver, "Id", "Code", 3);

            // description
            driver.FindElement(By.Id("Description")).SendKeys(CurrentDateTime);

            // price per unit
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).Click();
            Wait.WaitForElement(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]", 3);
            driver.FindElement(By.Id("Price")).SendKeys("$" + randNum + ".00");
            Wait.WaitForElement(driver, "Id", "Price", 3);

            // select files
            //IWebElement files = driver.FindElement(By.Id("files"));
            //files.SendKeys("D:\\Study\\Industry Connect\\Live Sessions\\alpha-and-beta-testing.png"); //*[@id="TimeMaterialEditForm"]/div/div[6]/div/div/ul/li/span[3]

        }

        public void SaveTM(IWebDriver driver)
        {
            // save
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(3000);//Wait not work
        }

        public void VerifyCreateTM(string CurrentDateTime, string randNum, IWebDriver driver)
        {
            // last page of TM list
            //driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(3000);//Wait not work

            // validate TM display
            try
            {
                IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                Wait.WaitForElement(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 1);               
                Assert.That(code.Text == CurrentDateTime);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text} != {CurrentDateTime}" , ex.Message);
            }
        }

        ////verify multiple TM creation
        //internal bool IsRecordCreated(IWebDriver driver, string code)
        //{
        //    Thread.Sleep(5000);
        //    try
        //    {
        //        //goto last page
        //        IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
        //        lastpage.Click();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("last page cannot be loaded", ex.Message);
        //    }
        //    Wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 400);

        //    //last test element selection
        //    IWebElement expectedcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
        //    if (expectedcode.Text == code)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;

        //    }
        //}


        //public void EditTM(IWebDriver driver)
        //{
        //    // refresh current page
        //    driver.Navigate().Refresh();
        //    Thread.Sleep(1000);

        //    // last page of TM list
        //    driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
        //    Thread.Sleep(3000);//Wait not work

        //    // validate given TM display
        //    try
        //    {
        //        IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        //        Assert.That(code.Text == CurrentDateTime);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text} != {CurrentDateTime}", ex.Message);
        //    }

        //    // click on edit
        //    driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]")).Click();
        //    Thread.Sleep(3000);//Wait not work
        //}

        //public void InputForEditTM(IWebDriver driver)
        //{
        //    // Price per unit
        //    driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).Click();
        //    Wait.WaitForElement(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]", 3);

        //    driver.FindElement(By.Id("Price")).Clear();
        //    Wait.WaitForElement(driver, "Id", "Price", 3);

        //    driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).Click();
        //    Wait.WaitForElement(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]", 3);

        //    IWebElement price = driver.FindElement(By.Id("Price"));
        //    driver.FindElement(By.Id("Price")).SendKeys("$" + randNum + ".99");
        //    Wait.WaitForElement(driver, "Id", "Price", 3);
        //}

        //public void VerifyEditTM(IWebDriver driver)
        //{
        //    // last page of TM list
        //    driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
        //    Thread.Sleep(3000);//Wait not work

        //    // validate price display
        //    try
        //    {
        //        IWebElement price = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
        //        Assert.That(price.Text == "$"+$"{randNum}.99");
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]")).Text} != ${randNum}.99", ex.Message);
        //    }

        //}


        //public void DeleteTM(IWebDriver driver)
        //{
        //    // refresh current page
        //    driver.Navigate().Refresh();
        //    Thread.Sleep(1000);

        //    // last page of TM
        //    driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
        //    Thread.Sleep(2000);

        //    // validate TM display
        //    try
        //    {
        //        IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        //        Wait.WaitForElement(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 1);
        //        Assert.That(code.Text == CurrentDateTime);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text} != {CurrentDateTime}", ex.Message);
        //    }

        //    // click on Delete
        //    driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]")).Click();
        //    Thread.Sleep(2000);

        //    // confirm to delete
        //    driver.SwitchTo().Alert().Accept();
        //    Thread.Sleep(1000);
        //}

        //public void VerifyDeleteTM(IWebDriver driver)
        //{
        //    // last page of TM list
        //    driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
        //    Thread.Sleep(3000);//Wait not work

        //    // validate given record disappeard
        //    try
        //    {
        //        IWebElement code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        //        Assert.That(code.Text != CurrentDateTime);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text} == {CurrentDateTime}", ex.Message);
        //    }
        //}
    }
}
//Opthion 1 - using assert pass and fail on o if condition
/*if (codeText.Text == CurrentDateTime)
{
    Assert.Pass("transaction-save new tm-end");
}
else
{
    Assert.Fail("transaction-save new tm-failed");
}*/

//Option 2 - use assert that
//Assert.That(codeText.Text, Is.EqualTo(CurrentDateTime));