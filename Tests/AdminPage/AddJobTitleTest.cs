using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.Admin;
using DiplomaProject.UI.Services;
using NUnit.Framework;

namespace Tests.AdminPage;

[TestFixture]
public class AddJobTitleTest : BaseTest
{
    private const string JobTitle = "Automation QA";

    [SetUp]
    public void LoginAsAdmin() => new LoginService().LoginAsAdmin();

    [Test]
    public void Scenario11AddJobTitle()
    {
        var adminHeaderPage = new SidePanelPage()
            .ClickAdminButton()
            .ClickJobDropDownMenu()
            .WaitDropDownMenuVisibility();
        Assert.IsTrue(adminHeaderPage.IsDropDownMenuDisplayed(), "Job options isn't displayed");
        var jobTitlesPage = adminHeaderPage
            .ClickJobTitlesInDropDownMenu();
        Assert.IsTrue(jobTitlesPage.IsJobTitlesHeaderDisplayed(), "Job Titles table isn't visible");
        jobTitlesPage
            .ClickAddButton()
            .WaitLoadingSpinnerInvisibility();
        var addJobTitlePage = new AddJobTitlePage()
            .TypeJobTitle(JobTitle);
        Assert.AreEqual(JobTitle, addJobTitlePage.GetJobTitleInputValue(), "Entered job title is incorrect");
        addJobTitlePage
            .ClickSaveButton();
        Assert.IsTrue(jobTitlesPage.GetJobTitlesText()
            .Any(title => title.Equals(JobTitle)), "The new title isn't saved");
    }

    [TearDown]
    public void DeleteNewTitle() =>
        new JobTitlesPage().ClickTrashBinButtonByJobTitle(JobTitle)
            .WaitPopUpVisibility()
            .ClickYesButton();
}