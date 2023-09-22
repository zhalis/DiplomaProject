using Allure.Net.Commons;
using DiplomaProject.UI.Framework;
using DiplomaProject.UI.Framework.WebDriver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

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
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenShot = ((ITakesScreenshot)WebDriverSingleton.GetDriver).GetScreenshot().AsByteArray;
            AllureLifecycle.Instance.AddAttachment(TestContext.CurrentContext.Test.Name, "image/png", screenShot);
        }
        WebDriverSingleton.StopBrowser();
    }
}