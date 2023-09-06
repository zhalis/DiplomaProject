namespace DiplomaProject.UI.Framework.Element.DropDowns;

public class AutocompleteDropDown : DropDown
{
    private const string InputByLabelPattern = "//*[.//text()='{0}'][contains(@class,'oxd-input-group')]//input";
    private const string AutocompleteDropDownOptionPattern =
        "//*[contains(@class,'oxd-autocomplete-dropdown')]//*[contains(text(),'{0}')]";

    private AutocompleteDropDown(string dropDownLabel) : base(dropDownLabel)
    {
    }

    public static AutocompleteDropDown ByLabel(string dropDownLabel) =>
        new(dropDownLabel);

    public override void SelectValue(string value) =>
        EnterValue(value)
            .SelectOptionInOpenedMenu(value);

    private AutocompleteDropDown EnterValue(string value)
    {
        Element.ByXPath(InputByLabelPattern, DropDownLabel).SendKeys(value);

        return this;
    }

    private void SelectOptionInOpenedMenu(string selectOption) =>
        Element.ByXPath(AutocompleteDropDownOptionPattern, selectOption).Click();
}