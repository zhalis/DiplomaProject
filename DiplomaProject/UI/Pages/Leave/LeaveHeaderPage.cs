using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Leave;

public class LeaveHeaderPage : BasePage
{
    private readonly Element _leaveHeaderTitle = Element.ByXPath(HeaderByTextPattern, "Leave");
    
    private readonly Element _entitlementsDropDownMenu = Element.ByXPath(SpanByTextPattern, "Entitlements ");
    
    private readonly Element _addEntitlementsLinkInDropDown = Element.ByXPath(LinkByTextPattern, "Add Entitlements");

    private readonly Element _assignLeaveButtonInTopBarMenu =
        Element.ByXPath("//li[contains(@class,'oxd-topbar-body-nav-tab')]//a[text()='Assign Leave']");

    public bool IsLeaveHeaderTitleDisplayed() => _leaveHeaderTitle.IsDisplayed();

    public AssignLeavePage ClickAssignButton()
    {
        _assignLeaveButtonInTopBarMenu.Click();

        return new AssignLeavePage();
    }

    public LeaveHeaderPage ClickEntitlementsDropDownMenu()
    {
        _entitlementsDropDownMenu.Click();

        return this;
    }

    public AddEntitlementsPage ClickAddEntitlementsLink()
    {
        _addEntitlementsLinkInDropDown.Click();

        return new AddEntitlementsPage();
    }
}