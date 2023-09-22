using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.PIM;
using DiplomaProject.UI.Services;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Tests.PIMPage;

[TestFixture]
[AllureNUnit]
public class DeleteEmployeeTest : BaseTest
{
    private const string FirstName = "Alexsey";
    private const string LastName = "Ivanov";
    private string _employeeId;

    [SetUp]
    public void LoginAsAdminAndCreateNewEmployee()
    {
        new LoginService()
            .LoginAsAdmin()
            .ClickPimButton()
            .ClickAddEmployeeButton();
        _employeeId = new EmployeeService()
            .CreateEmployee(FirstName, LastName);
    }

    [Test]
    public void Scenario14DeleteEmployee()
    {
        new SidePanelPage()
            .ClickPimButton()
            .ClickEmployeeListButton();
        var confirmationPopUp = new EmployeeService()
            .SearchEmployee(_employeeId)
            .ClickCheckboxByEmployeeId(_employeeId)
            .ClickDeleteSelectedButton();
        Assert.IsTrue(confirmationPopUp.IsConfirmationPopUpDisplayed(), "A confirmation pop up isn't displayed");
        confirmationPopUp.ClickYesButton();
        var employeeListPage = new EmployeeListPage()
            .ClickSearchButton();
        Assert.IsTrue(employeeListPage.IsNotFoundSearchResultMessageDisplayed(), "The employee isn't deleted");
    }

    [TearDown]
    public void Logout() => new LogoutService().Logout();
}