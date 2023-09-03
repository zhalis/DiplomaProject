using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Performance;

public class AddKpiPage : BasePage
{
    private readonly Element _addKpiTitle = Element.ByXPath("//p[text()='Add Key Performance Indicator']");

    private readonly Element _kpiInput = Element.ByXPath(
        "//label[text()='Key Performance Indicator']//ancestor::div[contains(@class,'oxd-input-group')]" +
        "//input[contains(@class,'oxd-input ')]");

    private readonly Element _jobTitleDropDownArrow =
        Element.ByXPath("//div[@class='oxd-select-text--after']//i[contains(@class,'bi-caret-down-fill')]");

    private readonly Element _jobTitleDropDown = Element.ByXPath("//div[contains(@class,'oxd-select-dropdown')]");

    private readonly Element _saveButton = Element.ByXPath(ButtonTypeSubmit);

    public bool IsAddKpiTitleDisplayed() => _addKpiTitle.IsDisplayed();

    public AddKpiPage TypeKpi(string kpi)
    {
        _kpiInput.Type(kpi);

        return this;
    }

    public AddKpiPage ClickJobTitleDropDownArrow()
    {
        _jobTitleDropDownArrow.Click();

        return this;
    }

    public AddKpiPage WaitJobTitleDropDownVisibility()
    {
        _jobTitleDropDown.IsDisplayed();

        return this;
    }

    public AddKpiPage ClickJobTitleDropDownOptionByName(string jobTitle)
    {
        Element.ByXPath(SelectDropDownOptionPattern, jobTitle).Click();

        return this;
    }

    public KpiPage ClickSaveButton()
    {
        _saveButton.Click();

        return new KpiPage();
    }
}