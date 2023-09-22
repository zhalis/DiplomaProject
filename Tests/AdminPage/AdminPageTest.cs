using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.Admin;
using DiplomaProject.UI.Services;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Tests.AdminPage;

[TestFixture]
[AllureNUnit]
public class AdminPageTest : BaseTest
{
    private const string JobTitle = "Automation QA";

    [SetUp]
    public void LoginAsAdmin() => new LoginService().LoginAsAdmin();

    [Test]
    public void Scenario6ValidateAdminFunction()
    {
        var adminHeaderPage = new SidePanelPage()
            .ClickAdminButton();
        Assert.IsTrue(adminHeaderPage.IsAdminTitleDisplayed(), "Admin page isn't displayed");
        adminHeaderPage
            .ClickUserManagementDropDownMenu();
        Assert.IsTrue(adminHeaderPage.IsUsersLinkDisplayed(), "'Users' link isn't displayed");
        adminHeaderPage
            .ClickJobDropDownMenu();
        Assert.IsTrue(adminHeaderPage.IsDropDownMenuDisplayed(), "Job dropdown menu isn't displayed");
        Assert.IsTrue(adminHeaderPage.IsJobTitlesLinkDisplayed(), "'Job Titles' link isn't displayed");
    }

    [Test]
    public void Scenario18ValidateJobTitlesManagementFunctionality()
    {
        var jobTitlesPage = new SidePanelPage()
            .ClickAdminButton()
            .OpenJobTitlesPage();
        Assert.IsTrue(jobTitlesPage.IsJobTitlesHeaderDisplayed(), "'Job Titles' page isn't displayed");
        jobTitlesPage.ClickAddButton()
            .WaitLoadingSpinnerInvisibility();
        var addJobTitlePage = new AddJobTitlePage();
        Assert.IsTrue(addJobTitlePage.IsAddJobTitleHeaderDisplayed(), "'Add Job Title' form page isn't displayed");
        addJobTitlePage
            .TypeJobTitle(JobTitle)
            .ClickSaveButton();
        Assert.IsTrue(addJobTitlePage.IsSavedSuccessfullyPopUpDisplayed(), "New job title isn't saved");
        jobTitlesPage = new JobTitlesPage();
        CollectionAssert.Contains(jobTitlesPage.GetJobTitles(), JobTitle, "The new job title isn't listed");
        jobTitlesPage
            .ClickCheckboxByJobTitleName(JobTitle);
        Assert.IsTrue(jobTitlesPage.IsCheckboxSelectedByJobTitleName(JobTitle), "The checkbox isn't selected");
        var confirmationPopUp = jobTitlesPage
            .ClickDeleteSelectedButton();
        Assert.IsTrue(confirmationPopUp.IsConfirmationPopUpDisplayed(), "Confirmation pop-up isn't displayed");
        confirmationPopUp.ClickYesButton();
        jobTitlesPage = new JobTitlesPage();
        Assert.IsTrue(jobTitlesPage.IsDeletedSuccessfullyPopUpDisplayed(), "The job title isn't deleted");
        CollectionAssert.DoesNotContain(jobTitlesPage.GetJobTitles(), JobTitle,
            "The job title is displayed in the list");
    }
}