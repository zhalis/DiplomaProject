using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.Leave;

public class AddEntitlementsPage : BasePage
{
    private readonly DropDown _employeeNameInput = AutocompleteDropDown.ByLabel("Employee Name");
    private readonly DropDown _leaveTypeDropDown = SelectDropDown.ByLabel("Leave Type");
    private readonly Element _entitlementInput = Element.ByXPath(InputByLabelNamePattern, "Entitlement");

    public AddEntitlementsPage SelectEmployee(string employeeName) =>
        ExecuteInChain<AddEntitlementsPage>(() => _employeeNameInput.SelectValue(employeeName));

    public AddEntitlementsPage SelectLeaveType(string leaveType) => ExecuteInChain<AddEntitlementsPage>(() =>
        _leaveTypeDropDown.SelectValue(leaveType));

    public AddEntitlementsPage EnterEntitlement(string entitlement) =>
        ExecuteInChain<AddEntitlementsPage>(() => _entitlementInput.SendKeys(entitlement));

    public ConfirmationPopUp ClickSaveButton()
    {
        ButtonTypeSubmit.Click();

        return new ConfirmationPopUp();
    }
}