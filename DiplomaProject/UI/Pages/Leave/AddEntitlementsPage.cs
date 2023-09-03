using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Leave;

public class AddEntitlementsPage : BasePage
{
    private readonly Element _saveButton = Element.ByXPath(ButtonTypeSubmit);

    private readonly Element _employeeNameInput = Element.ByXPath(InputByPlaceholderPattern, "Type for hints...");

    private readonly Element _leaveTypeDropDownArrow =
        Element.ByXPath("//label[text()='Leave Type']//ancestor::div[contains(@class,'oxd-input-group')]" +
                        "//i[contains(@class,'bi-caret-down-fill')]");

    private readonly Element _entitlementInput =
        Element.ByXPath("//label[text()='Entitlement']//ancestor::div[contains(@class,'oxd-input-group')]" +
                        "//input[contains(@class,'oxd-input')]");

    public AddEntitlementsPage EnterEmployeeName(string employeeName)
    {
        _employeeNameInput.Type(employeeName);

        return this;
    }

    public AddEntitlementsPage ClickLeaveTypeDropDownArrow()
    {
        _leaveTypeDropDownArrow.Click();

        return this;
    }

    public AddEntitlementsPage ClickSelectOptionByName(string selectOption)
    {
        Element.ByXPath(SelectDropDownOptionPattern, selectOption).Click();

        return this;
    }

    public AddEntitlementsPage ClickAutocompleteOptionByName(string autocompleteOption)
    {
        Element.ByXPath(AutocompleteDropDownOptionPattern, autocompleteOption).Click();

        return this;
    }

    public AddEntitlementsPage EnterEntitlement(string entitlement)
    {
        _entitlementInput.Type(entitlement);

        return this;
    }

    public ConfirmationPopUp ClickSaveButton()
    {
        _saveButton.Click();

        return new ConfirmationPopUp();
    }
}