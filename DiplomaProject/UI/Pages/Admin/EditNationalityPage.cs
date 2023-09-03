using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Admin;

public class EditNationalityPage : BasePage
{
    private readonly Element _nameInput =
        Element.ByXPath("//div[@class='orangehrm-card-container']//input[contains(@class,'oxd-input')]");

    private readonly Element _saveButton = Element.ByXPath(ButtonTypeSubmit);

    public EditNationalityPage EnterNationalityName(string nationalityName)
    {
        _nameInput.Click();
        _nameInput.ClearInputUsingBackspace();
        _nameInput.Type(nationalityName);

        return this;
    }

    public string GetValueFromNameInput() => _nameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public NationalitiesPage ClickSaveButton()
    {
        _saveButton.Click();

        return new NationalitiesPage();
    }
}