using MilosV_UiAutomation.BasePom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MilosV_UiAutomation.Pages
{
    public class XyzProductOverviewPage : XyzBasePom
    {
        public XyzProductOverviewPage(IWebDriver driver) : base(driver) { }

        //Lokatori za elemente na stranici proizvoda:
        By productTitle = By.XPath("//h1[@class='product-name' and contains(text(), 'Crni muški kačket')]");
        By productPrice = By.CssSelector("[data-product-id='27389']");
        By addToCartButton = By.Id("product-addtocart-button");
        By miniCartButton = By.CssSelector("div.minicart-wrapper a.action.showcart");
        By goToCartButton = By.CssSelector("a.viewcart");

        //Metoda za dohvatanje naslova proizvoda
        public string GetProductTitle()
        {
            return driver.FindElement(productTitle).Text;
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
    }
}