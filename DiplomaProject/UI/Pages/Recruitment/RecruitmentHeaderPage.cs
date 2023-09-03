using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Recruitment;

public class RecruitmentHeaderPage : BasePage
{
    private readonly Element _vacanciesButton = Element.ByXPath(LinkByTextPattern, "Vacancies");
    
    private readonly Element _candidatesButton = Element.ByXPath(LinkByTextPattern, "Candidates");

    public VacanciesPage ClickVacanciesButton()
    {
        _vacanciesButton.Click();

        return new VacanciesPage();
    }

    public CandidatesPage ClickCandidatesButton()
    {
        _candidatesButton.Click();

        return new CandidatesPage();
    }
}