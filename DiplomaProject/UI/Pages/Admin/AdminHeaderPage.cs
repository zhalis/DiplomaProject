using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.Admin;

public class AdminHeaderPage : BasePage
{
    private const string AdminTitle = "Admin";
    private const string NationalitiesLinkName = "Nationalities";
    private const string UsersLinkName = "Users";
    private const string JobTitlesOptionInDropDown = "Job Titles";
    private readonly HeaderDropDown _userManagementDropDown = HeaderDropDown.ByLabel("User Management ");
    private readonly HeaderDropDown _jobDropDown = HeaderDropDown.ByLabel("Job ");

    public bool IsAdminTitleDisplayed() => IsHeaderDisplayed(AdminTitle);

    public bool IsJobTitlesLinkDisplayed() => _jobDropDown.IsOptionDisplayedInDropDown(JobTitlesOptionInDropDown);

    public bool IsDropDownMenuDisplayed() => HeaderDropDown.IsDropDownMenuDisplayed();

    public bool IsUsersLinkDisplayed() => _userManagementDropDown.IsOptionDisplayedInDropDown(UsersLinkName);

    public void ClickUserManagementDropDownMenu() => _userManagementDropDown.OpenDropDownMenu();

    public UsersPage OpenUsersPage()
    {
        _userManagementDropDown.SelectValue(UsersLinkName);

        return new UsersPage();
    }

    public AdminHeaderPage ClickJobDropDownMenu() =>
        ExecuteInChain<AdminHeaderPage>(() => _jobDropDown.OpenDropDownMenu());

    public JobTitlesPage ClickJobTitlesInDropDownMenu()
    {
        _jobDropDown.SelectOptionInOpenedMenu(JobTitlesOptionInDropDown);

        return new JobTitlesPage();
    }

    public JobTitlesPage OpenJobTitlesPage()
    {
        _jobDropDown.SelectValue(JobTitlesOptionInDropDown);

        return new JobTitlesPage();
    }

    public NationalitiesPage ClickNationalitiesButton()
    {
        ClickLinkByName(NationalitiesLinkName);

        return new NationalitiesPage();
    }
}