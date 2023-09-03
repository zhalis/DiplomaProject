using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Recruitment;

public class AddVacancyPage : BasePage
{
    private readonly Element _addVacancyTitle = Element.ByXPath(HeaderByTextPattern, "Add Vacancy");

    private readonly Element _vacancyNameInput = Element.ByXPath(
            "//label[text()='Vacancy Name']//ancestor::div[contains(@class,'oxd-input')]//input[contains(@class,'oxd-input')]");

    private readonly Element _jobTitleDropDownArrow =
        Element.ByXPath("//div[@class='oxd-select-text--after']//i[contains(@class,'bi-caret-down-fill')]");
    
    private readonly Element _hiringManagerInput = Element.ByXPath(InputByPlaceholderPattern, "Type for hints...");
    
    private readonly Element _saveButton = Element.ByXPath(ButtonTypeSubmit);

    public bool IsAddVacancyTitleDisplayed() => _addVacancyTitle.IsDisplayed();

    public AddVacancyPage EnterVacancyName(string vacancyName)
    {
        _vacancyNameInput.Type(vacancyName);

        return this;
    }

    public AddVacancyPage ClickJobTitleDropDownArrow()
    {
        _jobTitleDropDownArrow.Click();

        return this;
    }

    public AddVacancyPage ClickJobTitleDropDownOptionByName(string jobTitle)
    {
        Element.ByXPath(SelectDropDownOptionPattern, jobTitle).Click();

        return this;
    }

    public AddVacancyPage EnterHiringManagerName(string hiringManagerName)
    {
        _hiringManagerInput.Type(hiringManagerName);

        return this;
    }

    public AddVacancyPage ClickManagerDropDownOptionByName(string hiringManager)
    {
        Element.ByXPath(AutocompleteDropDownOptionPattern, hiringManager).Click();

        return this;
    }

    public void ClickSaveButton() => _saveButton.Click();
}