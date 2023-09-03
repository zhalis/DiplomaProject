using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Dashboard;

public class DashboardPage : BasePage
{
    private const string DashboardElementsTitlePattern = "//p[text()='{0}']";

    private readonly Element _dashboardHeader = Element.ByXPath(HeaderByTextPattern, "Dashboard");

    private readonly Element _timeAtWorkTitle =
        Element.ByXPath(DashboardElementsTitlePattern, "Time at Work");

    private readonly Element _myActionsTitle =
        Element.ByXPath(DashboardElementsTitlePattern, "My Actions");

    private readonly Element _quickLaunchTitle =
        Element.ByXPath(DashboardElementsTitlePattern, "Quick Launch");

    private readonly Element _buzzLatestPostsTitle =
        Element.ByXPath(DashboardElementsTitlePattern, "Buzz Latest Posts");

    private readonly Element _employeesOnLeaveTodayTitle =
        Element.ByXPath(DashboardElementsTitlePattern, "Employees on Leave Today");

    private readonly Element _employeeDistributionBySubUnitTitle =
        Element.ByXPath(DashboardElementsTitlePattern, "Employee Distribution by Sub Unit");

    private readonly Element _employeeDistributionByLocationTitle =
        Element.ByXPath(DashboardElementsTitlePattern, "Employee Distribution by Location");

    public bool IsDashboardHeaderDisplayed() => _dashboardHeader.IsDisplayed();

    public bool IsTimeAtWorkTitleDisplayed() => _timeAtWorkTitle.IsDisplayed();

    public bool IsMyActionsTitleDisplayed() => _myActionsTitle.IsDisplayed();

    public bool IsQuickLaunchTitleDisplayed() => _quickLaunchTitle.IsDisplayed();

    public bool IsBuzzLatestPostsTitleDisplayed() => _buzzLatestPostsTitle.IsDisplayed();

    public bool IsEmployeesOnLeaveTodayTitleDisplayed() => _employeesOnLeaveTodayTitle.IsDisplayed();

    public bool IsEmployeeDistributionBySubUnitTitleDisplayed() => _employeeDistributionBySubUnitTitle.IsDisplayed();

    public bool IsEmployeeDistributionByLocationTitleDisplayed() => _employeeDistributionByLocationTitle.IsDisplayed();
}