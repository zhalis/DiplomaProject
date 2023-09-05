using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Admin;

public class EditNationalityPage : BasePage
{
    private readonly Element _nameInput = Element.ByXPath(InputByLabelNamePattern, "Name");

    public EditNationalityPage EnterNationalityName(string nationalityName)
    {
        _nameInput.Click();
        _nameInput.ClearInputUsingBackspace();
        _nameInput.SendKeys(nationalityName);

        return this;
    }

    public string GetValueFromNameInput() => _nameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public NationalitiesPage ClickSaveButton()
    {
        ButtonTypeSubmit.Click();

        return new NationalitiesPage();
    }
}