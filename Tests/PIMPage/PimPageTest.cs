using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.PIM;
using DiplomaProject.UI.Services;
using NUnit.Framework;

namespace Tests.PIMPage;

[TestFixture]
public class PimPageTest : BaseTest
{
    private const string FirstName = "Alexsey";
    private const string LastName = "Ivanov";
    private const string SearchParameter = "1234567";
    private const string NewFirstName = "FirstName";
    private const string SkillName = "C#";
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
    public void Scenario12SearchEmployee()
    {
        var employeeListPage = new SidePanelPage()
            .ClickPimButton()
            .ClickEmployeeListButton();
        employeeListPage.WaitLoadingSpinnerInvisibility();
        Assert.IsTrue(employeeListPage.IsEmployeeInformationTitleDisplayed(), "Employee list page isn't opened");
        employeeListPage
            .EnterEmployeeName(FirstName);
        Assert.AreEqual(FirstName, employeeListPage.GetEmployeeNameInputValue(), "Employee name isn't entered");
        employeeListPage
            .ClickSearchButton()
            .WaitSearchResult();
        Assert.IsTrue(employeeListPage.GetEmployeeNamesFromEmployeeList()
            .All(employeeName => employeeName.Contains(FirstName)), "Search results are incorrect");
        employeeListPage
            .ClearEmployeeNameInput()
            .EnterEmployeeName(SearchParameter)
            .ClickSearchButton();
        Assert.IsTrue(employeeListPage.IsNotFoundSearchResultMessageDisplayed(), "'Results not found' isn't displayed");
    }

    [Test]
    public void Scenario13EditEmployeeDetails()
    {
        new PimHeaderPage()
            .ClickEmployeeListButton();
        var personalDetailsPage = new EmployeeService()
            .SearchEmployee(_employeeId)
            .ClickOnEmployeeById(_employeeId);
        personalDetailsPage.WaitLoadingSpinnerInvisibility();
        personalDetailsPage
            .EnterNewFirstName(NewFirstName)
            .ClickSaveButton()
            .WaitLoadingSpinnerInvisibility();
        Assert.AreEqual(NewFirstName, personalDetailsPage.GetFirstNameInputValue(), "First name isn't updated");
        new PimHeaderPage()
            .ClickEmployeeListButton();
        var employeeListPage = new EmployeeService()
            .SearchEmployee(_employeeId);
        Assert.IsTrue(employeeListPage.GetEmployeeNamesFromEmployeeList()
            .All(employeeName => employeeName.Equals(NewFirstName)), "First name isn't updated in the list");
    }

    [Test]
    public void Scenario20ValidateAssignSkillToEmployeeProfile()
    {
        var employeeListPage = new PimHeaderPage()
            .ClickEmployeeListButton();
        employeeListPage.WaitLoadingSpinnerInvisibility();
        var qualificationsPage = employeeListPage.EnterEmployeeId(_employeeId)
            .ClickSearchButton()
            .WaitSearchResult()
            .ClickEditButtonByEmployeeId(_employeeId)
            .ClickQualificationsTab();
        Assert.IsTrue(qualificationsPage.IsQualificationsTitleDisplayed(), "Qualifications tab isn't opened");
        qualificationsPage.ClickAddSkillButton();
        qualificationsPage.WaitLoadingSpinnerInvisibility();
        Assert.IsTrue(qualificationsPage.IsAddSkillTitleDisplayed(), "Skill form isn't displayed");
        qualificationsPage
            .SelectSkill(SkillName)
            .ClickSaveButton();
        Assert.IsTrue(qualificationsPage.IsSavedSuccessfullyPopUpDisplayed(), "New skill isn't saved");
        Assert.IsTrue(qualificationsPage.GetSkillNamesFromSkillList()
            .Any(skill => skill.Equals(SkillName)), "New skill isn't appeared in the skill list");
    }

    [TearDown]
    public void DeleteAddedEmployeeAndLogout()
    {
        new PimHeaderPage().ClickEmployeeListButton();
        new EmployeeService().DeleteEmployee(_employeeId);
        new LogoutService().Logout();
    }
}