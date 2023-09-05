using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Pages.Admin;
using DiplomaProject.UI.Pages.Dashboard;
using DiplomaProject.UI.Pages.Leave;
using DiplomaProject.UI.Pages.Performance;
using DiplomaProject.UI.Pages.PIM;
using DiplomaProject.UI.Pages.Recruitment;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages;

public class SidePanelPage : BasePage
{
    private readonly Element _brandBanner = Element.ByXPath("//*[@alt='client brand banner']");
    private readonly Element _pimButton = Element.ByXPath(SpanByTextPattern, "PIM");
    private readonly Element _adminButton = Element.ByXPath(SpanByTextPattern, "Admin");
    private readonly Element _leaveButton = Element.ByXPath(SpanByTextPattern, "Leave");
    private readonly Element _performanceButton = Element.ByXPath(SpanByTextPattern, "Performance");
    private readonly Element _recruitmentButton = Element.ByXPath(SpanByTextPattern, "Recruitment");
    private readonly Element _dashboardButton = Element.ByXPath(SpanByTextPattern, "Dashboard");
    private readonly Element _searchInput = Element.ByXPath(InputByPlaceholderPattern, "Search");
    private readonly Element _sideMenuItem = Element.ByXPath("//*[contains(@class,'oxd-main-menu-item--name')]");

    public bool IsBrandBannerDisplayed() => _brandBanner.IsDisplayed();

    public string GetSearchBarInputValue() => _searchInput.GetAttributeValue(Attributes.ValueCssProperty);

    public List<string> GetSideMenuItems() =>
        _sideMenuItem.WaitForPresenceOfAllElements().Select(title => title.Text).ToList();

    public PimHeaderPage ClickPimButton()
    {
        _pimButton.Click();

        return new PimHeaderPage();
    }

    public AdminHeaderPage ClickAdminButton()
    {
        _adminButton.Click();

        return new AdminHeaderPage();
    }

    public LeaveHeaderPage ClickLeaveButton()
    {
        _leaveButton.Click();

        return new LeaveHeaderPage();
    }

    public DashboardPage ClickDashboardButton()
    {
        _dashboardButton.Click();

        return new DashboardPage();
    }

    public PerformanceHeaderPage ClickPerformanceButton()
    {
        _performanceButton.Click();

        return new PerformanceHeaderPage();
    }

    public RecruitmentHeaderPage ClickRecruitmentButton()
    {
        _recruitmentButton.Click();

        return new RecruitmentHeaderPage();
    }

    public SidePanelPage EnterSearchValue(string searchValue)
    {
        _searchInput.SendKeys(searchValue);

        return this;
    }
}