using NUnit.Framework;
using MilosV_UiAutomation.Pages;
using MilosV_UiAutomation.TestInfrastructure;

namespace MilosV_UiAutomation.Tests
{
    public class AddProductHomePage : TestSetup
    {
        private XyzLandingPage landingPage;

        [Test]
        public void AddingProductFromHomePage()
        {
            landingPage = new XyzLandingPage(driver);
            landingPage.NavigateToHomePage();
            landingPage.RejectCookiePopup();
            XyzLoginPage loginPage = landingPage.NavigateToLoginPage();
            XyzLandingPage homePage = loginPage.Login();
            homePage.SelectTab();
            XyzProductOverviewPage productOverview = homePage.SelectProduct();
            productOverview.GetProductTitle("Lanena muška košulja");
            Assert.That(productOverview.GetProductTitle("Lanena muška košulja"), Is.EqualTo("Boggi Milano - Lanena muška košulja"));
            productOverview.SelectSize("XL");
            productOverview.GetProductPrice();
            Assert.That(productOverview.GetProductPrice(), Is.EqualTo("17.490,00 RSD"));
            productOverview.AddToCart();
            productOverview.AssertCartValue(1);

        }
    }
}