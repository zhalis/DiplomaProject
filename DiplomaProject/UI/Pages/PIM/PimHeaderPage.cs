using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.PIM;

public class PimHeaderPage : BasePage
{
    private readonly Element _pimHeader = Element.ByXPath(HeaderByTextPattern, "PIM");
    private readonly Element _addEmployeeButton = Element.ByXPath(LinkByTextPattern, "Add Employee");
    private readonly Element _employeeListButton = Element.ByXPath(LinkByTextPattern, "Employee List");
    private readonly Element _configurationMenu = Element.ByXPath(SpanByTextPattern, "Configuration ");
    private readonly Element _customFieldsLink = Element.ByXPath(LinkByTextPattern, "Custom Fields");
    
    public bool IsPimHeaderDisplayed() => _pimHeader.IsDisplayed();
    
    public AddEmployeePage ClickAddEmployeeButton()
    {
        _addEmployeeButton.Click();

        return new AddEmployeePage();
    }
    
    public EmployeeListPage ClickEmployeeListButton()
    {
        _employeeListButton.Click();

        return new EmployeeListPage();
    }

    public PimHeaderPage ClickConfigurationMenu()
    {
        _configurationMenu.Click();

        return this;
    }

    public CustomFieldsPage ClickCustomFieldsLink()
    {
        _customFieldsLink.Click();

        return new CustomFieldsPage();
    }
}