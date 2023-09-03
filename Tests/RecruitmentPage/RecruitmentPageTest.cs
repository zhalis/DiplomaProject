using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.Recruitment;
using DiplomaProject.UI.Services;
using NUnit.Framework;

namespace Tests.RecruitmentPage;

[TestFixture]
public class RecruitmentPageTest : BaseTest
{
    private const string VacancyName = "MyVacancyName";
    private const string JobTitle = "Account Assist";
    private const string HiringManager = "Peter Mac Anderson";
    private const string FirstName = "Alexey";
    private const string LastName = "Ivanov";
    private const string FullName = $"{FirstName}  {LastName}";
    private const string Email = "IAlexey@example.com";

    [SetUp]
    public void LoginAsAdmin() => new LoginService().LoginAsAdmin();

    [Test]
    public void Scenario9ValidateRecruitmentManagementFunctionalityTest()
    {
        var vacanciesPage = new SidePanelPage()
            .ClickRecruitmentButton()
            .ClickVacanciesButton();
        Assert.IsTrue(vacanciesPage.IsVacanciesTitleDisplayed(), "Vacancies page isn't displayed");
        var addVacancyPage = vacanciesPage
            .ClickAddVacancyButton();
        Assert.IsTrue(addVacancyPage.IsAddVacancyTitleDisplayed(), "'Add Job Vacancy' page isn't displayed");
        new AddVacancyService()
            .FillInAddVacancyForm(VacancyName, JobTitle, HiringManager)
            .ClickSaveButton();
        BasePage.ClickRefreshButton();
        vacanciesPage = new RecruitmentHeaderPage()
            .ClickVacanciesButton();
        vacanciesPage.WaitLoadingSpinnerInvisibility();
        Assert.IsTrue(vacanciesPage.GetVacanciesName()
            .Any(vacancyName => vacancyName.Equals(VacancyName)), "The new vacancy is not listed in the job vacancies");
        var confirmationPopUp = vacanciesPage
            .ClickVacancyCheckbox(VacancyName)
            .ClickDeleteSelectedButton()
            .WaitPopUpVisibility();
        Assert.IsTrue(confirmationPopUp.IsConfirmationPopUpDisplayed(), "Confirmation pop-up isn't displayed");
        confirmationPopUp.ClickYesButton();
        vacanciesPage = new VacanciesPage();
        Assert.IsTrue(vacanciesPage.IsDeletedSuccessfullyPopUpDisplayed(), "The vacancy isn't deleted");
        Assert.IsFalse(vacanciesPage.GetVacanciesName()
            .Any(vacancyName => vacancyName.Equals(VacancyName)), "The vacancy is listed in the job vacancies");
    }

    [Test]
    public void Scenario16ValidateCandidateManagementInRecruitmentFunctionalityTest()
    {
        var addCandidatePage = new SidePanelPage()
            .ClickRecruitmentButton()
            .ClickCandidatesButton()
            .ClickAddButton();
        addCandidatePage.WaitLoadingSpinnerInvisibility();
        Assert.IsTrue(addCandidatePage.IsAddCandidateTitleDisplayed(), "'Add Candidate' form isn't displayed");
        addCandidatePage
            .EnterFirstName(FirstName)
            .EnterLastName(LastName)
            .EnterEmail(Email)
            .ClickSaveButton();
        Assert.IsTrue(addCandidatePage.IsSavedSuccessfullyPopUpDisplayed(),
            "The form isn't submitted and the new candidate isn't added");
        var candidatesPage = new RecruitmentHeaderPage()
            .ClickCandidatesButton();
        Assert.IsTrue(candidatesPage.GetCandidatesNames()
                .Any(candidate => candidate.Equals($"{FirstName} {LastName}")),
            "The new candidate isn't visible in the list");
        candidatesPage.ClickCheckboxByCandidateName(FullName);
        Assert.IsTrue(candidatesPage.IsCheckboxCheckedByCandidateName(FullName),
            "The checkbox next to the candidate's details isn't checked");
        var confirmationPopUp = candidatesPage.ClickDeleteSelectedButton();
        Assert.IsTrue(confirmationPopUp.IsConfirmationPopUpDisplayed(), "Confirmation pop-up isn't displayed");
        confirmationPopUp.ClickYesButton();
        candidatesPage = new CandidatesPage();
        Assert.IsTrue(candidatesPage.IsDeletedSuccessfullyPopUpDisplayed(), "The selected candidate isn't deleted");
        Assert.IsFalse(candidatesPage.GetCandidatesNames()
            .Any(candidate => candidate.Equals(FullName)), "The candidate's details aren't removed from the list");
    }
}