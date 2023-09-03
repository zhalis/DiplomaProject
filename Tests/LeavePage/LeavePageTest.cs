using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Services;
using NUnit.Framework;

namespace Tests.LeavePage;

[TestFixture]
public class LeavePageTest : BaseTest
{
    private const string FirstName = "Alexsey";
    private const string LastName = "Ivanov";
    private const string LeaveType = "CAN - Personal";
    private const string Comment = "comment";
    private const string Entitlement = "20";
    private string _employeeId;

    [SetUp]
    public void LoginAsAdminCreateEmployeeAndAddEntitlements()
    {
        new LoginService()
            .LoginAsAdmin()
            .ClickPimButton()
            .ClickAddEmployeeButton();
        _employeeId = new EmployeeService()
            .CreateEmployee(FirstName, LastName);
        new SidePanelPage()
            .ClickLeaveButton()
            .ClickEntitlementsDropDownMenu()
            .ClickAddEntitlementsLink();
        new AddEntitlementsService()
            .CreateEntitlement(FirstName, LeaveType, Entitlement);
    }

    [Test]
    public void Scenario10AssignLeave()
    {
        var leaveHeaderPage = new SidePanelPage()
            .ClickLeaveButton();
        leaveHeaderPage.WaitLoadingSpinnerInvisibility();
        Assert.IsTrue(leaveHeaderPage.IsLeaveHeaderTitleDisplayed(), "Leave options isn't displayed");
        var assignLeavePage = leaveHeaderPage.ClickAssignButton();
        Assert.IsTrue(assignLeavePage.IsAssignLeaveTitleDisplayed(), "'Assign Leave' page isn't displayed");
        assignLeavePage = new AssignLeaveService()
            .FillInAssignLeaveForm(FirstName, LeaveType, Comment)
            .ClickAssignButton();
        Assert.IsTrue(assignLeavePage.IsSavedSuccessfullyPopUpDisplayed(),
            "Leave isn't assigned to the specified employee");
    }

    [TearDown]
    public void DeleteEmployee()
    {
        new SidePanelPage()
            .ClickPimButton()
            .ClickEmployeeListButton();
        new EmployeeService()
            .DeleteEmployee(_employeeId);
    }
}