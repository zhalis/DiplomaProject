using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Dashboard;

public class DashboardPage : BasePage
{
    private const string DashboardElementsTitlePattern = "//*[text()='{0}']";

    private const string DashboardHeader = "Dashboard";

    private const string TimeAtWorkTitle = "Time at Work";

    private const string MyActionsTitle = "My Actions";

    private const string QuickLaunchTitle = "Quick Launch";

    private const string BuzzLatestPostsTitle = "Buzz Latest Posts";

    private const string EmployeesOnLeaveTodayTitle = "Employees on Leave Today";

    private const string EmployeeDistributionBySubUnitTitle = "Employee Distribution by Sub Unit";

    private const string EmployeeDistributionByLocationTitle = "Employee Distribution by Location";

    public bool IsDashboardHeaderDisplayed() => IsHeaderDisplayed(DashboardHeader);

    public bool IsTimeAtWorkTitleDisplayed() => GetTitleElement(TimeAtWorkTitle).IsDisplayed();

    public bool IsMyActionsTitleDisplayed() => GetTitleElement(MyActionsTitle).IsDisplayed();

    public bool IsQuickLaunchTitleDisplayed() => GetTitleElement(QuickLaunchTitle).IsDisplayed();

    public bool IsBuzzLatestPostsTitleDisplayed() => GetTitleElement(BuzzLatestPostsTitle).IsDisplayed();

    public bool IsEmployeesOnLeaveTodayTitleDisplayed() => GetTitleElement(EmployeesOnLeaveTodayTitle).IsDisplayed();

    public bool IsEmployeeDistributionBySubUnitTitleDisplayed() =>
        GetTitleElement(EmployeeDistributionBySubUnitTitle).IsDisplayed();

    public bool IsEmployeeDistributionByLocationTitleDisplayed() =>
        GetTitleElement(EmployeeDistributionByLocationTitle).IsDisplayed();

    private Element GetTitleElement(string title) => Element.ByXPath(DashboardElementsTitlePattern, title);
}