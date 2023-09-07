using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.Admin;
using DiplomaProject.UI.Services;
using NUnit.Framework;

namespace Tests.AdminPage;

[TestFixture]
public class SearchAdminTest : BaseTest
{
    private const string FirstName = "Alexey";
    private const string LastName = "Ivanov";
    private const string UserRole = "ESS";
    private const string Status = "Enabled";
    private const string Username = "Alexey";
    private const string Password = "ivanov123";
    private string _employeeId;
    private UsersPage _usersPage;

    [SetUp]
    public void LoginAsAdminCreateUserAndNavigateToUsersPage()
    {
        new LoginService().LoginAsAdmin()
            .ClickPimButton()
            .ClickAddEmployeeButton();
        _employeeId = new EmployeeService()
            .CreateEmployee(FirstName, LastName);
        new SidePanelPage()
            .ClickAdminButton()
            .OpenUsersPage()
            .ClickAddButton();
        _usersPage = new AddUserService()
            .CreateNewUser(UserRole, FirstName, Status, Username, Password);
        _usersPage.WaitLoadingSpinnerInvisibility();
    }

    [Test]
    public void Scenario15SearchAdmin()
    {
        Assert.IsTrue(_usersPage.IsUserListDisplayed(), "Users list isn't displayed");
        _usersPage
            .EnterUsername(Username);
        Assert.AreEqual(Username, _usersPage.GetUsernameInputValue(), "Username isn't entered");
        _usersPage
            .ClickSearchButton()
            .WaitSearchResultByUsername();
        Assert.IsTrue(_usersPage.GetFoundUsernames()
            .All(username => username.Contains(Username)), "Search results aren't displayed");
        var editUserPage = _usersPage
            .ClickEditButtonByUsername(Username);
        Assert.IsTrue(editUserPage.IsEditUserTitleDisplayed(), "Edit user page isn't opened");
    }

    [TearDown]
    public void DeleteUserAndEmployeeAndLogout()
    {
        new AdminHeaderPage()
            .OpenUsersPage()
            .WaitLoadingSpinnerInvisibility();
        new UsersPage()
            .EnterUsername(Username)
            .ClickSearchButton()
            .WaitSearchResultByUsername()
            .ClickTrashBinButtonByUsername(Username)
            .WaitPopUpVisibility()
            .ClickYesButton();
        new SidePanelPage()
            .ClickPimButton()
            .ClickEmployeeListButton();
        new EmployeeService()
            .DeleteEmployee(_employeeId);
        new LogoutService().Logout();
    }
}