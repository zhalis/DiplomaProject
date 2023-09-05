using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Recruitment;

public class VacanciesPage : BasePage
{
    private const string VacancyColumnName = "Vacancy";

    private readonly Element _vacanciesPageTitle = Element.ByXPath("//*[text()='Vacancies']");

    private readonly Element _addVacancyButton =
        Element.ByXPath("//*[@type='button']//*[contains(@class,'bi-plus')]");

    private readonly Table _vacancies = new();

    public bool IsVacanciesTitleDisplayed() => _vacanciesPageTitle.IsDisplayed();

    public AddVacancyPage ClickAddVacancyButton()
    {
        _addVacancyButton.Click();

        return new AddVacancyPage();
    }

    public ConfirmationPopUp ClickDeleteSelectedButton()
    {
        _vacancies.ClickDeleteSelected();

        return new ConfirmationPopUp();
    }

    public List<string> GetVacancies() =>
        _vacancies.GetElementsByColumn(VacancyColumnName);

    public VacanciesPage ClickVacancyCheckbox(string vacancy)
    {
        _vacancies.ClickCheckboxByColumnValue(vacancy);

        return this;
    }
}