using MilosV_UiAutomation.BasePom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MilosV_UiAutomation.Pages
{
    public class XyzLoginPage : XyzBasePom
    {
        public XyzLoginPage(IWebDriver driver) : base(driver) { }

        // Lokatori za elemente na stranici:
        By successMessage = By.XPath("//*[@data-ui-id='message-success']");
        By emailInput = By.Id("email");
        By passwordInput = By.Id("pass");
        By loginButton = By.Id("send2");

        //User kredencijali:
        private string email = "vlahovic.milos911@gmail.com";
        private string password = "Test123@";


        // Metoda koja proverava da li je ispravna poruka prikazana nakon kreiranja korisnika
        public bool IsUserCreationMessageVisible()
        {
            WaitUntilVisible(successMessage);
            return driver.FindElement(successMessage).Displayed;
        }
       
        //Login metoda
        public XyzLandingPage Login()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.FindElement(emailInput).SendKeys(email);
            IWebElement passwordField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(passwordInput));
            passwordField.SendKeys(password);
            driver.FindElement(loginButton).Click();
            return new XyzLandingPage(driver); 
        }
    }
}