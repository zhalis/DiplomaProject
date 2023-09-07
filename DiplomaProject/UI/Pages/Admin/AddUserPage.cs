using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.Admin;

public class AddUserPage : BasePage
{
    private readonly DropDown _userRoleDropDown = SelectDropDown.ByLabel("User Role");
    private readonly DropDown _statusDropDown = SelectDropDown.ByLabel("Status");
    private readonly DropDown _employeeNameDropDown = AutocompleteDropDown.ByLabel("Employee Name");
    private readonly Element _usernameInput = Element.ByXPath(InputByLabelNamePattern, "Username");
    private readonly Element _passwordInput = Element.ByXPath(InputByLabelNamePattern, "Password");
    private readonly Element _confirmPasswordInput = Element.ByXPath(InputByLabelNamePattern, "Confirm Password");

    public AddUserPage SelectEmployeeName(string employeeName) =>
        ExecuteInChain<AddUserPage>(() => _employeeNameDropDown.SelectValue(employeeName));

    public AddUserPage EnterUsername(string username) =>
        ExecuteInChain<AddUserPage>(() => _usernameInput.SendKeys(username));

    public AddUserPage EnterPassword(string password) =>
        ExecuteInChain<AddUserPage>(() => _passwordInput.SendKeys(password));

    public AddUserPage EnterConfirmPassword(string password) =>
        ExecuteInChain<AddUserPage>(() => _confirmPasswordInput.SendKeys(password));

    public AddUserPage SelectUserRole(string userRole) =>
        ExecuteInChain<AddUserPage>(() => _userRoleDropDown.SelectValue(userRole));

    public AddUserPage SelectStatus(string status) =>
        ExecuteInChain<AddUserPage>(() => _statusDropDown.SelectValue(status));

    public UsersPage ClickSaveButton()
    {
        ButtonTypeSubmit.Click();

        return new UsersPage();
    }
}