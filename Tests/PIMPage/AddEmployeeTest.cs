using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.PIM;
using DiplomaProject.UI.Services;
using NUnit.Framework;

namespace Tests.PIMPage;

[TestFixture]
public class AddEmployeeTest : BaseTest
{
    private const string FirstName = "Alexsey";
    private const string LastName = "Ivanov";
    private string _employeeId;

    [SetUp]
    public void LoginAsAdmin() => new LoginService().LoginAsAdmin();

    [Test]
    public void Scenario3ValidateAddNewEmployee()
    {
        var pimHeaderPage = new SidePanelPage()
            .ClickPimButton();
        Assert.IsTrue(pimHeaderPage.IsPimHeaderDisplayed(), "PIM header isn't displayed");
        var addEmployeePage = pimHeaderPage
            .ClickAddEmployeeButton();
        Assert.IsTrue(addEmployeePage.IsAddEmployeeTitleDisplayed(), "'Add Employee' form isn't displayed");
        addEmployeePage = new EmployeeService()
            .FillInAddEmployeeForm(FirstName, LastName);
        _employeeId = addEmployeePage
            .GetEmployeeId();
        Assert.AreEqual(FirstName, addEmployeePage.GetFirstNameInputValue(), "First name isn't entered");
        Assert.AreEqual(LastName, addEmployeePage.GetLastNameInputValue(), "Last Name isn't entered");
        var personalDetailsPage = addEmployeePage
            .ClickSaveButton();
        Assert.IsTrue(personalDetailsPage.IsPersonalTitleDisplayed(), "Form isn't submitted");
        var employeeListPage = new PimHeaderPage()
            .ClickEmployeeListButton();
        new EmployeeService()
            .SearchEmployee(_employeeId);
        Assert.IsTrue(employeeListPage.IsEmployeeByIdDisplayed(_employeeId),
            "The new employee details isn't appear in the Employee List");
    }

    [TearDown]
    public void DeleteAddedEmployeeAndLogout()
    {
        new PimHeaderPage().ClickEmployeeListButton();
        new EmployeeService().DeleteEmployee(_employeeId);
        new LogoutService().Logout();
    }
}