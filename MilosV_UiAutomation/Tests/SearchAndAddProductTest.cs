using NUnit.Framework;
using MilosV_UiAutomation.Pages;
using MilosV_UiAutomation.TestInfrastructure;

namespace MilosV_UiAutomation.Tests
{
    public class SearchAndAddProductTest : TestSetup
    {
        private XyzLandingPage landingPage;

        [Test]
        public void SearchAndAddProduct()
        { 
            landingPage = new XyzLandingPage(driver);
            landingPage.NavigateToHomePage();
            landingPage.RejectCookiePopup();
            XyzLoginPage loginPage = landingPage.NavigateToLoginPage();
            XyzLandingPage homePage = loginPage.Login();
            XyzSearchResultPage searchResult = homePage.SearchForProduct("Boss");
            searchResult.SortingProducts("Noviteti");
            XyzProductOverviewPage productOverview = searchResult.SelectProduct();
            String productTitle = productOverview.GetProductTitle("BOSS - Crni muški kačket");
            Assert.That(productOverview.GetProductTitle("BOSS - Crni muški kačket"), Is.EqualTo("BOSS - Crni muški kačket"));
            String productPrice = productOverview.GetProductPrice();
            Assert.That(productPrice, Is.EqualTo("6.990,00 RSD"), "Product price is wrong!");
            productOverview.AddToCart();
            productOverview.ClickMiniCart();
            XyzShoppingCartPage shoppingCart = productOverview.ClickGoToCart();
            Assert.That(shoppingCart.IsProductInCart(), Is.True, "Product is not in the cart!");
            XyzCheckOutPage checkOutPage = shoppingCart.ClickCheckoutButton();
            XyzPaymentPage paymentPage = checkOutPage.FillCheckoutForm();
            paymentPage.SelectPaymentMethodCard();
            paymentPage.FillCardDetails();
            paymentPage.AgreeToTerms();

        }
    }
}