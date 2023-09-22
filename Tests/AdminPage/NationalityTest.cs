using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.Admin;
using DiplomaProject.UI.Services;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Tests.AdminPage;

[TestFixture]
[AllureNUnit]
public class NationalityTest : BaseTest
{
    private const string NationalityName = "Afghan";
    private const string NewNationalityName = "AAAAAA";

    private NationalitiesPage _nationalitiesPage;

    [SetUp]
    public void LoginAsAdmin() => new LoginService().LoginAsAdmin();

    [Test]
    public void Scenario7EditNationality()
    {
        _nationalitiesPage = new SidePanelPage()
            .ClickAdminButton()
            .ClickNationalitiesButton();
        Assert.IsTrue(_nationalitiesPage.IsNationalitiesTableTitleDisplayed(), "Nationalities table isn't displayed");
        var editNationalityPage = _nationalitiesPage.ClickEditButtonByNationalityName(NationalityName);
        editNationalityPage.WaitLoadingSpinnerInvisibility();
        editNationalityPage.EnterNationalityName(NewNationalityName);
        Assert.AreEqual(NewNationalityName, editNationalityPage.GetValueFromNameInput(),
            "Nationality name isn't updated");
        _nationalitiesPage = editNationalityPage.ClickSaveButton();
        Assert.IsTrue(_nationalitiesPage.GetNationalitiesNames()
                .Any(nationality => nationality.Equals(NewNationalityName)),
            "Changed nationality isn't saved/displayed");
    }

    [TearDown]
    public void RevertNationalityName()
    {
        var editNationalityPage = _nationalitiesPage
            .ClickEditButtonByNationalityName(NewNationalityName);
        editNationalityPage.WaitLoadingSpinnerInvisibility();
        editNationalityPage
            .EnterNationalityName(NationalityName)
            .ClickSaveButton();
    }
}