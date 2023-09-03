using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.PIM;

public class AddEmployeePage : BasePage
{
    private readonly Element _addEmployeeTitle = Element.ByXPath(HeaderByTextPattern, "Add Employee");

    private readonly Element _firstNameInput = Element.ByXPath(InputByPlaceholderPattern, "First Name");

    private readonly Element _lastNameInput = Element.ByXPath(InputByPlaceholderPattern, "Last Name");

    private readonly Element _employeeIdInput = Element.ByXPath(
        "//label[text()='Employee Id']/parent::div[contains(@class,'label-wrapper')]" +
        "//following-sibling::div//input[contains(@class,'oxd-input')]");

    private readonly Element _saveButton = Element.ByXPath(ButtonTypeSubmit);

    public bool IsAddEmployeeTitleDisplayed() => _addEmployeeTitle.IsDisplayed();

    public AddEmployeePage EnterFirstName(string firstName)
    {
        _firstNameInput.Type(firstName);

        return this;
    }

    public AddEmployeePage EnterLastName(string lastName)
    {
        _lastNameInput.Type(lastName);

        return this;
    }

    public string GetFirstNameInputValue() => _firstNameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public string GetLastNameInputValue() => _lastNameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public string GetEmployeeId() => _employeeIdInput.GetAttributeValue(Attributes.ValueCssProperty);

    public PersonalDetailsPage ClickSaveButton()
    {
        _saveButton.Click();

        return new PersonalDetailsPage();
    }
}