using DiplomaProject.UI.Pages.PIM;

namespace DiplomaProject.UI.Services;

public class EmployeeService
{
    private readonly AddEmployeePage _addEmployeePage = new();
    private readonly EmployeeListPage _employeeListPage = new();

    public AddEmployeePage FillInAddEmployeeForm(string firstName, string lastName)
    {
        _addEmployeePage.WaitLoadingSpinnerInvisibility();
        return _addEmployeePage
            .EnterFirstName(firstName)
            .EnterLastName(lastName);
    }

    public string CreateEmployee(string firstName, string lastName)
    {
        var addEmployeePage = FillInAddEmployeeForm(firstName, lastName);
        var employeeId = addEmployeePage.GetEmployeeId();
        addEmployeePage.ClickSaveButton();
        return employeeId;
    }

    public EmployeeListPage SearchEmployee(string employeeId)
    {
        _employeeListPage.WaitLoadingSpinnerInvisibility();
        return _employeeListPage
            .EnterEmployeeId(employeeId)
            .ClickSearchButton()
            .WaitSearchResult();
    }

    public void DeleteEmployee(string employeeId)
    {
        SearchEmployee(employeeId)
            .ClickTrashBinButtonByEmployeeId(employeeId)
            .WaitPopUpVisibility()
            .ClickYesButton();
    }
}