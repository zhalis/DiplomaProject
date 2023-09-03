using DiplomaProject.UI.Pages.Leave;

namespace DiplomaProject.UI.Services;

public class AssignLeaveService
{
    private readonly AssignLeavePage _assignLeavePage = new();

    public AssignLeavePage FillInAssignLeaveForm(string employeeName, string leaveType, string comment)
    {
        _assignLeavePage.WaitLoadingSpinnerInvisibility();
        return _assignLeavePage
            .EnterEmployeeName(employeeName)
            .ClickAutocompleteOptionByName(employeeName)
            .ClickLeaveTypeDropDownArrow()
            .ClickSelectOptionByName(leaveType)
            .ClickFromDateCalendarIcon()
            .ClickTodayButtonInCalendarDropDown()
            .ClickToDateCalendarIcon()
            .ClickTodayButtonInCalendarDropDown()
            .EnterComment(comment);
    }
}