using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.PIM;

public class AddCustomFieldPage : BasePage
{
    private const string DropDownArrowPattern =
        "//label[text()='{0}']//ancestor::div[contains(@class,'oxd-input-group')]" +
        "//i[contains(@class,'bi-caret-down-fill')]";

    private readonly Element _addCustomFieldTitle = Element.ByXPath(HeaderByTextPattern, "Add Custom Field");
    
    private readonly Element _fieldNameInput =
        Element.ByXPath("//label[text()='Field Name']//ancestor::div[contains(@class,'oxd-input-group')]" +
                        "//input[contains(@class,'oxd-input')]");
    
    private readonly Element _screenDropDownArrow = Element.ByXPath(DropDownArrowPattern, "Screen");
    
    private readonly Element _typeDropDownArrow = Element.ByXPath(DropDownArrowPattern, "Type");
    
    private readonly Element _saveButton = Element.ByXPath(ButtonTypeSubmit);

    public bool IsAddCustomFieldTitleDisplayed() => _addCustomFieldTitle.IsDisplayed();

    public AddCustomFieldPage EnterFieldName(string fieldName)
    {
        _fieldNameInput.Type(fieldName);

        return this;
    }

    public AddCustomFieldPage ClickTypeDropDownArrow()
    {
        _typeDropDownArrow.Click();

        return this;
    }

    public AddCustomFieldPage ClickScreenDropDownArrow()
    {
        _screenDropDownArrow.Click();

        return this;
    }

    public AddCustomFieldPage ClickSelectOptionByName(string selectOption)
    {
        Element.ByXPath(SelectDropDownOptionPattern, selectOption).Click();

        return this;
    }

    public CustomFieldsPage ClickSaveButton()
    {
        _saveButton.Click();

        return new CustomFieldsPage();
    }
}