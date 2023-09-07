using DiplomaProject.UI.Framework;
using DiplomaProject.UI.Framework.WebDriver;
using NUnit.Framework;

namespace Tests;

public abstract class BaseTest
{
    [SetUp]
    public void OpenBrowserAndNavigateToUrl()
    {
        WebDriverSingleton.GetDriver.Navigate().GoToUrl(Properties.OrangeHrmUrl);
    }

    [TearDown]
    public void CloseBrowse()
    {
        WebDriverSingleton.StopBrowser();
    }
}