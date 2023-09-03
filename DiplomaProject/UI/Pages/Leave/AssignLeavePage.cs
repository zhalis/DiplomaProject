using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Leave;

public class AssignLeavePage : BasePage
{
    private const string CalendarButtonPattern =
        "//label[text()='{0}']//ancestor::div[contains(@class,'oxd-input-group')]//i[contains(@class,'bi-calendar')]";

    private readonly Element _assignLeaveHeaderTitle = Element.ByXPath(HeaderByTextPattern, "Assign Leave");

    private readonly Element _employeeNameInput = Element.ByXPath(InputByPlaceholderPattern, "Type for hints...");

    private readonly Element _leaveTypeDropDownArrow =
        Element.ByXPath("//div[@class='oxd-select-text--after']//i[contains(@class,'bi-caret-down-fill')]");

    private readonly Element _fromDateCalendarIcon = Element.ByXPath(CalendarButtonPattern, "From Date");

    private readonly Element _toDateCalendarIcon = Element.ByXPath(CalendarButtonPattern, "To Date");

    private readonly Element _todayButtonInCalendarDropDown =
        Element.ByXPath("//div[contains(@class,'oxd-date-input-calendar')]//div[text()='Today']");

    private readonly Element _commentsInput = Element.ByXPath("//textarea[contains(@class,'oxd-textarea')]");

    private readonly Element _assignButton = Element.ByXPath(ButtonTypeSubmit);

    public bool IsAssignLeaveTitleDisplayed() => _assignLeaveHeaderTitle.IsDisplayed();

    public AssignLeavePage EnterEmployeeName(string employeeName)
    {
        _employeeNameInput.Type(employeeName);

        return this;
    }

    public AssignLeavePage ClickAutocompleteOptionByName(string autocompleteOption)
    {
        Element.ByXPath(AutocompleteDropDownOptionPattern, autocompleteOption).Click();

        return this;
    }

    public AssignLeavePage ClickLeaveTypeDropDownArrow()
    {
        _leaveTypeDropDownArrow.Click();

        return this;
    }

    public AssignLeavePage ClickSelectOptionByName(string selectOption)
    {
        Element.ByXPath(SelectDropDownOptionPattern, selectOption).Click();

        return this;
    }

    public AssignLeavePage ClickFromDateCalendarIcon()
    {
        _fromDateCalendarIcon.Click();

        return this;
    }

    public AssignLeavePage ClickToDateCalendarIcon()
    {
        _toDateCalendarIcon.Click();

        return this;
    }

    public AssignLeavePage ClickTodayButtonInCalendarDropDown()
    {
        _todayButtonInCalendarDropDown.Click();

        return this;
    }

    public AssignLeavePage EnterComment(string comment)
    {
        _commentsInput.Type(comment);

        return this;
    }

    public AssignLeavePage ClickAssignButton()
    {
        _assignButton.Click();

        return this;
    }
}