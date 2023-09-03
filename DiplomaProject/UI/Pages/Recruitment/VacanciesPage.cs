using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Recruitment;

public class VacanciesPage : BasePage
{
    private readonly Element _vacanciesPageTitle = Element.ByXPath("//h5[text()='Vacancies']");

    private readonly Element _addVacancyButton =
        Element.ByXPath("//button[@type='button']//i[contains(@class,'bi-plus')]");

    private readonly Element _deleteSelectedButton = Element.ByXPath(
        "//button[contains(@class,'oxd-button')]//i[contains(@class,'bi-trash-fill')]");
    
    private readonly Element _vacancyNameFromList = Element.ByXPath("//div[contains(@class,'oxd-table-cell')][2]/div");

    private readonly string _vacancyCheckboxByVacancyName =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//span";

    public bool IsVacanciesTitleDisplayed() => _vacanciesPageTitle.IsDisplayed();

    public AddVacancyPage ClickAddVacancyButton()
    {
        _addVacancyButton.Click();

        return new AddVacancyPage();
    }

    public ConfirmationPopUp ClickDeleteSelectedButton()
    {
        _deleteSelectedButton.Click();

        return new ConfirmationPopUp();
    }

    public IEnumerable<string> GetVacanciesName() =>
        _vacancyNameFromList.WaitForPresenceOfAllElements().Select(vacancy => vacancy.Text);

    public VacanciesPage ClickVacancyCheckbox(string vacancy)
    {
        Element.ByXPath(_vacancyCheckboxByVacancyName, vacancy).Click();

        return this;
    }
}