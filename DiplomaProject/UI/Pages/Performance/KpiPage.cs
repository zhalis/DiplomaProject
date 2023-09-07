using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Performance;

public class KpiPage : BasePage
{
    private const string KpiColumnName = "Key Performance Indicator";
    private readonly Element _kpiForJobTitle =
        Element.ByXPath("//h5[text()='Key Performance Indicators for Job Title']");
    private readonly Element _addButton =
        Element.ByXPath("//button[contains(@class,'oxd-button--secondary')]/i[contains(@class,'oxd-icon')]");
    private readonly Element _kpiList = Element.ByXPath("//div[@class='orangehrm-container']");
    private readonly Table _kpis = new();

    public bool IsKpiJobTitleDisplayed() => _kpiForJobTitle.IsDisplayed();

    public AddKpiPage ClickAddButton()
    {
        _addButton.Click();

        return new AddKpiPage();
    }

    public ConfirmationPopUp ClickDeleteSelectedButton()
    {
        _kpis.ClickDeleteSelected();

        return new ConfirmationPopUp();
    }

    public void ClickKpiCheckboxByKpiName(string kpiName) => _kpis.ClickCheckboxByColumnValue(kpiName);

    public bool IsCheckboxCheckedByKpiName(string kpiName) =>
        _kpis.IsCheckboxCheckedByColumnValue(kpiName);

    public List<string> GetKpiNamesFromKpiList() =>
        _kpis.GetElementsByColumn(KpiColumnName);

    public KpiPage WaitKpiListVisibility() => ExecuteInChain<KpiPage>(() => _kpiList.WaitForVisibility());
}