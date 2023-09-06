using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.Element.DropDowns;

namespace DiplomaProject.UI.Pages.PIM;

public class QualificationsPage : BasePage
{
    private const string QualificationsTitle = "Qualifications";
    private const string AddSkillTitle = "Add Skill";
    private readonly Element _addSkillButton = Element.ByXPath("//*[.//text()='Skills']/*[@type='button']");
    private readonly DropDown _skillDropDown = SelectDropDown.ByLabel("Skill");
    private readonly Element _skillFromSkillList = Element.ByXPath(
        "//*[.//text()='Skill'][contains(@class,'oxd-table')]//div[contains(@class,'oxd-table-cell')][2]");

    public bool IsQualificationsTitleDisplayed() => IsHeaderDisplayed(QualificationsTitle);

    public bool IsAddSkillTitleDisplayed() => IsHeaderDisplayed(AddSkillTitle);

    public List<string> GetSkillNamesFromSkillList() =>
        _skillFromSkillList.WaitForPresenceOfAllElements().Select(skill => skill.Text).ToList();

    public QualificationsPage ClickAddSkillButton() =>
        ExecuteInChain<QualificationsPage>(() => _addSkillButton.Click());

    public QualificationsPage SelectSkill(string skillName) =>
        ExecuteInChain<QualificationsPage>(() => _skillDropDown.SelectValue(skillName));

    public QualificationsPage ClickSaveButton() =>
        ExecuteInChain<QualificationsPage>(() => ButtonTypeSubmit.Click());
}