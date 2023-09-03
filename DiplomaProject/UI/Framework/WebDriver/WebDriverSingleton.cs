using OpenQA.Selenium;

namespace DiplomaProject.UI.Framework.WebDriver;

public static class WebDriverSingleton
{
    private static readonly ThreadLocal<IWebDriver?> Driver = new();

    public static IWebDriver GetDriver => Driver.Value ??= WebDriverFactory.GetWebDriver(Properties.Browser);

    public static void StopBrowser()
    {
        GetDriver.Quit();
        Driver.Value = null;
    }
}