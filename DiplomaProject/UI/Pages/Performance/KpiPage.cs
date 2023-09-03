using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Performance;

public class KpiPage : BasePage
{
    private const string KpiCheckboxByKpiNamePattern =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//span";

    private const string KpiCheckboxInputByNamePattern =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//input[@type='checkbox']";

    private readonly Element _kpiForJobTitle =
        Element.ByXPath("//h5[text()='Key Performance Indicators for Job Title']");

    private readonly Element _addButton =
        Element.ByXPath("//button[contains(@class,'oxd-button--secondary')]/i[contains(@class,'oxd-icon')]");

    private readonly Element _deleteSelectedButton = Element.ByXPath(
        "//button[contains(@class,'oxd-button')]//i[contains(@class,'bi-trash-fill')]");

    private readonly Element _kpiList = Element.ByXPath("//div[@class='orangehrm-container']");

    private readonly Element _kpiNameFromList =
        Element.ByXPath("//div[contains(@class,'oxd-table-row ')]/div[contains(@class,'oxd-table-cell')][2]");

    public bool IsKpiJobTitleDisplayed() => _kpiForJobTitle.IsDisplayed();

    public AddKpiPage ClickAddButton()
    {
        _addButton.Click();

        return new AddKpiPage();
    }

    public ConfirmationPopUp ClickDeleteSelectedButton()
    {
        _deleteSelectedButton.Click();

        return new ConfirmationPopUp();
    }

    public KpiPage ClickKpiCheckboxByKpiName(string kpiName)
    {
        Element.ByXPath(KpiCheckboxByKpiNamePattern, kpiName).Click();

        return this;
    }

    public bool IsCheckboxCheckedByKpiName(string kpiName) =>
        bool.Parse(Element.ByXPath(KpiCheckboxInputByNamePattern, kpiName)
            .GetAttributeValue(Attributes.CheckedCssProperty));

    public IEnumerable<string> GetKpiNamesFromKpiList() =>
        _kpiNameFromList.WaitForPresenceOfAllElements().Select(kpi => kpi.Text);

    public KpiPage WaitKpiListVisibility()
    {
        _kpiList.WaitForVisibility();

        return this;
    }
}