using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Admin;

public class UsersPage : BasePage
{
    private const string UsernameColumnName = "Username";

    private readonly Element _userList = Element.ByXPath("//*[@class='orangehrm-container']");

    private readonly Element _oneRecordFoundTitle = Element.ByXPath(SpanByTextPattern, "(1) Record Found");

    private readonly Element _usernameInput = Element.ByXPath(InputByLabelNamePattern, "Username");

    private readonly Element _addButton =
        Element.ByXPath("//*[@type='button' and contains(@class,'oxd-button--secondary')]");

    private readonly Table _users = new();

    public UsersPage EnterUsername(string username)
    {
        _usernameInput.SendKeys(username);

        return this;
    }

    public string GetUsernameInputValue() => _usernameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public UsersPage ClickSearchButton()
    {
        ButtonTypeSubmit.Click();

        return this;
    }

    public UsersPage WaitSearchResultByUsername()
    {
        _oneRecordFoundTitle.WaitForVisibility();

        return this;
    }

    public bool IsUserListDisplayed() => _userList.IsDisplayed();

    public AddUserPage ClickAddButton()
    {
        _addButton.Click();

        return new AddUserPage();
    }

    public List<string> GetFoundUsernames() =>
        _users.GetElementsByColumn(UsernameColumnName);

    public ConfirmationPopUp ClickTrashBinButtonByUsername(string username)
    {
        _users.ClickTrashBinButtonByColumnValue(username);

        return new ConfirmationPopUp();
    }

    public EditUserPage ClickEditButtonByUsername(string username)
    {
        _users.ClickEditButtonByColumnValue(username);

        return new EditUserPage();
    }
}