using MilosV_UiAutomation.BasePom;
using MilosV_UiAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

public class XyzSearchResultPage : XyzBasePom
{
    public XyzSearchResultPage(IWebDriver driver) : base(driver) { }

    //Lokatori za elemente na stranici:
    By productItem = By.XPath("//a[contains(normalize-space(text()), 'Crni muški kačket')]");
    By sortingDdm = By.CssSelector("#catalog-sorter");
    
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