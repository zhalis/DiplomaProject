using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.Performance;
using DiplomaProject.UI.Services;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Tests.PerformancePage;

[TestFixture]
[AllureNUnit]
public class PerformancePageTest : BaseTest
{
    private const string Kpi = "AddedKpi";
    private const string JobTitle = "Account Assistant";

    [SetUp]
    public void LoginAsAdmin() => new LoginService().LoginAsAdmin();

    [Test]
    public void Scenario5ValidatePerformanceManagementFunctionality()
    {
        var kpiPage = new SidePanelPage()
            .ClickPerformanceButton()
            .OpenKpiPage();
        Assert.IsTrue(kpiPage.IsKpiJobTitleDisplayed(), "KPI page isn't displayed");
        var addKpiPage = kpiPage
            .ClickAddButton();
        Assert.IsTrue(addKpiPage.IsAddKpiTitleDisplayed(), "'Add Key Performance Indicator' page isn't displayed");
        kpiPage = addKpiPage
            .TypeKpi(Kpi)
            .SelectJobTitle(JobTitle)
            .ClickSaveButton()
            .WaitKpiListVisibility();
        CollectionAssert.Contains(kpiPage.GetKpiNamesFromKpiList(), Kpi,
            "The new performance indicator isn't listed in the KPI list");
        kpiPage.ClickKpiCheckboxByKpiName(Kpi);
        Assert.IsTrue(kpiPage.IsCheckboxCheckedByKpiName(Kpi), "The checkbox isn't checked");
        var confirmationPopUp = kpiPage.ClickDeleteSelectedButton();
        Assert.IsTrue(confirmationPopUp.IsConfirmationPopUpDisplayed(), "Confirmation pop-up isn't displayed");
        confirmationPopUp.ClickYesButton();
        CollectionAssert.DoesNotContain(new KpiPage().GetKpiNamesFromKpiList(), Kpi,
            "The indicator listed in the KPI list");
    }
}