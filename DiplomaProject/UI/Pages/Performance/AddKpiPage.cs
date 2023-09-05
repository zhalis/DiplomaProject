using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.Performance;

public class AddKpiPage : BasePage
{
    private readonly Element _addKpiTitle = Element.ByXPath("//*[text()='Add Key Performance Indicator']");

    private readonly Element _kpiInput = Element.ByXPath(InputByLabelNamePattern, "Key Performance Indicator");

    private readonly DropDown _jobTitleDropDown = SelectDropDown.ByLabel("Job Title");

    public bool IsAddKpiTitleDisplayed() => _addKpiTitle.IsDisplayed();

    public AddKpiPage TypeKpi(string kpi)
    {
        _kpiInput.SendKeys(kpi);

        return this;
    }

    public AddKpiPage SelectJobTitle(string jobTitle)
    {
        _jobTitleDropDown.SelectValue(jobTitle);

        return this;
    }

    public KpiPage ClickSaveButton()
    {
        ButtonTypeSubmit.Click();

        return new KpiPage();
    }
}