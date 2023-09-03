using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Admin;

public class NationalitiesPage : BasePage
{
    private const string EditButtonByNationalityNamePattern =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//i[contains(@class,'bi-pencil-fill')]";

    private readonly Element _nationalitiesTitleHeader = Element.ByXPath(HeaderByTextPattern, "Nationalities");
    private readonly Element _nationalityNameFromTable = Element.ByXPath("//div[contains(@class,'oxd-table-cell')][2]");

    public bool IsNationalitiesTableTitleDisplayed() => _nationalitiesTitleHeader.IsDisplayed();

    public EditNationalityPage ClickEditButtonByNationalityName(string nationalityName)
    {
        Element.ByXPath(EditButtonByNationalityNamePattern, nationalityName).Click();

        return new EditNationalityPage();
    }

    public IEnumerable<string> GetNationalitiesNames() =>
        _nationalityNameFromTable.WaitForPresenceOfAllElements()
            .Select(nationality => nationality.Text);
}