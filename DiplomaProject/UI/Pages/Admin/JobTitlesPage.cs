using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Admin;

public class JobTitlesPage : BasePage
{
    private const string TrashBinButtonByJobTitlePattern =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//i[contains(@class,'bi-trash')]";

    private const string CheckboxByJobTitleNamePattern =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//span[contains(@class,'oxd-checkbox-input')]";

    private const string CheckboxInputByJobTitleNamePattern =
        "//div[text()='{0}']//ancestor::div[contains(@class,'oxd-table-row')]//input[@type='checkbox']";

    private readonly Element _jobTitleHeader = Element.ByXPath(HeaderByTextPattern, "Job Titles");

    private readonly Element _addButton = Element.ByXPath("//button[contains(@class,'oxd-button')]");

    private readonly Element _jobTitle = Element.ByXPath("//div[contains(@class,'oxd-table-cell')][2]/div");

    private readonly Element _deleteSelectedButton = Element.ByXPath(
        "//button[contains(@class,'oxd-button')]//i[contains(@class,'bi-trash-fill')]");

    public bool IsCheckboxSelectedByJobTitleName(string jobTitle) =>
        bool.Parse(Element.ByXPath(CheckboxInputByJobTitleNamePattern, jobTitle)
            .GetAttributeValue(Attributes.CheckedCssProperty));

    public bool IsJobTitlesHeaderDisplayed() => _jobTitleHeader.IsDisplayed();

    public AddJobTitlePage ClickAddButton()
    {
        _addButton.Click();

        return new AddJobTitlePage();
    }

    public IEnumerable<string> GetJobTitlesText() =>
        _jobTitle.WaitForPresenceOfAllElements().Select(title => title.Text);

    public ConfirmationPopUp ClickTrashBinButtonByJobTitle(string jobTitle)
    {
        Element.ByXPath(TrashBinButtonByJobTitlePattern, jobTitle).Click();

        return new ConfirmationPopUp();
    }

    public JobTitlesPage ClickCheckboxByJobTitleName(string jobTitle)
    {
        Element.ByXPath(CheckboxByJobTitleNamePattern, jobTitle).Click();

        return this;
    }

    public ConfirmationPopUp ClickDeleteSelectedButton()
    {
        _deleteSelectedButton.Click();

        return new ConfirmationPopUp();
    }
}