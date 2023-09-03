using DiplomaProject.UI.Pages.Leave;

namespace DiplomaProject.UI.Services;

public class AddEntitlementsService
{
    private readonly AddEntitlementsPage _addEntitlementsPage = new();

    public void CreateEntitlement(string employeeName, string leaveType, string entitlement)
    {
        _addEntitlementsPage.WaitLoadingSpinnerInvisibility();
        _addEntitlementsPage
            .EnterEmployeeName(employeeName)
            .ClickAutocompleteOptionByName(employeeName)
            .ClickLeaveTypeDropDownArrow()
            .ClickSelectOptionByName(leaveType)
            .EnterEntitlement(entitlement)
            .ClickSaveButton()
            .ClickConfirmButton();
    }
}