using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.PIM;

public class CustomFieldsPage : BasePage
{
    private const string TrashBinButtonByCustomFieldNamePattern =
        "//div[text()='{0}']/parent::div//following-sibling::div//i[contains(@class,'bi-trash')]";

    private readonly Element _customFieldsTitle = Element.ByXPath(HeaderByTextPattern, "Custom Fields");
    private readonly Element _addButton = Element.ByXPath("//button[contains(@class,'oxd-button ')]");

    public bool IsCustomFieldsTitleDisplayed() => _customFieldsTitle.IsDisplayed();

    public AddCustomFieldPage ClickAddButton()
    {
        _addButton.Click();

        return new AddCustomFieldPage();
    }

    public ConfirmationPopUp ClickTrashBinButtonBuCustomFieldName(string fieldName)
    {
        Element.ByXPath(TrashBinButtonByCustomFieldNamePattern, fieldName).Click();

        return new ConfirmationPopUp();
    }
}