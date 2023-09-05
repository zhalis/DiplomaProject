using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.Recruitment;

public class AddVacancyPage : BasePage
{
    private const string AddVacancyTitle = "Add Vacancy";

    private readonly Element _vacancyNameInput = Element.ByXPath(InputByLabelNamePattern, "Vacancy Name");

    private readonly DropDown _jobTitleDropDown = SelectDropDown.ByLabel("Job Title");

    private readonly DropDown _hiringManagerDropDown = AutocompleteDropDown.ByLabel("Hiring Manager");

    public bool IsAddVacancyTitleDisplayed() => IsHeaderDisplayed(AddVacancyTitle);

    public AddVacancyPage EnterVacancyName(string vacancyName)
    {
        _vacancyNameInput.SendKeys(vacancyName);

        return this;
    }

    public AddVacancyPage SelectJobTitle(string jobTitle)
    {
        _jobTitleDropDown.SelectValue(jobTitle);

        return this;
    }

    public AddVacancyPage EnterHiringManagerName(string hiringManagerName)
    {
        _hiringManagerDropDown.SelectValue(hiringManagerName);

        return this;
    }

    public void ClickSaveButton() => ButtonTypeSubmit.Click();
}