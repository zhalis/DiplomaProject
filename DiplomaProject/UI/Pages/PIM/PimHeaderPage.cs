using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.PIM;

public class PimHeaderPage : BasePage
{
    private const string PimHeader = "PIM";
    private const string AddEmployeeLink = "Add Employee";
    private const string EmployeeListLink = "Employee List";
    private const string CustomFieldsLink = "Custom Fields";
    private readonly DropDown _configurationDropDown = HeaderDropDown.ByLabel("Configuration ");

    public bool IsPimHeaderDisplayed() => IsHeaderDisplayed(PimHeader);

    public AddEmployeePage ClickAddEmployeeButton()
    {
        ClickLinkByName(AddEmployeeLink);

        return new AddEmployeePage();
    }

    public EmployeeListPage ClickEmployeeListButton()
    {
        ClickLinkByName(EmployeeListLink);

        return new EmployeeListPage();
    }

    public CustomFieldsPage OpenCustomFieldsPage()
    {
        _configurationDropDown.SelectValue(CustomFieldsLink);

        return new CustomFieldsPage();
    }
}