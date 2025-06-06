using MilosV_UiAutomation.BasePom;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MilosV_UiAutomation.Pages
{
    public class XyzProductOverviewPage : XyzBasePom
    {
        public XyzProductOverviewPage(IWebDriver driver) : base(driver) { }

        //Lokatori za elemente na stranici proizvoda:
        By productPrice = By.CssSelector("div.price-box span.price");
        By addToCartButton = By.Id("product-addtocart-button");
        By miniCartButton = By.CssSelector("div.minicart-wrapper a.action.showcart");
        By goToCartButton = By.CssSelector("a.viewcart");
        By goToCheckoutButton = By.Id("top-cart-btn-checkout");
        By cartValue = By.CssSelector("span.counter.qty.minicart-not-empty");

        //Metoda za dohvatanje naslova proizvoda
        private By GetTitleLocator(string partialTitle)
        {
            return By.XPath($"//h1[contains(@class, 'product-name') and contains(text(), '{partialTitle}')]");
        }
        public string GetProductTitle(string partialTitle)
        {
            return driver.FindElement(GetTitleLocator(partialTitle)).Text;
        }



        //Metoda za dohvatanje cene proizvoda
        public string GetProductPrice()
        {
            return driver.FindElement(productPrice).Text;
        }

        //Metoda za dodavanje proizvoda u korpu
        public void AddToCart()
        {
            WaitUntilVisible(addToCartButton);
            driver.FindElement(addToCartButton).Click();
        }

        //Metoda za klik na mini korpu
        public void ClickMiniCart()
        {
            WaitUntilVisible(miniCartButton);
            driver.FindElement(miniCartButton).Click();
        }

        //Metoda za klik na dugme "Idite na korpu"
        public XyzShoppingCartPage ClickGoToCart()
        {
            WaitUntilVisible(goToCartButton);
            driver.FindElement(goToCartButton).Click();
            return new XyzShoppingCartPage(driver);
        }

        //Metoda za klik na dugme "Naplata"
        public XyzCheckOutPage ClickGoToCheckout()
        {
            WaitUntilVisible(goToCheckoutButton);
            driver.FindElement(goToCheckoutButton).Click();
            return new XyzCheckOutPage(driver);
        }

        //Metoda za select velicine:
        public void SelectSize(string size) //Size moze biti: S, M, L, XL, XXL
        {
            var sizeButton = By.XPath($"//div[@option-label='{size}']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(sizeButton));
            element.Click();
        }

        //Metoda koja proverava da li se broj artikala u korpi inkrementira
        public void AssertCartValue(int expectedCount)
        {
         
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(cartValue, "1"));

            string counterText = driver.FindElement(cartValue).Text;
            Assert.That(counterText, Is.EqualTo(expectedCount.ToString()), "Cart counter is not updated.");

        }

    }
}