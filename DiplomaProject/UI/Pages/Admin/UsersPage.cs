using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Admin;

public class UsersPage : BasePage
{
    private const string ActionsButtonByUsernameAndButtonClassPattern =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//i[contains(@class,'{1}')]";

    private static readonly string TrashBinButtonByUsernamePattern =
        string.Format(ActionsButtonByUsernameAndButtonClassPattern, "{0}", "bi-trash");

    private static readonly string EditButtonByUsernamePattern =
        string.Format(ActionsButtonByUsernameAndButtonClassPattern, "{0}", "bi-pencil-fill");

    private readonly Element _userList = Element.ByXPath("//div[@class='orangehrm-container']");

    private readonly Element _searchButton = Element.ByXPath(ButtonTypeSubmit);

    private readonly Element _oneRecordFoundTitle = Element.ByXPath(SpanByTextPattern, "(1) Record Found");

    private readonly Element _usernameInput =
        Element.ByXPath("//div[contains(@class,'oxd-input-group')]//input[contains(@class,'oxd-input')]");

    private readonly Element _addButton =
        Element.ByXPath("//button[@type='button' and contains(@class,'oxd-button--secondary')]");

    private readonly Element _employeeUsername =
        Element.ByXPath("//div[@class='oxd-table-card']//div[contains(@class,'oxd-table-cell')][2]/div");

    public UsersPage EnterUsername(string username)
    {
        _usernameInput.Type(username);

        return this;
    }

    public string GetUsernameInputValue() => _usernameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public UsersPage ClickSearchButton()
    {
        _searchButton.Click();

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

    public IEnumerable<string> GetFoundUsernames() =>
        _employeeUsername.WaitForPresenceOfAllElements().Select(username => username.Text);

    public ConfirmationPopUp ClickTrashBinButtonByUsername(string username)
    {
        Element.ByXPath(TrashBinButtonByUsernamePattern, username).Click();

        return new ConfirmationPopUp();
    }

    public EditUserPage ClickEditButtonByUsername(string username)
    {
        Element.ByXPath(EditButtonByUsernamePattern, username).Click();

        return new EditUserPage();
    }
}