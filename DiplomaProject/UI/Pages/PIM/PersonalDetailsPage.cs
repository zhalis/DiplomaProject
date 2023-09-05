using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.PIM;

public class PersonalDetailsPage : BasePage
{
    private const string PersonalDetailsTitle = "Personal Details";

    private const string FieldLabelByNamePattern = "//*[text()='{0}']";

    private const string QualificationsLink = "Qualifications";

    private readonly Element _firstNameInput = Element.ByXPath(InputByPlaceholderPattern, "First Name");

    private readonly Element _saveButton =
        Element.ByXPath("//*[contains(@class,'orangehrm-horizontal-padding')]//*[@type='submit']");

    private readonly Element _customFieldsSaveButton =
        Element.ByXPath("//*[@class='orangehrm-custom-fields']//*[@type='submit']");

    public bool IsPersonalTitleDisplayed() => IsHeaderDisplayed(PersonalDetailsTitle);

    public PersonalDetailsPage EnterNewFirstName(string firstName)
    {
        _firstNameInput.Click();
        _firstNameInput.ClearInputUsingBackspace();
        _firstNameInput.SendKeys(firstName);

        return this;
    }

    public string GetFirstNameInputValue() => _firstNameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public PersonalDetailsPage ClickSaveButton()
    {
        _saveButton.Click();

        return this;
    }

    public bool IsFieldDisplayed(string fieldLabel) =>
        Element.ByXPath(FieldLabelByNamePattern, fieldLabel).IsDisplayed();

    public PersonalDetailsPage EnterFieldValue(string fieldLabel, string value)
    {
        Element.ByXPath(InputByLabelNamePattern, fieldLabel).SendKeys(value);

        return this;
    }

    public PersonalDetailsPage ClickCustomFieldsSaveButton()
    {
        _customFieldsSaveButton.Click();

        return this;
    }

    public QualificationsPage ClickQualificationsTab()
    {
        ClickLinkByName(QualificationsLink);

        return new QualificationsPage();
    }
}