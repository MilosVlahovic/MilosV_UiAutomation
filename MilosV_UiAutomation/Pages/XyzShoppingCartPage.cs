using OpenQA.Selenium;
using MilosV_UiAutomation.BasePom;
namespace MilosV_UiAutomation.Pages
{
    public class XyzShoppingCartPage : XyzBasePom
    {
        public XyzShoppingCartPage(IWebDriver driver) : base(driver) { }

        //Lokatori za elemente na stranici korpe:
        By checkoutButton = By.CssSelector("button[title='Nastavite na plaćanje']");
        By productInCart = By.XPath("//a[contains(normalize-space(text()), 'Crni muški kačket')]");

        //Metoda koja proverava da li je proizvod u korpi
        public bool IsProductInCart()
        {
            WaitUntilVisible(productInCart);
            return driver.FindElement(productInCart).Displayed;
        }

        //Metoda za klik na dugme "Nastavite na placanje"
        public XyzCheckOutPage ClickCheckoutButton()
        {
            WaitUntilVisible(checkoutButton);
            driver.FindElement(checkoutButton).Click();
            return new XyzCheckOutPage(driver);
        }

    }
}