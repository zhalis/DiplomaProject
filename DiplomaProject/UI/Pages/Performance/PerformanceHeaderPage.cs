using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.Performance;

public class PerformanceHeaderPage : BasePage
{
    private const string KpiLink = "KPIs";
    private readonly DropDown _configureDropDownMenu = HeaderDropDown.ByLabel("Configure ");

    public KpiPage OpenKpiPage()
    {
        _configureDropDownMenu.SelectValue(KpiLink);

        return new KpiPage();
    }
}