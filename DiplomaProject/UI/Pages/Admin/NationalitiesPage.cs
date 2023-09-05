using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Admin;

public class NationalitiesPage : BasePage
{
    private const string NationalitiesTitleHeader = "Nationalities";

    private const string NationalityColumnName = "Nationality";

    private readonly Table _nationalities = new();

    public bool IsNationalitiesTableTitleDisplayed() => IsHeaderDisplayed(NationalitiesTitleHeader);

    public EditNationalityPage ClickEditButtonByNationalityName(string nationalityName)
    {
        _nationalities.ClickEditButtonByColumnValue(nationalityName);

        return new EditNationalityPage();
    }

    public List<string> GetNationalitiesNames() =>
        _nationalities.GetElementsByColumn(NationalityColumnName);
}