using MilosV_UiAutomation.BasePom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MilosV_UiAutomation.Pages
{
    public class XyzWalletsPage : XyzBasePom
    {
        public XyzWalletsPage(IWebDriver driver) : base(driver) { }


        By sortingDdm = By.CssSelector("#catalog-sorter");
        By productItem = By.XPath("//a[contains(text(), 'BOSS - Monogram muška futrola za kartice')]");


        //Metoda za sortiranje search rezultata.
        public void SortingProducts(string option)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement dropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(sortingDdm));

            SelectElement select = new SelectElement(dropdown);
            select.SelectByText(option);
        }

        //Metoda za select artikla
        public XyzProductOverviewPage SelectProduct()
        {
            WaitUntilVisible(productItem);
            driver.FindElement(productItem).Click();
            return new XyzProductOverviewPage(driver);
        }

    }

       
    }
