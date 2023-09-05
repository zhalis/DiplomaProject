using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Admin;

public class JobTitlesPage : BasePage
{
    private const string JobTitles = "Job Titles";

    private readonly Element _addButton = Element.ByXPath("//*[contains(@class,'oxd-button--medium')]");

    private readonly Table _jobTitles = new();

    public bool IsCheckboxSelectedByJobTitleName(string jobTitle) =>
        _jobTitles.IsCheckboxCheckedByColumnValue(jobTitle);

    public bool IsJobTitlesHeaderDisplayed() => IsHeaderDisplayed(JobTitles);

    public AddJobTitlePage ClickAddButton()
    {
        _addButton.Click();

        return new AddJobTitlePage();
    }

    public List<string> GetJobTitles() =>
        _jobTitles.GetElementsByColumn(JobTitles);

    public ConfirmationPopUp ClickTrashBinButtonByJobTitle(string jobTitle)
    {
        _jobTitles.ClickTrashBinButtonByColumnValue(jobTitle);

        return new ConfirmationPopUp();
    }

    public JobTitlesPage ClickCheckboxByJobTitleName(string jobTitle)
    {
       _jobTitles.ClickCheckboxByColumnValue(jobTitle);

        return this;
    }

    public ConfirmationPopUp ClickDeleteSelectedButton()
    {
        _jobTitles.ClickDeleteSelected();

        return new ConfirmationPopUp();
    }
}