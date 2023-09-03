using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Admin;

public class AddJobTitlePage : BasePage
{
    private readonly Element _saveButton = Element.ByXPath(ButtonTypeSubmit);

    private readonly Element _addJobTitleHeader = Element.ByXPath(HeaderByTextPattern, "Add Job Title");

    private readonly Element _jobTitleInput =
        Element.ByXPath("//label[text()='Job Title']/parent::div[contains(@class,'label-wrapper')]" +
                        "//following-sibling::div//input[contains(@class,'oxd-input')]");

    public string GetJobTitleInputValue() => _jobTitleInput.GetAttributeValue(Attributes.ValueCssProperty);

    public bool IsAddJobTitleHeaderDisplayed() => _addJobTitleHeader.IsDisplayed();

    public AddJobTitlePage TypeJobTitle(string jobTitle)
    {
        _jobTitleInput.Type(jobTitle);

        return this;
    }

    public JobTitlesPage ClickSaveButton()
    {
        _saveButton.Click();

        return new JobTitlesPage();
    }
}