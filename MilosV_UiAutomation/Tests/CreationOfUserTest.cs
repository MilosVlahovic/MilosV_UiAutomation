using NUnit.Framework;
using MilosV_UiAutomation.Pages;
using MilosV_UiAutomation.TestInfrastructure;

namespace MilosV_UiAutomation.Tests
{
    public class CreationOfUserTest : TestSetup
    {
        private XyzLandingPage landingPage;

        [Test]
        public void TestCreateNewUser()
        {
            //Kreiranje novog korisnika i login.
            landingPage = new XyzLandingPage(driver);
            landingPage.NavigateToHomePage();
            landingPage.RejectCookiePopup();
            XyzUserCreationPage userCreate = landingPage.NavigateToCreateNewUser();
            XyzLoginPage loginPage = userCreate.InsertUserDetails();
            Assert.That(loginPage.IsUserCreationMessageVisible(), Is.True, "The expected message was not displayed after user creation.");
            loginPage.Login();
            
        }
    }
}


