using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Services;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Tests;

[TestFixture]
[AllureNUnit]
public class SidePanelTest : BaseTest
{
    private const string Keyword = "fo";

    [SetUp]
    public void LoginAsAdmin() => new LoginService().LoginAsAdmin();

    [Test]
    public void Scenario4ValidateSearchFunctionality()
    {
        var sidePanelPage = new SidePanelPage()
            .EnterSearchValue(Keyword);
        Assert.AreEqual(Keyword, sidePanelPage.GetSearchBarInputValue(), "Keyword isn't entered");
        Assert.IsTrue(sidePanelPage.GetSideMenuItems()
            .All(item => item.Contains(Keyword)), "Result doesn't match the entered keyword");
    }

    [TearDown]
    public void Logout() => new LogoutService().Logout();
}