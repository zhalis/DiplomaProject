using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.Leave;

public class AssignLeavePage : BasePage
{
    private const string CalendarButtonPattern =
        "//*[.//text()='{0}'][contains(@class,'oxd-input-group')]//i[contains(@class,'bi-calendar')]";
    private const string AssignLeaveHeaderTitle = "Assign Leave";
    private readonly DropDown _leaveTypeDropDown = SelectDropDown.ByLabel("Leave Type");
    private readonly DropDown _employeeNameDropDown = AutocompleteDropDown.ByLabel("Employee Name");
    private readonly Element _fromDateCalendarIcon = Element.ByXPath(CalendarButtonPattern, "From Date");
    private readonly Element _toDateCalendarIcon = Element.ByXPath(CalendarButtonPattern, "To Date");
    private readonly Element _todayButtonInCalendarDropDown =
        Element.ByXPath("//*[contains(@class,'oxd-date-input-calendar')]//div[text()='Today']");
    private readonly Element _commentsInput = Element.ByXPath("//*[contains(@class,'oxd-textarea')]");

    public bool IsAssignLeaveTitleDisplayed() => IsHeaderDisplayed(AssignLeaveHeaderTitle);

    public AssignLeavePage SelectEmployeeName(string employeeName) =>
        ExecuteInChain<AssignLeavePage>(() => _employeeNameDropDown.SelectValue(employeeName));

    public AssignLeavePage SelectLeaveType(string leaveType) =>
        ExecuteInChain<AssignLeavePage>(() => _leaveTypeDropDown.SelectValue(leaveType));

    public AssignLeavePage ClickFromDateCalendarIcon() => ExecuteInChain<AssignLeavePage>(_fromDateCalendarIcon.Click);

    public AssignLeavePage ClickToDateCalendarIcon() =>
        ExecuteInChain<AssignLeavePage>(_toDateCalendarIcon.Click);

    public AssignLeavePage ClickTodayButtonInCalendarDropDown() =>
        ExecuteInChain<AssignLeavePage>(_todayButtonInCalendarDropDown.Click);

    public AssignLeavePage EnterComment(string comment) =>
        ExecuteInChain<AssignLeavePage>(() => _commentsInput.SendKeys(comment));

    public AssignLeavePage ClickAssignButton() => ExecuteInChain<AssignLeavePage>(ButtonTypeSubmit.Click);
}