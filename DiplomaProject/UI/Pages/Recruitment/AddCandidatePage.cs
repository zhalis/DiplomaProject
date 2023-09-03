using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Recruitment;

public class AddCandidatePage : BasePage
{
    private readonly Element _addCandidateTitle = Element.ByXPath(HeaderByTextPattern, "Add Candidate");
    
    private readonly Element _firstNameInput = Element.ByXPath(InputByPlaceholderPattern, "First Name");
    
    private readonly Element _lastNameInput = Element.ByXPath(InputByPlaceholderPattern, "Last Name");

    private readonly Element _emailInput =
        Element.ByXPath("//label[text()='Email']//ancestor::div[contains(@class,'oxd-input-group')]" +
                        "//input[contains(@class,'oxd-input')]");
    
    private readonly Element _saveButton = Element.ByXPath("//button[text()=' Save ']");

    public bool IsAddCandidateTitleDisplayed() => _addCandidateTitle.IsDisplayed();

    public AddCandidatePage EnterFirstName(string firstName)
    {
        _firstNameInput.Type(firstName);

        return this;
    }

    public AddCandidatePage EnterLastName(string lastName)
    {
        _lastNameInput.Type(lastName);

        return this;
    }

    public AddCandidatePage EnterEmail(string email)
    {
        _emailInput.Type(email);

        return this;
    }

    public AddCandidatePage ClickSaveButton()
    {
        _saveButton.Click();

        return this;
    }
}