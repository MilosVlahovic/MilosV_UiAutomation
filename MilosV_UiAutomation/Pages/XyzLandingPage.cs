using OpenQA.Selenium;
using MilosV_UiAutomation.BasePom;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.DevTools.V135.Network;


namespace MilosV_UiAutomation.Pages
{
    public class XyzLandingPage : XyzBasePom 
    {
        public XyzLandingPage(IWebDriver driver) : base(driver) { }

        //Url stranice:
        private readonly string url = "https://xyzfashionstore.com/rs/";

        //Lokatori za elemente na stranici:
        By guestButton = By.XPath("//button[@class= 'dropdown-toggle guest']");
        By createNewUserButton = By.XPath("//a[text()='Kreirajte korisnički nalog']");
        By loginButton = By.XPath("//a[text()='Prijava']");
        By searchField = By.Id("search");
        By searchButton = By.XPath("//button[@class='action-search']");

        //Metoda za navigaciju na pocetnu stranicu
        public void NavigateToHomePage()  
        {
            driver.Navigate().GoToUrl(url);
            
        }

        //Metoda za navigaciju na stranicu za kreiranje novog korisnika
        public XyzUserCreationPage NavigateToCreateNewUser()
        {
            Actions actions = new Actions(driver); // Kreiranje objekta Actions za simulaciju korisnickih akcija
            actions.MoveToElement(driver.FindElement(guestButton)).Perform(); //Hover na dugme guest
            driver.FindElement(createNewUserButton).Click();
            return new XyzUserCreationPage(driver);
        }

        //Metoda za navigaciju na login page.
        
        public XyzLoginPage NavigateToLoginPage()
        {
            Actions actions = new Actions(driver); 
            actions.MoveToElement(driver.FindElement(guestButton)).Perform();
            driver.FindElement(loginButton).Click();
            return new XyzLoginPage(driver);
        }

        //Metoda za pretragu proizvoda na pocetnoj stranici
        public XyzSearchResultPage SearchForProduct(string searchValue) { 
      
            driver.FindElement(searchField).SendKeys(searchValue);
            driver.FindElement(searchButton).Click();
            return new XyzSearchResultPage(driver);

        }

    }
}