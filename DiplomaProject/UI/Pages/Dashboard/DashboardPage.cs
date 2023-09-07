using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Dashboard;

public class DashboardPage : BasePage
{
    private const string DashboardElementsTitlePattern = "//*[text()='{0}']";

    public bool IsDashboardHeaderDisplayed() => IsHeaderDisplayed("Dashboard");

    public bool IsTimeAtWorkTitleDisplayed() => GetTitleElement("Time at Work").IsDisplayed();

    public bool IsMyActionsTitleDisplayed() => GetTitleElement("My Actions").IsDisplayed();

    public bool IsQuickLaunchTitleDisplayed() => GetTitleElement("Quick Launch").IsDisplayed();

    public bool IsBuzzLatestPostsTitleDisplayed() => GetTitleElement("Buzz Latest Posts").IsDisplayed();

    public bool IsEmployeesOnLeaveTodayTitleDisplayed() => GetTitleElement("Employees on Leave Today").IsDisplayed();

    public bool IsEmployeeDistributionBySubUnitTitleDisplayed() =>
        GetTitleElement("Employee Distribution by Sub Unit").IsDisplayed();

    public bool IsEmployeeDistributionByLocationTitleDisplayed() =>
        GetTitleElement("Employee Distribution by Location").IsDisplayed();

    private Element GetTitleElement(string title) => Element.ByXPath(DashboardElementsTitlePattern, title);
}