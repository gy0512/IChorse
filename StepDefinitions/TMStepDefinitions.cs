using IChorse.Helpers;
using IChorse.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;


namespace IChorse.StepDefinitions
{
    [Binding, Scope(Feature = "TM")]//[Binding]
    public sealed class TMStepDefinitions
    {
        IWebDriver driver;
        private Context _context;

        public TMStepDefinitions(Context context)
        {
            //_context = context;
            _context = new Context();
        }

        //[BeforeScenario]
        //public void LoginToTurnUp()
        //{
        //    // define webdriver
        //    //var option = new ChromeOptions();
        //    //option.AddArgument("--headless");
        //    //option.AddArgument("--start-maximized");
        //    //option.AddAdditionalCapability("useAutomationExtension", false);
        //    //option.AddArgument("no-sandbox");
        //    //driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), option);//driver = new ChromeDriver(option)
        //    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //driver = new ChromeDriver();

        //    // Object init and define for login page
        //    SFLoginPage loginObj = new SFLoginPage();
        //    loginObj.LoginSteps(driver);
        //}

        [AfterScenario]
        public void Dispose()
        {
            driver.Dispose();// close the window and release memory
        }

        [Given(@"I login to the TurnUp")]
        public void GivenILoginToTheTurnUp()
        {
            // define webdriver
            //var option = new ChromeOptions();
            //option.AddArgument("--headless");
            //driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), option);//driver = new ChromeDriver(option)
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //driver = new ChromeDriver();

            // Object init and define for login page
            SFLoginPage loginObj = new SFLoginPage();
            loginObj.LoginSteps(driver);


            /*var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions))
            {
                SFLoginPage loginObj = new SFLoginPage();
                loginObj.LoginSteps(driver);
            }*/
        }

        //Cretate New TM Start
        [Given(@"I navigate to the TM")]
        public void GivenINavigateToTheTM()
        {
            var homePage = new SFHomePage();
            homePage.NavigateToTM(driver);
        }


        [Given(@"I click the create new button")]
        public void GivenIClickTheCreateNewButton()
        {
            var tmPage = new SFTMPage();
            tmPage.CreateTM(driver);
        }

        //[Given(@"I create entries using code: '(.*)' and price: '(.*)'")]
        //public void GivenICreateEntriesUsingCodeAndPrice(string code, string price)
        //{
        //    var tmPage = new SFTMPage();
        //    var randNum = tmPage.CreateRandomPrice();
        //    var currentdt = tmPage.CreateRandomCode();
        //    _context.price = randNum;
        //    _context.code = currentdt;
        //}

        [When(@"I create entries using code: '(.*)' and price: '(.*)'")]
        public void WhenICreateEntriesUsingCodeAndPrice(string code, string price)
        {
            var tmPage = new SFTMPage();
            var randNum = tmPage.CreateRandomPrice();
            var currentdt = tmPage.CreateRandomCode();
            _context.price = randNum;
            _context.code = currentdt;
            //tmPage.CreateTMWithValues(driver, _context.code, _context.price);
        }

        [Then(@"I am able to verify with code: '(.*)'")]
        public void ThenIAmAbleToVerifyWithCode(string code)
        {
            //var tmPage = new SFTMPage();

            //var result = tmPage.IsRecordCreated(driver, _context.code);
            //Assert.IsTrue(result, "NO TM Record created for code : " + _context.code);
        }

        /*[When(@"I created entries using values from table :")]
        public void WhenICreatedEntriesUsingValuesFromTable(Table table)
        {
            var code = string.Empty;
            var price = string.Empty;
            var data = table;
            var TMPage = new TMpage();

            for (var i = 0; i < data.Rows.Count; i++)
            {
                code = data.Rows[i]["code"];
                price = data.Rows[i]["price"];
                TMPage.CreateTMWithValues(driver, code, price);
            }
        }*/


        [Given(@"I input the details for creating TM")]
        public void GivenIInputTheDetailsForCreatingTM()
        {
            var tmPage = new SFTMPage();
            tmPage.InputForSaveTM(_context.price, _context.code, driver);
        }

        [Given(@"I click the save button")]
        public void GivenIClickTheSaveButton()
        {
            var tmPage = new SFTMPage();
            tmPage.SaveTM(driver);
        }

        [Then(@"I should see the given TM record")]
        public void ThenIShouldSeeTheGivenTMRecord()
        {
            var tmPage = new SFTMPage();
            tmPage.VerifyCreateTM(_context.price, _context.code, driver);
        }
        //Cretate New TM End


        ////Edit TM Start
        //[Given(@"I should see the given TM record")]
        //public void GivenIShouldSeeTheGivenTMRecord()
        //{
        //    var tmPage = new SFTMPage();
        //    tmPage.VerifyCreateTM(driver, _context.price, _context.code);
        //}

        //[Given(@"I click the edit button")]
        //public void GivenIClickTheEditButton()
        //{
        //    var tmPage = new SFTMPage();
        //    tmPage.EditTM(driver);
        //}

        //[Given(@"I input the details for edit TM")]
        //public void GivenIInputTheDetailsForEditTM()
        //{
        //    var tmPage = new SFTMPage();
        //    tmPage.InputForEditTM(driver);
        //}

        //[Given(@"I click the save button for edit TM")]
        //public void GivenIClickTheSaveButtonForEditTM()
        //{
        //    var tmPage = new SFTMPage();
        //    tmPage.SaveTM(driver);
        //}

        //[Then(@"I should see the given TM record is modified")]
        //public void ThenIShouldSeeTheGivenTMRecordIsModified()
        //{
        //    var tmPage = new SFTMPage();
        //    tmPage.VerifyEditTM(driver);
        //}
        ////Edit TM End


        ////Delete TM Start
        //[Given(@"I should see the given TM record is modified")]
        //public void GivenIShouldSeeTheGivenTMRecordIsModified()
        //{
        //    var tmPage = new SFTMPage();
        //    tmPage.VerifyEditTM(driver);
        //}

        //[Given(@"I click the delete button and confirm to delete for deleting TM")]
        //public void GivenIClickTheDeleteButtonAndConfirmToDeleteForDeletingTM()
        //{
        //    var tmPage = new SFTMPage();
        //    tmPage.DeleteTM(driver);
        //}

        //[Then(@"I should see the given TM record deleted")]
        //public void ThenIShouldSeeTheGivenTMRecordDeleted()
        //{
        //    var tmPage = new SFTMPage();
        //    tmPage.VerifyDeleteTM(driver);
        //}
        ////Delete TM End
    }
}
