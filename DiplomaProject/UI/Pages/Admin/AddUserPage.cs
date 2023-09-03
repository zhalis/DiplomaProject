using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Admin;

public class AddUserPage : BasePage
{
    private const string DropDownArrowPattern =
        "//label[text()='{0}']//ancestor::div[contains(@class,'oxd-input-group')]" +
        "//i[contains(@class,'bi-caret-down-fill')]";

    private const string InputByLabelNamePattern =
        "//label[text()='{0}']//ancestor::div[contains(@class,'oxd-input-group')]//input[contains(@class,'oxd-input')]";

    private readonly Element _userRoleArrow = Element.ByXPath(DropDownArrowPattern, "User Role");
    private readonly Element _statusArrow = Element.ByXPath(DropDownArrowPattern, "Status");
    private readonly Element _employeeNameInput = Element.ByXPath(InputByPlaceholderPattern, "Type for hints...");
    private readonly Element _usernameInput = Element.ByXPath(InputByLabelNamePattern, "Username");
    private readonly Element _passwordInput = Element.ByXPath(InputByLabelNamePattern, "Password");
    private readonly Element _confirmPasswordInput = Element.ByXPath(InputByLabelNamePattern, "Confirm Password");
    private readonly Element _saveButton = Element.ByXPath(ButtonTypeSubmit);

    public AddUserPage EnterEmployeeName(string employeeName)
    {
        _employeeNameInput.Type(employeeName);

        return this;
    }

    public AddUserPage EnterUsername(string username)
    {
        _usernameInput.Type(username);

        return this;
    }

    public AddUserPage EnterPassword(string password)
    {
        _passwordInput.Type(password);

        return this;
    }

    public AddUserPage EnterConfirmPassword(string password)
    {
        _confirmPasswordInput.Type(password);

        return this;
    }

    public AddUserPage ClickUserRoleDropDownArrow()
    {
        _userRoleArrow.Click();

        return this;
    }

    public AddUserPage ClickStatusDropDownArrow()
    {
        _statusArrow.Click();

        return this;
    }

    public AddUserPage ClickSelectOptionByName(string selectOption)
    {
        Element.ByXPath(SelectDropDownOptionPattern, selectOption).Click();

        return this;
    }

    public AddUserPage ClickAutocompleteOptionByName(string employeeName)
    {
        Element.ByXPath(AutocompleteDropDownOptionPattern, employeeName).Click();

        return this;
    }

    public UsersPage ClickSaveButton()
    {
        _saveButton.Click();

        return new UsersPage();
    }
}