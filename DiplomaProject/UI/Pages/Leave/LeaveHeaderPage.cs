using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.Leave;

public class LeaveHeaderPage : BasePage
{
    private const string LeaveHeaderTitle = "Leave";

    private const string AddEntitlementsLink = "Add Entitlements";

    private const string AssignLeaveLink = "Assign Leave";

    private readonly DropDown _entitlementsDropDown = HeaderDropDown.ByLabel("Entitlements ");

    public bool IsLeaveHeaderTitleDisplayed() => IsHeaderDisplayed(LeaveHeaderTitle);

    public AssignLeavePage ClickAssignButton()
    {
        ClickLinkByName(AssignLeaveLink);

        return new AssignLeavePage();
    }

    public AddEntitlementsPage OpenAddEntitlementsPage()
    {
        _entitlementsDropDown.SelectValue(AddEntitlementsLink);

        return new AddEntitlementsPage();
    }
}