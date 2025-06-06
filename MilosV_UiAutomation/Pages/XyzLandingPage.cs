using MilosV_UiAutomation.BasePom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;



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
        By Tab = By.XPath("//a[text()='Najprodavanije']");
        By productItem = By.CssSelector("a.product-item-photo[title*='Boggi Milano - Lanena muška košulja']");
        By mensMenu = By.XPath("//a[@href='/rs/muskarci/' and contains(@class,'nav-anchor')]");
        By Category = By.XPath("//a[contains(@href, '/rs/muskarci/aksesoari/') and span[normalize-space()='Aksesoari']]");
        By CategoryItem = By.XPath("//a[contains(@href, '/rs/muskarci/aksesoari/novcanici')]");
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
        public XyzSearchResultPage SearchForProduct(string searchValue)
        {

            driver.FindElement(searchField).SendKeys(searchValue);
            driver.FindElement(searchButton).Click();
            return new XyzSearchResultPage(driver);
        }

        //Metoda za select taba 'Najprodavanije'.
        public void SelectTab()
        {
            WaitUntilVisible(Tab);
            driver.FindElement(Tab).Click();

        }

        //Metoda za select producta
        public XyzProductOverviewPage SelectProduct()
        {
            IWebElement element = driver.FindElement(productItem);

            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();  // Skroluje do elementa

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

            element.Click();

            return new XyzProductOverviewPage(driver);
        }

        //Metoda za selectovanje kategorije proizvoda iz headera.
        public XyzWalletsPage SelectHeaderProductCategory()
        {
            Actions actions = new Actions(driver);
            IWebElement muskarci = driver.FindElement(mensMenu);
            actions.MoveToElement(muskarci).Perform();
            IWebElement aksesoariElement = driver.FindElement(Category);
            actions.MoveToElement(aksesoariElement).Perform();
            driver.FindElement(CategoryItem).Click();
            return new XyzWalletsPage(driver);
        }




    }
}