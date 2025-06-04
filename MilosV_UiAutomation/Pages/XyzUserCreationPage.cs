using MilosV_UiAutomation.BasePom;
using MilosV_UiAutomation.Pages;
using OpenQA.Selenium;

public class XyzUserCreationPage : XyzBasePom
{
    public XyzUserCreationPage(IWebDriver driver) : base(driver) { }

    // Lokatori za elemente na stranici za kreiranje korisnika:
     By firstNameInput = By.Id("firstname");
     By lastNameInput = By.Id("lastname");
     By emailInput = By.Id("email_address");
     By passwordInput = By.Id("password");
     By passwordConfirmationInput = By.Id("password-confirmation");
     By privacyCheckbox = By.XPath("//input[@title='Privacy Checkbox']");
     By termsCheckbox = By.XPath("//input[@title='Agree']");
     By createAccountButton = By.XPath("//button[@title='Kreirajte korisnički nalog']");

    // Podaci za kreiranje korisnika:
     string firstName = "Milos";
     string lastName = "Vlahovic";
     string email = $"testEmail{new Random().Next(100, 999)}@gmail.com";
     string password = "Test123@";

    //Metoda koja unosi podatke korisnika i kreira nalog:
    public XyzLoginPage InsertUserDetails()
    {
        driver.FindElement(firstNameInput).SendKeys(firstName);
        driver.FindElement(lastNameInput).SendKeys(lastName);
        driver.FindElement(emailInput).SendKeys(email);
        driver.FindElement(passwordInput).SendKeys(password);
        driver.FindElement(passwordConfirmationInput).SendKeys(password);
        driver.FindElement(privacyCheckbox).Click();
        driver.FindElement(termsCheckbox).Click();
        driver.FindElement(createAccountButton).Click();
        return new XyzLoginPage(driver);
    }
}