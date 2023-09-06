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

    public AddCustomFieldPage EnterFieldName(string fieldName) =>
        ExecuteInChain<AddCustomFieldPage>(() => _fieldNameInput.SendKeys(fieldName));

    public AddCustomFieldPage SelectScreen(string screen) =>
        ExecuteInChain<AddCustomFieldPage>(() => _screenDropDown.SelectValue(screen));

    public AddCustomFieldPage SelectType(string type) =>
        ExecuteInChain<AddCustomFieldPage>(() => _typeDropDown.SelectValue(type));

    public void ClickSaveButton()
    {
        ButtonTypeSubmit.Click();
    }
}