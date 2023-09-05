using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Recruitment;

public class AddCandidatePage : BasePage
{
    private const string AddCandidateTitle = "Add Candidate";

    private readonly Element _firstNameInput = Element.ByXPath(InputByPlaceholderPattern, "First Name");

    private readonly Element _lastNameInput = Element.ByXPath(InputByPlaceholderPattern, "Last Name");

    private readonly Element _emailInput = Element.ByXPath(InputByLabelNamePattern, "Email");

    public bool IsAddCandidateTitleDisplayed() => IsHeaderDisplayed(AddCandidateTitle);

    public AddCandidatePage EnterFirstName(string firstName)
    {
        _firstNameInput.SendKeys(firstName);

        return this;
    }

    public AddCandidatePage EnterLastName(string lastName)
    {
        _lastNameInput.SendKeys(lastName);

        return this;
    }

    public AddCandidatePage EnterEmail(string email)
    {
        _emailInput.SendKeys(email);

        return this;
    }

    public AddCandidatePage ClickSaveButton()
    {
        ButtonTypeSubmit.Click();

        return this;
    }
}