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

    public AddUserPage SelectEmployeeName(string employeeName)
    {
        _employeeNameDropDown.SelectValue(employeeName);

        return this;
    }

    public AddUserPage EnterUsername(string username)
    {
        _usernameInput.SendKeys(username);

        return this;
    }

    public AddUserPage EnterPassword(string password)
    {
        _passwordInput.SendKeys(password);

        return this;
    }

    public AddUserPage EnterConfirmPassword(string password)
    {
        _confirmPasswordInput.SendKeys(password);

        return this;
    }

    public AddUserPage SelectUserRole(string userRole)
    {
        _userRoleDropDown.SelectValue(userRole);

        return this;
    }

    public AddUserPage SelectStatus(string status)
    {
        _statusDropDown.SelectValue(status);

        return this;
    }

    public UsersPage ClickSaveButton()
    {
        ButtonTypeSubmit.Click();

        return new UsersPage();
    }
}