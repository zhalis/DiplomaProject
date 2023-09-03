using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.PIM;

public class PersonalDetailsPage : BasePage
{
    private const string FieldLabelByNamePattern = "//label[text()='{0}']";

    private const string FieldInputByLabelNamePattern =
        "//label[text()='{0}']//ancestor::div[contains(@class,'oxd-input-group')]" +
        "//input[contains(@class,'oxd-input')]";

    private readonly Element _personalDetailsTitle = Element.ByXPath(HeaderByTextPattern, "Personal Details");
    
    private readonly Element _firstNameInput = Element.ByXPath(InputByPlaceholderPattern, "First Name");
    
    private readonly Element _qualificationsTab = Element.ByXPath(LinkByTextPattern, "Qualifications");

    private readonly Element _saveButton =
        Element.ByXPath("//div[contains(@class,'orangehrm-horizontal-padding')]//button[@type='submit']");

    private readonly Element _customFieldsSaveButton =
        Element.ByXPath("//div[@class='orangehrm-custom-fields']//button[@type='submit']");

    public bool IsPersonalTitleDisplayed() => _personalDetailsTitle.IsDisplayed();

    public PersonalDetailsPage EnterNewFirstName(string firstName)
    {
        _firstNameInput.Click();
        _firstNameInput.ClearInputUsingBackspace();
        _firstNameInput.Type(firstName);

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
        Element.ByXPath(FieldInputByLabelNamePattern, fieldLabel).Type(value);

        return this;
    }

    public PersonalDetailsPage ClickCustomFieldsSaveButton()
    {
        _customFieldsSaveButton.Click();

        return this;
    }

    public QualificationsPage ClickQualificationsTab()
    {
        _qualificationsTab.Click();

        return new QualificationsPage();
    }
}