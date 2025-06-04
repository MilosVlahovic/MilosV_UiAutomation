using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace MilosV_UiAutomation.BasePom
{
    public class XyzBasePom
    {

        protected readonly IWebDriver driver; 
        public XyzBasePom(IWebDriver driver) // konstruktor koji prima IWebDriver, sto omogucava da se driver koristi u svim stranicama.
        {
            this.driver = driver;
        }

        // metoda koja ceka da element postane vidljiv
        protected void WaitUntilVisible(By locator, int seconds = 5) 
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }
        /// Metoda koja odbija kolacice na stranici, nasao sam na StackOverflow-u, nisam sam osmislio :)
        public void RejectCookiePopup()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string script = @"
            const shadowHost = document.querySelector('#cmpwrapper');
            if (!shadowHost || !shadowHost.shadowRoot) return false;

            const shadowRoot = shadowHost.shadowRoot;
            const button = shadowRoot.querySelector('a.cmpboxbtnno.cmptxt_btn_no');
            if (!button) return false;

            button.click();
            return true;
        ";
                bool clicked = (bool)js.ExecuteScript(script);
                if (!clicked)
                    Console.WriteLine("Button not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while rejecting:" + ex.Message);
            }
        }
    }
}