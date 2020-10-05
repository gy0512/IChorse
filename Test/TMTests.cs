using IChorse.Helpers;
using IChorse.Pages;
using NUnit.Framework;

namespace IChorse //September2020
{
    [TestFixture, Description("This fixture contains Time and Material tests")]
    [Parallelizable]
    class TMTests : CommonDriver
    {
        static void Main(string[] args)
        {

        }

        [Test, Order(1), Description("Check if the user is able to create time successfully")]
        public void T1_CreateNewTMTest()
        {
            // Object init and define for home page
            HomePage homObj = new HomePage();
            homObj.NavigateToTM(driver);

            //Test 1 - To check the time creating.
            // Object init and define for TM page
            TMPage tmobj = new TMPage();
            tmobj.CreateTM(driver);
            tmobj.InputForSaveTM(driver);
            tmobj.SaveTM(driver);
            tmobj.VerifyCreateTM(driver);
        }

        [Test, Order(2), Description("Check if the user is able to edit time successfully")]
        public void T2_EditTMTest()
        {
            // Object init and define for home page
            HomePage homObj = new HomePage();
            homObj.NavigateToTM(driver);

            //Test 2 - To check the time editing.
            TMPage tmobj = new TMPage();

            tmobj.CreateTM(driver);
            tmobj.InputForSaveTM(driver);
            tmobj.SaveTM(driver);
            tmobj.VerifyCreateTM(driver);

            tmobj.EditTM(driver);
            tmobj.InputForEditTM(driver);
            tmobj.SaveTM(driver);
            tmobj.VerifyEditTM(driver);
        }       

        [Test, Order(3), Description("Check if the user is able to delete time successfully")]
        public void T3_DeleteTMTest()
        {
            // Object init and define for home page
            HomePage homObj = new HomePage();
            homObj.NavigateToTM(driver);

            //Test 3 - To check the time deleting.
            TMPage tmobj = new TMPage();

            tmobj.CreateTM(driver);
            tmobj.InputForSaveTM(driver);
            tmobj.SaveTM(driver);
            tmobj.VerifyCreateTM(driver);

            tmobj.EditTM(driver);
            tmobj.InputForEditTM(driver);
            tmobj.SaveTM(driver);
            tmobj.VerifyEditTM(driver);

            tmobj.DeleteTM(driver);
            tmobj.VerifyDeleteTM(driver); 
        }
    }
}
