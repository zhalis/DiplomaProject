using DiplomaProject.UI.Pages.PIM;

namespace DiplomaProject.UI.Services;

public class EmployeeService
{
    public AddEmployeePage FillInAddEmployeeForm(string firstName, string lastName)
    {
        var addEmployeePage = new AddEmployeePage();
        addEmployeePage.WaitLoadingSpinnerInvisibility();

        return addEmployeePage
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
        var employeeListPage = new EmployeeListPage();
        employeeListPage.WaitLoadingSpinnerInvisibility();

        return employeeListPage
            .EnterEmployeeId(employeeId)
            .ClickSearchButton()
            .WaitSearchResult();
    }

    public void DeleteEmployee(string employeeId) =>
        SearchEmployee(employeeId)
            .ClickTrashBinButtonByEmployeeId(employeeId)
            .WaitPopUpVisibility()
            .ClickYesButton();
}