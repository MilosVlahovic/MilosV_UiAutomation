using OpenQA.Selenium;
using MilosV_UiAutomation.BasePom;

namespace MilosV_UiAutomation.Pages
{
    public class XyzPaymentPage : XyzBasePom
    {
        public XyzPaymentPage(IWebDriver driver) : base(driver){}

        //Lokatori za placanje karticom
        By cardNumber = By.Id("chcybersource_cc_number");
        By cardExpiryMonth = By.Id("chcybersource_expiration");
        By cardExpiryYear = By.Id("chcybersource_expiration_yr");
        By cardCvv = By.Id("chcybersource_cc_cid");
        By agreeTermsCheckbox = By.Id("agreement_chcybersource_1");

        //Podaci za karticu
        String cardNumberValue = "4539 1488 0343 6467";
        String cardExpiryMonthValue = "12";
        String cardExpiryYearValue = "2027";
        String cardCvvValue = "315";


        //Metoda za izbor načina plaćanja: karticom 
        By paymentMethodCard = By.Id("chcybersource");
        public void SelectPaymentMethodCard()
        {
            WaitUntilVisible(paymentMethodCard);
            driver.FindElement(paymentMethodCard).Click(); 
        }

        //Metoda za popunjavanje podataka za karticu
        public void FillCardDetails()
        {
            driver.FindElement(cardNumber).SendKeys(cardNumberValue);
            driver.FindElement(cardExpiryMonth).SendKeys(cardExpiryMonthValue);
            driver.FindElement(cardExpiryYear).SendKeys(cardExpiryYearValue);
            driver.FindElement(cardCvv).SendKeys(cardCvvValue);
        }

        //Metoda za potvrdu uslova korišćenja
        public void AgreeToTerms()
        {
            WaitUntilVisible(agreeTermsCheckbox);
            driver.FindElement(agreeTermsCheckbox).Click();
        }


    }
}