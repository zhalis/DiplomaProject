namespace DiplomaProject.UI.Pages.Recruitment;

public class RecruitmentHeaderPage : BasePage
{
    private const string VacanciesLink = "Vacancies";

    private const string CandidatesLink = "Candidates";

    public VacanciesPage ClickVacanciesButton()
    {
        ClickLinkByName(VacanciesLink);

        return new VacanciesPage();
    }

    public CandidatesPage ClickCandidatesButton()
    {
        ClickLinkByName(CandidatesLink);

        return new CandidatesPage();
    }
}