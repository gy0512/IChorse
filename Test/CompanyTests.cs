using IChorse.Helpers;
using IChorse.Pages;
using NUnit.Framework;

namespace IChorse //IChorse.Test
{
    [TestFixture, Description("This fixture contains Company tests")]
    [Parallelizable]
    class CompanyTests : CommonDriver
    {
        [Test, Order(1), Description("Check if the user is able to create company successfully")]
        public void T1_CreateNewCompanyTest()
        {
            // Object init and define for home page
            HomePage homObj = new HomePage();
            homObj.NavigateToCompany(driver);

            //Test 1 - To check if the user is able to create company successfully.
            // Object init and define for Company page
            CompanyPage companyobj = new CompanyPage();
            companyobj.CreateCompany(driver);
            companyobj.InputForCreateCompany(driver);
            companyobj.SaveCompany(driver);
            companyobj.VerifyCreateCompany(driver);
        }

        [Test, Order(2), Description("Check if the user is able to edit company successfully")]
        public void T2_EditCompanyTest()
        {
            // Object init and define for home page
            HomePage homObj = new HomePage();
            homObj.NavigateToCompany(driver);

            //Test 2 - To check if the user is able to edit company successfully.
            // Object init and define for Company page
            CompanyPage companyobj = new CompanyPage();

            companyobj.CreateCompany(driver);
            companyobj.InputForCreateCompany(driver);
            companyobj.SaveCompany(driver);
            companyobj.VerifyCreateCompany(driver);

            companyobj.EditCompany(driver);
            companyobj.InputForEditCompany(driver);
            companyobj.SaveCompany(driver);
            companyobj.VerifyEditCompany(driver);
        }

        [Test, Order(3), Description("Check if the user is able to delete company successfully")]
        public void T3_DeleteCompanyTest()
        {
            // Object init and define for home page
            HomePage homObj = new HomePage();
            homObj.NavigateToCompany(driver);

            //Test 3 - To check if the user is able to delete company successfully.
            // Object init and define for Company page
            CompanyPage companyobj = new CompanyPage();

            companyobj.CreateCompany(driver);
            companyobj.InputForCreateCompany(driver);
            companyobj.SaveCompany(driver);
            companyobj.VerifyCreateCompany(driver);

            companyobj.EditCompany(driver);
            companyobj.InputForEditCompany(driver);
            companyobj.SaveCompany(driver);
            companyobj.VerifyEditCompany(driver);

            companyobj.DeleteCompany(driver);
            companyobj.VerifyDeleteCompany(driver);
        }
    }
}
