using DiplomaProject.UI.Utils;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using static DiplomaProject.UI.Framework.WebDriver.BrowserName;

namespace DiplomaProject.UI.Framework.WebDriver;

public static class WebDriverFactory
{
    private const int DefaultTimeOutInSeconds = 20;
    private const int ShortTimeoutInSeconds = 2;

    public static OpenQA.Selenium.WebDriver GetWebDriver(BrowserName browserName) =>
        browserName switch
        {
            Chrome => CreateDriver(() => new ChromeDriver()),
            Firefox => CreateDriver(() => new FirefoxDriver()),
            Edge => CreateDriver(() => new EdgeDriver()),
            _ => throw new ArgumentException($"Unsupported browser name: {browserName.ToString()}")
        };

    private static T CreateDriver<T>(Supplier<T> driverSupplier) where T : OpenQA.Selenium.WebDriver
    {
        var driver = driverSupplier.Invoke();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ShortTimeoutInSeconds);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(DefaultTimeOutInSeconds);

        return driver;
    }
}