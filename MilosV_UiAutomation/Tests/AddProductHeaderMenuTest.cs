using MilosV_UiAutomation.Pages;
using MilosV_UiAutomation.TestInfrastructure;
using NUnit.Framework;


namespace MilosV_UiAutomation.Tests
{
    public class AddProductHeaderMenu : TestSetup
    {
        private XyzLandingPage landingPage;

        [Test]
        public void AddingProductFromHeaderDdropDownMenu()
        {
            landingPage = new XyzLandingPage(driver);
            landingPage.NavigateToHomePage();
            landingPage.RejectCookiePopup();
            XyzLoginPage loginPage = landingPage.NavigateToLoginPage();
            XyzLandingPage homePage = loginPage.Login();
            XyzWalletsPage walletsPage = homePage.SelectHeaderProductCategory();
            walletsPage.SortingProducts("Cene rastuće");
            XyzProductOverviewPage productOverview = walletsPage.SelectProduct();
            productOverview.GetProductTitle("BOSS - Monogram muška futrola za kartice");
            Assert.That(productOverview.GetProductTitle("BOSS - Monogram muška futrola za kartice"), Is.EqualTo("BOSS - Monogram muška futrola za kartice"));
            productOverview.AddToCart();
            productOverview.ClickMiniCart();
            XyzCheckOutPage checkOutPage = productOverview.ClickGoToCheckout();
            XyzPaymentPage paymentpage = checkOutPage.FillCheckoutForm();
            paymentpage.SelectPaymentMethodCard();
            paymentpage.FillCardDetails();
            paymentpage.AgreeToTerms();

        }
    }

}