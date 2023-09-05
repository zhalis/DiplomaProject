using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.PIM;

public class AddEmployeePage : BasePage
{
    private const string AddEmployeeTitle = "Add Employee";

    private readonly Element _firstNameInput = Element.ByXPath(InputByPlaceholderPattern, "First Name");

    private readonly Element _lastNameInput = Element.ByXPath(InputByPlaceholderPattern, "Last Name");

    private readonly Element _employeeIdInput = Element.ByXPath(InputByLabelNamePattern, "Employee Id");

    public bool IsAddEmployeeTitleDisplayed() => IsHeaderDisplayed(AddEmployeeTitle);

    public AddEmployeePage EnterFirstName(string firstName)
    {
        _firstNameInput.SendKeys(firstName);

        return this;
    }

    public AddEmployeePage EnterLastName(string lastName)
    {
        _lastNameInput.SendKeys(lastName);

        return this;
    }

    public string GetFirstNameInputValue() => _firstNameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public string GetLastNameInputValue() => _lastNameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public string GetEmployeeId() => _employeeIdInput.GetAttributeValue(Attributes.ValueCssProperty);

    public PersonalDetailsPage ClickSaveButton()
    {
        ButtonTypeSubmit.Click();

        return new PersonalDetailsPage();
    }
}