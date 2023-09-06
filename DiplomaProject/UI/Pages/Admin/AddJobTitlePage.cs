using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Admin;

public class AddJobTitlePage : BasePage
{
    private const string AddJobTitleHeader = "Add Job Title";
    private readonly Element _jobTitleInput = Element.ByXPath(InputByLabelNamePattern, "Job Title");
    public string GetJobTitleInputValue() => _jobTitleInput.GetAttributeValue(Attributes.ValueCssProperty);

    public bool IsAddJobTitleHeaderDisplayed() => IsHeaderDisplayed(AddJobTitleHeader);

    public AddJobTitlePage TypeJobTitle(string jobTitle) =>
        ExecuteInChain<AddJobTitlePage>(() => _jobTitleInput.SendKeys(jobTitle));

    public void ClickSaveButton() => ButtonTypeSubmit.Click();
}