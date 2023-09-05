using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Recruitment;

public class CandidatesPage : BasePage
{
    private const string CandidateColumnName = "Candidate";

    private readonly Element _addButton =
        Element.ByXPath("//*[@type='button' and contains(@class,'oxd-button--secondary')]");

    private readonly Table _candidates = new();

    public CandidatesPage ClickCheckboxByCandidateName(string candidateName)
    {
        _candidates.ClickCheckboxByColumnValue(candidateName);

        return this;
    }

    public bool IsCheckboxCheckedByCandidateName(string candidateName) =>
        _candidates.IsCheckboxCheckedByColumnValue(candidateName);

    public List<string> GetCandidatesNames() =>
        _candidates.GetElementsByColumn(CandidateColumnName);

    public AddCandidatePage ClickAddButton()
    {
        _addButton.Click();

        return new AddCandidatePage();
    }

    public ConfirmationPopUp ClickDeleteSelectedButton()
    {
        _candidates.ClickDeleteSelected();

        return new ConfirmationPopUp();
    }
}