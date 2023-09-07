using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Recruitment;

public class AddCandidatePage : BasePage
{
    private const string AddCandidateTitle = "Add Candidate";
    private readonly Element _firstNameInput = Element.ByXPath(InputByPlaceholderPattern, "First Name");
    private readonly Element _lastNameInput = Element.ByXPath(InputByPlaceholderPattern, "Last Name");
    private readonly Element _emailInput = Element.ByXPath(InputByLabelNamePattern, "Email");

    public bool IsAddCandidateTitleDisplayed() => IsHeaderDisplayed(AddCandidateTitle);

    public AddCandidatePage EnterFirstName(string firstName) =>
        ExecuteInChain<AddCandidatePage>(() => _firstNameInput.SendKeys(firstName));

    public AddCandidatePage EnterLastName(string lastName) =>
        ExecuteInChain<AddCandidatePage>(() => _lastNameInput.SendKeys(lastName));

    public AddCandidatePage EnterEmail(string email) =>
        ExecuteInChain<AddCandidatePage>(() => _emailInput.SendKeys(email));

    public AddCandidatePage ClickSaveButton() => ExecuteInChain<AddCandidatePage>(ButtonTypeSubmit.Click);
}