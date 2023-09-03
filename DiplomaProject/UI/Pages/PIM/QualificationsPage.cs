using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.PIM;

public class QualificationsPage : BasePage
{
    private readonly Element _qualificationsTitle = Element.ByXPath(HeaderByTextPattern, "Qualifications");

    private readonly Element _addSkillTitle = Element.ByXPath(HeaderByTextPattern, "Add Skill");

    private readonly Element _addSkillButton = Element.ByXPath(
        "//h6[text()='Skills']/parent::div//button[@type='button' and contains(@class,'oxd-button--text')]");

    private readonly Element _skillDropDownArrow =
        Element.ByXPath("//label[text()='Skill']//ancestor::div[contains(@class,'oxd-input-group')]" +
                        "//i[contains(@class,'bi-caret-down-fill')]");

    private readonly Element _skillFromSkillList = Element.ByXPath(
        "//h6[text()='Skills']//ancestor::div[contains(@class,'orangehrm-horizontal-padding')]" +
        "//following-sibling::div//div[contains(@class,'oxd-table-cell')][2]");

    private readonly Element _saveButton = Element.ByXPath(ButtonTypeSubmit);

    public bool IsQualificationsTitleDisplayed() => _qualificationsTitle.IsDisplayed();
    
    public bool IsAddSkillTitleDisplayed() => _addSkillTitle.IsDisplayed();

    public IEnumerable<string> GetSkillNamesFromSkillList() =>
        _skillFromSkillList.WaitForPresenceOfAllElements().Select(skill => skill.Text);

    public QualificationsPage ClickAddSkillButton()
    {
        _addSkillButton.Click();

        return this;
    }

    public QualificationsPage ClickSkillDropDownArrow()
    {
        _skillDropDownArrow.Click();

        return this;
    }

    public QualificationsPage ClickSelectOptionByName(string selectOption)
    {
        Element.ByXPath(SelectDropDownOptionPattern, selectOption).Click();

        return this;
    }

    public QualificationsPage ClickSaveButton()
    {
        _saveButton.Click();

        return this;
    }
}