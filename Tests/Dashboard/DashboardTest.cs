using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Services;
using NUnit.Framework;

namespace Tests.Dashboard;

public class DashboardTest : BaseTest
{
    [SetUp]
    public void LoginAsAdmin() => new LoginService().LoginAsAdmin();

    [Test]
    public void Scenario8ValidateDashboardAccess()
    {
        var dashboardPage = new SidePanelPage()
            .ClickDashboardButton();
        Assert.IsTrue(dashboardPage.IsDashboardHeaderDisplayed(), "Dashboard page isn't displayed");
        Assert.IsTrue(dashboardPage.IsTimeAtWorkTitleDisplayed(),
            GetDashboardElementAbsenceMessage("Time at Work"));
        Assert.IsTrue(dashboardPage.IsMyActionsTitleDisplayed(),
            GetDashboardElementAbsenceMessage("My Actions"));
        Assert.IsTrue(dashboardPage.IsQuickLaunchTitleDisplayed(),
            GetDashboardElementAbsenceMessage("Quick Launch"));
        Assert.IsTrue(dashboardPage.IsBuzzLatestPostsTitleDisplayed(),
            GetDashboardElementAbsenceMessage("Buzz Latest Posts"));
        Assert.IsTrue(dashboardPage.IsEmployeesOnLeaveTodayTitleDisplayed(),
            GetDashboardElementAbsenceMessage("Employees on Leave Today"));
        Assert.IsTrue(dashboardPage.IsEmployeeDistributionBySubUnitTitleDisplayed(),
            GetDashboardElementAbsenceMessage("Employee Distribution by Sub Unit"));
        Assert.IsTrue(dashboardPage.IsEmployeeDistributionByLocationTitleDisplayed(),
            GetDashboardElementAbsenceMessage("Employee Distribution by Location"));
    }

    private static string GetDashboardElementAbsenceMessage(string dashboardElementName) =>
        $"Dashboard's element '{dashboardElementName}' isn't present";
}