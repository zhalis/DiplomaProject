using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.PIM;

public class EmployeeListPage : BasePage
{
    private const string EmployeeByIdPattern = "//div[contains(@class,'oxd-table-cell')]/div[text()='{0}']";

    private const string CheckboxByIdPattern =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//span";

    private const string ActionsButtonByUsernameAndButtonClassPattern =
        "//div[text()='{0}']/parent::div//following-sibling::div//i[contains(@class,'{1}')]";

    private static readonly string TrashBinButtonByEmployeeIdPattern =
        string.Format(ActionsButtonByUsernameAndButtonClassPattern, "{0}", "bi-trash");

    private static readonly string EditButtonByEmployeeIdPattern =
        string.Format(ActionsButtonByUsernameAndButtonClassPattern, "{0}", "bi-pencil");

    private readonly Element _employeeInformationTitle = Element.ByXPath("//h5[text()='Employee Information']");

    private readonly Element _employeeNameInput = Element.ByXPath(InputByPlaceholderPattern, "Type for hints...");

    private readonly Element _employeeIdInput =
        Element.ByXPath("//label[text()='Employee Id']/parent::div[contains(@class,'label-wrapper')]" +
                        "//following-sibling::div//input[contains(@class,'oxd-input')]");

    private readonly Element _searchButton = Element.ByXPath(ButtonTypeSubmit);

    private readonly Element _notFoundSearchResultMessage = Element.ByXPath(SpanByTextPattern, "No Records Found");

    private readonly Element _oneRecordFoundTitle = Element.ByXPath(SpanByTextPattern, "(1) Record Found");

    private readonly Element _employeeName =
        Element.ByXPath("//div[@class='oxd-table-card']//div[contains(@class,'oxd-table-cell')][3]/div");

    private readonly Element _deleteSelectedButton = Element.ByXPath(
        "//div[contains(@class,'orangehrm-horizontal-padding')]//button[contains(@class,'oxd-button')]");

    public bool IsEmployeeInformationTitleDisplayed() => _employeeInformationTitle.IsDisplayed();

    public string GetEmployeeNameInputValue() => _employeeNameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public bool IsNotFoundSearchResultMessageDisplayed() => _notFoundSearchResultMessage.IsDisplayed();

    public bool IsEmployeeByIdDisplayed(string employeeId) =>
        Element.ByXPath(EmployeeByIdPattern, employeeId).IsDisplayed();

    public EmployeeListPage EnterEmployeeName(string employeeName)
    {
        _employeeNameInput.Type(employeeName);

        return this;
    }

    public EmployeeListPage ClearEmployeeNameInput()
    {
        _employeeNameInput.ClearInputUsingBackspace();

        return new EmployeeListPage();
    }

    public EmployeeListPage EnterEmployeeId(string employeeId)
    {
        _employeeIdInput.Click();
        _employeeIdInput.Type(employeeId);

        return this;
    }

    public EmployeeListPage ClickSearchButton()
    {
        _searchButton.Click();

        return this;
    }

    public EmployeeListPage WaitSearchResult()
    {
        _oneRecordFoundTitle.WaitForVisibility();

        return this;
    }

    public ConfirmationPopUp ClickTrashBinButtonByEmployeeId(string employeeId)
    {
        Element.ByXPath(TrashBinButtonByEmployeeIdPattern, employeeId).Click();

        return new ConfirmationPopUp();
    }

    public IEnumerable<string> GetEmployeeNamesFromEmployeeList() =>
        _employeeName.WaitForPresenceOfAllElements().Select(employeeName => employeeName.Text);

    public PersonalDetailsPage ClickOnEmployeeById(string employeeId)
    {
        Element.ByXPath(EmployeeByIdPattern, employeeId).Click();

        return new PersonalDetailsPage();
    }

    public EmployeeListPage ClickCheckboxByEmployeeId(string employeeId)
    {
        Element.ByXPath(CheckboxByIdPattern, employeeId).Click();

        return this;
    }

    public ConfirmationPopUp ClickDeleteSelectedButton()
    {
        _deleteSelectedButton.Click();

        return new ConfirmationPopUp();
    }

    public PersonalDetailsPage ClickEditButtonByEmployeeId(string employeeId)
    {
        Element.ByXPath(EditButtonByEmployeeIdPattern, employeeId).Click();

        return new PersonalDetailsPage();
    }
}