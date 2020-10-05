using IChorse.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;


namespace IChorse.StepDefinitions
{
    [Binding, Scope(Feature = "Company")]//[Binding]

    public sealed class CompanyStepDefinitions
    {
        IWebDriver driver;

        //[BeforeScenario]
        //public void LoginToTurnUp()
        //{
        //    // define webdriver
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

        //[Given(@"I login to the TurnUp")]
        //public void GivenILoginToTheTurnUp()
        //{
        //    // define webdriver
        //    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //driver = new ChromeDriver();

        //    // Object init and define for login page
        //    SFLoginPage loginObj = new SFLoginPage();
        //    loginObj.LoginSteps(driver);

        //}
        [Given(@"I login to the TurnUp for Company")]
        public void GivenILoginToTheTurnUpForCompany()
        {
            // define webdriver
            //var option = new ChromeOptions();
            //option.AddArgument("--headless");
            //driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), option);//driver = new ChromeDriver(option)
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //driver = new ChromeDriver();

            // Object init and define for login page
            SFLoginPage loginObj = new SFLoginPage();
            loginObj.LoginSteps(driver);
        }



        //Cretate New Company Start
        [Given(@"I navigate to the Company")]
        public void GivenINavigateToTheCompany()
        {
            var homePage = new SFHomePage();
            homePage.NavigateToCompany(driver);
        }

       [Given(@"I click the create new button for Company")]
        public void GivenIClickTheCreateNewButtonForCompany()
        {
            var companyPage = new SFCompanyPage();
            companyPage.CreateCompany(driver);
        }

        [Given(@"I input the details for creating Company")]
        public void GivenIInputTheDetailsForCreatingCompany()
        {
            var companyPage = new SFCompanyPage();
            companyPage.InputForCreateCompany(driver);
        }

        [Given(@"I click the save button for creating Company")]
        public void GivenIClickTheSaveButtonForCreatingCompany()
        {
            var companyPage = new SFCompanyPage();
            companyPage.SaveCompany(driver);
        }

        [Then(@"I should see the given Company record")]
        public void ThenIShouldSeeTheGivenCompanyRecord()
        {
            var companyPage = new SFCompanyPage();
            companyPage.VerifyCreateCompany(driver);
        }
        //Cretate New Company End


        //Edit Company Start
        [Given(@"I should see the given Company record")]
        public void GivenIShouldSeeTheGivenCompanyRecord()
        {
            var companyPage = new SFCompanyPage();
            companyPage.VerifyCreateCompany(driver);
        }

        [Given(@"I click the edit button for edit Company")]
        public void GivenIClickTheEditButtonForEditCompany()
        {
            var companyPage = new SFCompanyPage();
            companyPage.EditCompany(driver);
        }

        [Given(@"I input the details for edit Company")]
        public void GivenIInputTheDetailsForEditCompany()
        {
            var companyPage = new SFCompanyPage();
            companyPage.InputForEditCompany(driver);
        }

        [Given(@"I click the save button for edit Company")]
        public void GivenIClickTheSaveButtonForEditCompany()
        {
            var companyPage = new SFCompanyPage();
            companyPage.SaveCompany(driver);
        }

        [Then(@"I should see the given Company record is modified")]
        public void ThenIShouldSeeTheGivenCompanyRecordIsModified()
        {
            var companyPage = new SFCompanyPage();
            companyPage.VerifyEditCompany(driver);
        }
        //Edit Company End


        //Delete Company Start
        [Given(@"I should see the given Company record is modified")]
        public void GivenIShouldSeeTheGivenCompanyRecordIsModified()
        {
            var companyPage = new SFCompanyPage();
            companyPage.VerifyEditCompany(driver);
        }

        [Given(@"I click the delete button and confirm to delete for deleting Company")]
        public void GivenIClickTheDeleteButtonAndConfirmToDeleteForDeletingCompany()
        {
            var companyPage = new SFCompanyPage();
            companyPage.DeleteCompany(driver);
        }

        [Then(@"I should see the given Company record deleted")]
        public void ThenIShouldSeeTheGivenCompanyRecordDeleted()
        {
            var companyPage = new SFCompanyPage();
            companyPage.VerifyDeleteCompany(driver);
        }
        //Delete Company End
    }
}
