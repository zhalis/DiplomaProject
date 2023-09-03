using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Admin;

public class AdminHeaderPage : BasePage
{
    private readonly Element _nationalitiesButton = Element.ByXPath(LinkByTextPattern, "Nationalities");

    private readonly Element _adminTitle = Element.ByXPath(HeaderByTextPattern, "Admin");

    private readonly Element _dropDownMenu = Element.ByXPath("//ul[@class='oxd-dropdown-menu']");

    private readonly Element _usersLinkInDropDownMenu = Element.ByXPath(LinkByTextPattern, "Users");

    private readonly Element _userManagementDropDownButton =
        Element.ByXPath(SpanByTextPattern, "User Management ");

    private readonly Element _jobDropDownButton =
        Element.ByXPath(SpanByTextPattern, "Job ");

    private readonly Element _jobTitlesLinkInDropDown =
        Element.ByXPath("//ul[@class='oxd-dropdown-menu']//a[text()='Job Titles']");

    public bool IsAdminTitleDisplayed() => _adminTitle.IsDisplayed();

    public bool IsJobTitlesLinkDisplayed() => _jobTitlesLinkInDropDown.IsDisplayed();

    public bool IsDropDownMenuDisplayed() => _dropDownMenu.IsDisplayed();

    public bool IsUsersLinkDisplayed() => _usersLinkInDropDownMenu.IsDisplayed();

    public AdminHeaderPage ClickUserManagementDropDownMenu()
    {
        _userManagementDropDownButton.Click();

        return this;
    }

    public UsersPage ClickUsersLink()
    {
        _usersLinkInDropDownMenu.Click();

        return new UsersPage();
    }

    public AdminHeaderPage ClickJobDropDownMenu()
    {
        _jobDropDownButton.Click();

        return this;
    }

    public JobTitlesPage ClickJobTitlesInDropDownMenu()
    {
        _jobTitlesLinkInDropDown.Click();

        return new JobTitlesPage();
    }

    public NationalitiesPage ClickNationalitiesButton()
    {
        _nationalitiesButton.Click();

        return new NationalitiesPage();
    }

    public AdminHeaderPage WaitDropDownMenuVisibility()
    {
        _dropDownMenu.WaitForVisibility();

        return this;
    }
}