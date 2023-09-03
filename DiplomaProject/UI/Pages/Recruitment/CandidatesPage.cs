using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Recruitment;

public class CandidatesPage : BasePage
{
    private const string CheckboxByCandidateNamePattern =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//span";

    private const string CheckboxInputByCandidateNamePattern =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//input[@type='checkbox']";

    private readonly Element _addButton =
        Element.ByXPath("//button[@type='button' and contains(@class,'oxd-button--secondary')]");

    private readonly Element _deleteSelectedButton = Element.ByXPath(
        "//button[contains(@class,'oxd-button')]//i[contains(@class,'bi-trash-fill')]");

    private readonly Element _candidateNameFromList =
        Element.ByXPath("//div[@class='oxd-table-card']//div[contains(@class,'oxd-table-cell')][3]/div");

    public CandidatesPage ClickCheckboxByCandidateName(string candidateName)
    {
        Element.ByXPath(CheckboxByCandidateNamePattern, candidateName).Click();

        return this;
    }

    public bool IsCheckboxCheckedByCandidateName(string candidateName) =>
        bool.Parse(Element.ByXPath(CheckboxInputByCandidateNamePattern, candidateName)
            .GetAttributeValue(Attributes.CheckedCssProperty));

    public IEnumerable<string> GetCandidatesNames() =>
        _candidateNameFromList.WaitForPresenceOfAllElements().Select(username => username.Text);

    public AddCandidatePage ClickAddButton()
    {
        _addButton.Click();

        return new AddCandidatePage();
    }

    public ConfirmationPopUp ClickDeleteSelectedButton()
    {
        _deleteSelectedButton.Click();

        return new ConfirmationPopUp();
    }
}