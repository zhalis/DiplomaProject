using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.Leave;

public class AddEntitlementsPage : BasePage
{
    private readonly DropDown _employeeNameInput = AutocompleteDropDown.ByLabel("Employee Name");

    private readonly DropDown _leaveTypeDropDown = SelectDropDown.ByLabel("Leave Type");

    private readonly Element _entitlementInput = Element.ByXPath(InputByLabelNamePattern, "Entitlement");

    public AddEntitlementsPage SelectEmployee(string employeeName)
    {
        _employeeNameInput.SelectValue(employeeName);

        return this;
    }

    public AddEntitlementsPage SelectLeaveType(string leaveType)
    {
        _leaveTypeDropDown.SelectValue(leaveType);

        return this;
    }

    public AddEntitlementsPage EnterEntitlement(string entitlement)
    {
        _entitlementInput.SendKeys(entitlement);

        return this;
    }

    public ConfirmationPopUp ClickSaveButton()
    {
        ButtonTypeSubmit.Click();

        return new ConfirmationPopUp();
    }
}