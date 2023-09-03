using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Performance;

public class PerformanceHeaderPage : BasePage
{
    private readonly Element _configureDropDownMenu = Element.ByXPath(SpanByTextPattern, "Configure ");
    private readonly Element _dropDownMenu = Element.ByXPath("//ul[contains(@class,'oxd-dropdown-menu')]");
    private readonly Element _kpiLinkInDropDownMenu = Element.ByXPath(LinkByTextPattern, "KPIs");

    public PerformanceHeaderPage ClickConfigureMenu()
    {
        _configureDropDownMenu.Click();

        return this;
    }

    public PerformanceHeaderPage WaitDropDownVisibility()
    {
        _dropDownMenu.WaitForVisibility();

        return this;
    }

    public KpiPage ClickKpiLink()
    {
        _kpiLinkInDropDownMenu.Click();

        return new KpiPage();
    }
}