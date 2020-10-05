using IChorse.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace IChorse.Pages
{
    class CompanyPage
    {
        // using current datetime or random number as dynamic parameter
        private static readonly string randDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        private static readonly Random rd = new Random();
        public static string CurrentDateTime => randDateTime;
        public static int randNum = rd.Next(1, 999999);
        public static string firstname = "test";
        public static string lastname = "birds";
        public static string phone = "0210547001";


        public void CreateCompany(IWebDriver driver)
        {
            Console.WriteLine("transaction-CreateCompany_Create New-start");
            // create new company
            driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();            
            Thread.Sleep(2000);//Wait not work

            // validate create new
            try
            {
                IWebElement Company = driver.FindElement(By.XPath("//*[@id=\"container\"]/h2"));
                Assert.That(Company.Text == "Company");
                Console.WriteLine("transaction-CreateCompany_Create New-end");
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"container\"]/h2")).Text} != Company", ex.Message);
            }
        }

        public void InputForCreateCompany(IWebDriver driver)
        {
            // input company name
            driver.FindElement(By.Id("Name")).SendKeys($"{firstname}{lastname}");
            Wait.WaitForElement(driver, "Id", "Name", 3);

            Console.WriteLine("transaction-CreateCompany_ContactDisplay-start");
            // edit contact
            /*//this is a code fraction to validate current workable window
            Console.WriteLine("count windows handlers" + driver.WindowHandles.Count);
            foreach (var item in driver.WindowHandles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Current window handle" + driver.CurrentWindowHandle);*/
            driver.FindElement(By.XPath("//*[@id=\"EditContactButton\"]")).Click();
            Wait.WaitForElement(driver, "XPath", "//*[@id=\"EditContactButton\"]", 3);
            try
            {
                IWebElement EditContactDisplay = driver.FindElement(By.XPath("//*[@id=\"contactDetailWindow_wnd_title\"]"));
                Assert.That(EditContactDisplay.Text == "Edit Contact");
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"contactDetailWindow_wnd_title\"]")).Text} != Edit Contact", ex.Message);
            }

            // switch to iframe
            //didn't work for: driver.SwitchTo().Window(driver.WindowHandles[1]); or driver.SwitchTo().Window(driver.WindowHandles.Last());
            //workable solution: https://blog.csdn.net/MTbaby/article/details/77563289
            IWebElement iframe = driver.FindElement(By.XPath("//*[@id=\"contactDetailWindow\"]/iframe"));           
            driver.SwitchTo().Frame(iframe);

            // firstname   
            driver.FindElement(By.XPath("//*[@id=\"FirstName\"]")).SendKeys($"{firstname}");
            Wait.WaitForElement(driver, "XPath", "//*[@id=\"FirstName\"]", 3);

            // lastname
            driver.FindElement(By.XPath("//*[@id=\"LastName\"]")).SendKeys($"{lastname}");
            Wait.WaitForElement(driver, "XPath", "//*[@id=\"LastName\"]", 3);

            // phone
            driver.FindElement(By.XPath("//*[@id=\"Phone\"]")).SendKeys($"{phone}");
            Wait.WaitForElement(driver, "XPath", "//*[@id=\"Phone\"]", 3);

            // save contract
            driver.FindElement(By.XPath("//*[@id=\"submitButton\"]")).Click();
            Thread.Sleep(3000);//Wait not work

            // iframe back to original page 
            driver.SwitchTo().DefaultContent();

            // validate contact display
            try
            {
                IWebElement ContactDisplay = driver.FindElement(By.XPath("//*[@id=\"ContactDisplay\"]"));               
                IWebElement BillingContactDisplay = driver.FindElement(By.XPath("//*[@id=\"BillingContactDisplay\"]"));
                Assert.That(ContactDisplay.GetAttribute("value") == BillingContactDisplay.GetAttribute("value"));
                Console.WriteLine("transaction-CreateCompany_ContactDisplay-end");
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"ContactDisplay\"]")).GetAttribute("value")} != {driver.FindElement(By.XPath("//*[@id=\"BillingContactDisplay\"]")).GetAttribute("value")}", ex.Message);
            }

            Console.WriteLine("transaction-CreateCompany_createnewgroup-start");
            // create new group
            driver.FindElement(By.XPath("//*[@id=\"CreateGroupButton\"]")).Click();
            Wait.WaitForElement(driver, "XPath", "//*[@id=\"CreateGroupButton\"]", 3);

            // switch to iframe
            IWebElement iframe_addgroup = driver.FindElement(By.XPath("//*[@id=\"groupDetailWindow\"]/iframe"));
            driver.SwitchTo().Frame(iframe_addgroup);

            // group name
            driver.FindElement(By.XPath("//*[@id=\"Name\"]")).SendKeys($"g{firstname}{lastname}");
            Thread.Sleep(2000);//Wait not work

            // save group           
            driver.FindElement(By.XPath("//*[@id=\"GroupEditForm\"]/div/div[2]/div/input[1]")).Click(); //didn't work cause of same id: driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]")).Click();
            Thread.Sleep(3000);//Wait not work

            // iframe back to original page            
            driver.SwitchTo().DefaultContent();

            // last page of group
            driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(3000);//Wait not work

            // validate group display
            try
            {
                IWebElement NewGroupDisplay = driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[2]"));
                Assert.That(NewGroupDisplay.Text == $"g{firstname}{lastname}");
                Thread.Sleep(2000);
                Console.WriteLine("transaction-CreateCompany_createnewgroup-end");
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[2]")).Text} != g{firstname}{lastname}", ex.Message);
            }
        }
        
        public void SaveCompany(IWebDriver driver)
        {

            Console.WriteLine("transaction-CreateCompany-start");
            // save company
            driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]")).Click();
            Thread.Sleep(3000);//Wait not work
        }

        public void VerifyCreateCompany(IWebDriver driver)
        {
            // last page of company
            driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(3000);//Wait not work

            // validate company display
            try
            {
                IWebElement NewCompanyDisplay = driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(NewCompanyDisplay.Text == $"{firstname}{lastname}");
                Console.WriteLine("transaction-CreateCompany-end");
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text} != {firstname}{lastname}", ex.Message);
            }
        }

        public void EditCompany(IWebDriver driver)
        {
            Console.WriteLine("transaction-EditCompany-start");
            //refresh current page
            driver.Navigate().Refresh();
            Thread.Sleep(1000);

            // last page of company list
            driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(4000);//Wait not work

            // validate company display
            try
            {
                IWebElement NewCompanyDisplay = driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(NewCompanyDisplay.Text == $"{firstname}{lastname}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text} != {firstname}{lastname}", ex.Message);
            }

            // edit company
            driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]")).Click();

            // validate edit display
            try
            {
                IWebElement companyName = driver.FindElement(By.Id("Name"));
                Assert.That(companyName.GetAttribute("value") == $"{firstname}{lastname}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.Id("Name")).GetAttribute("value")} != {firstname}{lastname}", ex.Message);
            }
        }

        public void InputForEditCompany(IWebDriver driver)
        {
            // rename company
            driver.FindElement(By.Id("Name")).Clear();
            Wait.WaitForElement(driver, "Id", "Name", 3);
            driver.FindElement(By.Id("Name")).SendKeys($"{lastname} {firstname}");
            Wait.WaitForElement(driver, "Id", "Name", 3);

            // last page of group
            driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(3000);//Wait not work

            // validate group display
            try
            {
                IWebElement groupName = driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[2]"));
                Assert.That(groupName.Text == $"g{firstname}{lastname}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[2]")).Text} != g{firstname}{lastname}", ex.Message);
            }

            // click on edit group           
            driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[4]/a[1]")).Click();
            Thread.Sleep(2000);

            // Switch to iframe
            IWebElement iframe_editgroup = driver.FindElement(By.XPath("//*[@id=\"groupDetailWindow\"]/iframe"));
            driver.SwitchTo().Frame(iframe_editgroup);
            Thread.Sleep(1000);

            // rename group
            driver.FindElement(By.Id("Name")).Clear();
            Wait.WaitForElement(driver, "Id", "Name", 3);
            driver.FindElement(By.XPath("//*[@id=\"Name\"]")).SendKeys($"g{lastname}{firstname}{randNum}");
            Thread.Sleep(2000);//Wait not work

            // save group
            driver.FindElement(By.XPath("//*[@id=\"GroupEditForm\"]/div/div[2]/div/input[1]")).Click();
            Thread.Sleep(2000);//Wait not work           

            // validate group edit
            try
            {               
                IWebElement groupNmae = driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[2]"));
                Assert.That(groupNmae.Text == $"g{lastname}{firstname}{randNum}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[2]")).Text} != g{lastname}{firstname}{randNum}", ex.Message);
            }
        }

        public void VerifyEditCompany(IWebDriver driver)
        {
            // last page of company list
            driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(2000);//Wait not work

            // validate company edit
            try
            {
                IWebElement companyName = driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(companyName.Text == $"{lastname} {firstname}");
                Thread.Sleep(2000);
                Console.WriteLine("transaction-EditCompany-end");
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text} != {lastname} {firstname}", ex.Message);
            }
        }


        public void DeleteCompany(IWebDriver driver)
        {
            Console.WriteLine("transaction-DeleteCompany-start");
            //refresh current page
            driver.Navigate().Refresh();
            Thread.Sleep(2000);

            // last page of company list
            driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(4000);//Wait not work

            // validate company display
            try
            {
                IWebElement companyName = driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                Thread.Sleep(2000);
                Assert.That(companyName.Text == $"{lastname} {firstname}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text} != {lastname} {firstname}", ex.Message);
            }

            // edit company
            driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]")).Click();

            // validate edit display
            try
            {
                IWebElement companyName = driver.FindElement(By.Id("Name"));
                Assert.That(companyName.GetAttribute("value") == $"{lastname} {firstname}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.Id("Name")).GetAttribute("value")} != {lastname} {firstname}", ex.Message);
            }

            // last page of group
            driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(3000);//Wait not work

            // validate group display
            try
            {
                IWebElement groupName = driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[2]"));
                Assert.That(groupName.Text == $"g{lastname}{firstname}{randNum}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[2]")).Text} != g{lastname}{firstname}{randNum}", ex.Message);
            }

            //  delete group            
            driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[4]/a[2]")).Click();

            // confirm to delete
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);

            /*// refresh current page
            driver.Navigate().Refresh();
            Thread.Sleep(2000);*/

            // last page of group
            driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(3000);//Wait not work

            // validate group delete
            try
            {
                IWebElement groupNmae = driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[2]"));
                Assert.That(groupNmae.Text != $"g{lastname}{firstname}{randNum}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"groupGrid\"]/div[2]/table/tbody/tr[last()]/td[2]")).Text} == g{lastname}{firstname}{randNum}", ex.Message);
            }

            // save company
            driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]")).Click();
            Thread.Sleep(2000);//Wait not work

            // last page of company list
            driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(4000);//Wait not work

            // validate company display
            try
            {
                IWebElement companyName = driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                Thread.Sleep(2000);
                Assert.That(companyName.Text == $"{lastname} {firstname}");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text} != {lastname} {firstname}", ex.Message);
            }

            // delete company
            driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]")).Click();

            // confirm to delete
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
        }

        public void VerifyDeleteCompany(IWebDriver driver)
        {
            // last page of company list
            driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(4000);//Wait not work

            // validate given company disappeard
            try
            {               
                IWebElement CompanyName = driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(CompanyName.Text != $"{lastname} {firstname}");
                Console.WriteLine("transaction-DeleteCompany-end");
            }
            catch (Exception ex)
            {
                Assert.Fail($"{driver.FindElement(By.XPath("//*[@id=\"companiesGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text} == {lastname} {firstname}", ex.Message);
            }
        }
    }
}
