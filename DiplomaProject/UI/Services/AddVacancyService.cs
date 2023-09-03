using DiplomaProject.UI.Pages.Recruitment;

namespace DiplomaProject.UI.Services;

public class AddVacancyService
{
    private readonly AddVacancyPage _addVacancyPage = new();

    public AddVacancyPage FillInAddVacancyForm(string vacancyName, string jobTitle, string hiringManager)
    {
        _addVacancyPage.WaitLoadingSpinnerInvisibility();
        return _addVacancyPage
            .EnterVacancyName(vacancyName)
            .ClickJobTitleDropDownArrow()
            .ClickJobTitleDropDownOptionByName(jobTitle)
            .EnterHiringManagerName(hiringManager)
            .ClickManagerDropDownOptionByName(hiringManager);
    }
}