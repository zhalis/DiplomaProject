using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.PIM;

public class CustomFieldsPage : BasePage
{
    private const string CustomFieldsTitle = "Custom Fields";
    private readonly Element _addButton = Element.ByXPath("//*[contains(@class,'oxd-button--medium')]");
    private readonly Table _customFields = new();

    public bool IsCustomFieldsTitleDisplayed() => IsHeaderDisplayed(CustomFieldsTitle);

    public AddCustomFieldPage ClickAddButton()
    {
        _addButton.Click();

        return new AddCustomFieldPage();
    }

    public ConfirmationPopUp ClickTrashBinButtonBuCustomFieldName(string fieldName)
    {
        _customFields.ClickTrashBinButtonByColumnValue(fieldName);

        return new ConfirmationPopUp();
    }
}