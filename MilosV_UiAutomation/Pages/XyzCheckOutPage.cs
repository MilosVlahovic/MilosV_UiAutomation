using OpenQA.Selenium;
using MilosV_UiAutomation.BasePom;

namespace MilosV_UiAutomation.Pages
{
    public class XyzCheckOutPage : XyzBasePom
    {
        public XyzCheckOutPage(IWebDriver driver) : base(driver) { }

        //Lokatori za elemente na Checkout stranici
        By company = By.XPath("//input[@name='company']");
        By adress = By.XPath("//input[@name='street[0]']");
        By city = By.XPath("//input[@name='city']");
        By postcode = By.XPath("//input[@name='postcode']");
        By phoneNumber = By.XPath("//input[@name='telephone']");
        By nextButton = By.XPath("//button[@data-role='opc-continue']");

        //Podaci za Checkout
        string companyInput = "Nul Tien"; 
        string adressInput = "Ulica Testera 1";
        string cityInput = "Beograd";
        string postcodeInput = "11000";
        string phoneNumberInput = "+381638815363";

        //Metoda za unos podataka na Checkout stranici
        public XyzPaymentPage FillCheckoutForm()
        {
            WaitUntilVisible(company);
            driver.FindElement(company).SendKeys(companyInput);
            driver.FindElement(adress).SendKeys(adressInput);
            driver.FindElement(city).SendKeys(cityInput);
            driver.FindElement(postcode).SendKeys(postcodeInput);
            driver.FindElement(phoneNumber).SendKeys(phoneNumberInput);
            driver.FindElement(nextButton).Click();
            return new XyzPaymentPage(driver);

        }
    }
}