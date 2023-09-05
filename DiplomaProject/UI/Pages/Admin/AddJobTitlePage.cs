using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Admin;

public class AddJobTitlePage : BasePage
{
    private const string AddJobTitleHeader = "Add Job Title";

    private readonly Element _jobTitleInput = Element.ByXPath(InputByLabelNamePattern, "Job Title");

    public string GetJobTitleInputValue() => _jobTitleInput.GetAttributeValue(Attributes.ValueCssProperty);

    public bool IsAddJobTitleHeaderDisplayed() => IsHeaderDisplayed(AddJobTitleHeader);

    public AddJobTitlePage TypeJobTitle(string jobTitle)
    {
        _jobTitleInput.SendKeys(jobTitle);

        return this;
    }

    public void ClickSaveButton() => ButtonTypeSubmit.Click();
}