namespace DiplomaProject.UI.Framework.Element.DropDowns;

public class SelectDropDown : DropDown
{
    private const string DropDownArrowPatternByLabel =
        "//*[text()='{0}']/parent::div//following-sibling::div//i[contains(@class,'bi-caret-down-fill')]";
    private const string SelectDropDownOptionPatternBySelectOption =
        "//*[contains(@class,'oxd-select-dropdown')]//*[contains(text(),'{0}')]";

    private SelectDropDown(string dropDownLabel) : base(dropDownLabel)
    {
    }

    public static SelectDropDown ByLabel(string dropDownLabel) =>
        new(dropDownLabel);

    public override void SelectValue(string value) =>
        ClickDropDownArrow()
            .SelectOptionInOpenedMenu(value);

    private SelectDropDown ClickDropDownArrow()
    {
        Element.ByXPath(DropDownArrowPatternByLabel, DropDownLabel).Click();

        return this;
    }

    private void SelectOptionInOpenedMenu(string option) =>
        Element.ByXPath(SelectDropDownOptionPatternBySelectOption, option).Click();
}