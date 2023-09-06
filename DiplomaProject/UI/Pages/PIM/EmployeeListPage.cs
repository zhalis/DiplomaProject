using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.PIM;

public class EmployeeListPage : BasePage
{
    private const string FirstNameColumnName = "First (& Middle) Name";
    private readonly Element _employeeInformationTitle = Element.ByXPath("//*[text()='Employee Information']");
    private readonly Element _employeeNameInput = Element.ByXPath(InputByLabelNamePattern, "Employee Name");
    private readonly Element _employeeIdInput = Element.ByXPath(InputByLabelNamePattern, "Employee Id");
    private readonly Element _notFoundSearchResultMessage = Element.ByXPath(SpanByTextPattern, "No Records Found");
    private readonly Element _oneRecordFoundTitle = Element.ByXPath(SpanByTextPattern, "(1) Record Found");
    private readonly Table _employees = new();

    public bool IsEmployeeInformationTitleDisplayed() => _employeeInformationTitle.IsDisplayed();

    public string GetEmployeeNameInputValue() => _employeeNameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public bool IsNotFoundSearchResultMessageDisplayed() => _notFoundSearchResultMessage.IsDisplayed();

    public bool IsEmployeeByIdDisplayed(string employeeId) => _employees.IsColumnValueDisplayed(employeeId);

    public EmployeeListPage EnterEmployeeName(string employeeName) =>
        ExecuteInChain<EmployeeListPage>(() => _employeeNameInput.SendKeys(employeeName));

    public EmployeeListPage ClearEmployeeNameInput()
    {
        _employeeNameInput.ClearInputUsingBackspace();

        return new EmployeeListPage();
    }

    public EmployeeListPage EnterEmployeeId(string employeeId) => ExecuteInChain<EmployeeListPage>(() =>
    {
        _employeeIdInput.Click();
        _employeeIdInput.SendKeys(employeeId);
    });

    public EmployeeListPage ClickSearchButton() => ExecuteInChain<EmployeeListPage>(() => ButtonTypeSubmit.Click());

    public EmployeeListPage WaitSearchResult() =>
        ExecuteInChain<EmployeeListPage>(() => _oneRecordFoundTitle.WaitForVisibility());

    public ConfirmationPopUp ClickTrashBinButtonByEmployeeId(string employeeId)
    {
        _employees.ClickTrashBinButtonByColumnValue(employeeId);

        return new ConfirmationPopUp();
    }

    public List<string> GetEmployeeNamesFromEmployeeList() =>
        _employees.GetElementsByColumn(FirstNameColumnName);

    public PersonalDetailsPage ClickOnEmployeeById(string employeeId)
    {
        _employees.ClickTableCellByValue(employeeId);

        return new PersonalDetailsPage();
    }

    public EmployeeListPage ClickCheckboxByEmployeeId(string employeeId) =>
        ExecuteInChain<EmployeeListPage>(() => _employees.ClickCheckboxByColumnValue(employeeId));

    public ConfirmationPopUp ClickDeleteSelectedButton()
    {
        _employees.ClickDeleteSelected();

        return new ConfirmationPopUp();
    }

    public PersonalDetailsPage ClickEditButtonByEmployeeId(string employeeId)
    {
        _employees.ClickEditButtonByColumnValue(employeeId);

        return new PersonalDetailsPage();
    }
}