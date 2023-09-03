using DiplomaProject.UI.Framework.WebDriver;
using DiplomaProject.UI.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DiplomaProject.UI.Framework.Element;

public class Element
{
    private const int DefaultTimeOutInSeconds = 20;
    private readonly By _by;

    private Element(By by)
    {
        _by = by;
    }

    public static Element ByXPath(string xPath, params object[] parameters) =>
        new(By.XPath(string.Format(xPath, parameters)));

    public void Click() =>
        WaitForClickable().Click();

    public void Type(string value) => WaitForVisibility().SendKeys(value);

    public void ClearInputUsingBackspace() =>
        GetAttributeValue(Attributes.ValueCssProperty).ToList()
            .ForEach(_ => WebDriverSingleton.GetDriver.FindElement(_by).SendKeys(Keys.Backspace));

    public string GetAttributeValue(string attribute) => 
        WebDriverSingleton.GetDriver.FindElement(_by).GetAttribute(attribute);

    public bool IsDisplayed() => WaitForVisibility().Displayed;

    private IWebElement WaitForClickable() =>
        new WebDriverWait(WebDriverSingleton.GetDriver, TimeSpan.FromSeconds(DefaultTimeOutInSeconds))
            .Until(ExpectedConditions.ElementToBeClickable(_by));

    public IWebElement WaitForVisibility() =>
        new WebDriverWait(WebDriverSingleton.GetDriver, TimeSpan.FromSeconds(DefaultTimeOutInSeconds))
            .Until(ExpectedConditions.ElementIsVisible(_by));

    public void WaitForInvisibility() =>
        new WebDriverWait(WebDriverSingleton.GetDriver, TimeSpan.FromSeconds(DefaultTimeOutInSeconds))
            .Until(ExpectedConditions.InvisibilityOfElementLocated(_by));

    public IEnumerable<IWebElement> WaitForPresenceOfAllElements() =>
        new WebDriverWait(WebDriverSingleton.GetDriver, TimeSpan.FromSeconds(DefaultTimeOutInSeconds))
            .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_by));
}