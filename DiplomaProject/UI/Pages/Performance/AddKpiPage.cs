using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.Performance;

public class AddKpiPage : BasePage
{
    private readonly Element _addKpiTitle = Element.ByXPath("//*[text()='Add Key Performance Indicator']");
    private readonly Element _kpiInput = Element.ByXPath(InputByLabelNamePattern, "Key Performance Indicator");
    private readonly DropDown _jobTitleDropDown = SelectDropDown.ByLabel("Job Title");

    public bool IsAddKpiTitleDisplayed() => _addKpiTitle.IsDisplayed();

    public AddKpiPage TypeKpi(string kpi) => ExecuteInChain<AddKpiPage>(() => _kpiInput.SendKeys(kpi));

    public AddKpiPage SelectJobTitle(string jobTitle) =>
        ExecuteInChain<AddKpiPage>(() => _jobTitleDropDown.SelectValue(jobTitle));

    public KpiPage ClickSaveButton()
    {
        ButtonTypeSubmit.Click();

        return new KpiPage();
    }
}