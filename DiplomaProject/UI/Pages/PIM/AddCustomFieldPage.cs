using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.PIM;

public class AddCustomFieldPage : BasePage
{
    private const string AddCustomFieldTitle = "Add Custom Field";

    private readonly Element _fieldNameInput = Element.ByXPath(InputByLabelNamePattern, "Field Name");

    private readonly DropDown _screenDropDown = SelectDropDown.ByLabel("Screen");

    private readonly DropDown _typeDropDown = SelectDropDown.ByLabel("Type");

    public bool IsAddCustomFieldTitleDisplayed() => IsHeaderDisplayed(AddCustomFieldTitle);

    public AddCustomFieldPage EnterFieldName(string fieldName)
    {
        _fieldNameInput.SendKeys(fieldName);

        return this;
    }

    public AddCustomFieldPage SelectScreen(string screen)
    {
        _screenDropDown.SelectValue(screen);

        return this;
    }

    public AddCustomFieldPage SelectType(string type)
    {
        _typeDropDown.SelectValue(type);

        return this;
    }

    public void ClickSaveButton()
    {
        ButtonTypeSubmit.Click();
    }
}