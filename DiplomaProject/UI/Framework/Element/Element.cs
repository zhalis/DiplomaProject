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
    private readonly IWebDriver _driver;
    private IWebElement? _element;

    private Element(By by)
    {
        _by = by;
        _driver = WebDriverSingleton.GetDriver;
    }

    private IWebElement GetElement => _element ??= WaitForPresence();

    public static Element ByXPath(string xPath, params object[] parameters) =>
        new(By.XPath(string.Format(xPath, parameters)));

    public void Click() => WaitForClickable().Click();

    public void SendKeys(string value) => WaitForVisibility().SendKeys(value);

    public void ClearInputUsingBackspace() =>
        GetAttributeValue(Attributes.ValueCssProperty).ToList()
            .ForEach(_ => GetElement.SendKeys(Keys.Backspace));

    public string GetAttributeValue(string attribute) => GetElement.GetAttribute(attribute);

    public bool IsDisplayed() => WaitForVisibility().Displayed;

    public bool IsSelected() => GetElement.Selected;

    public IWebElement WaitForVisibility() =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultTimeOutInSeconds))
            .Until(ExpectedConditions.ElementIsVisible(_by));

    public void WaitForInvisibility() =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultTimeOutInSeconds))
            .Until(ExpectedConditions.InvisibilityOfElementLocated(_by));

    public IEnumerable<IWebElement> WaitForPresenceOfAllElements() =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultTimeOutInSeconds))
            .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_by));

    private IWebElement WaitForClickable() =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultTimeOutInSeconds))
            .Until(ExpectedConditions.ElementToBeClickable(_by));

    private IWebElement WaitForPresence() =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultTimeOutInSeconds))
            .Until(ExpectedConditions.ElementExists(_by));
}