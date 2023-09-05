namespace DiplomaProject.UI.Framework.Element.DropDowns;

public class HeaderDropDown : DropDown
{
    private const string SpanByTextPattern = "//span[text()='{0}']";

    private const string LinkByTextPattern = "//a[text()='{0}']";

    private HeaderDropDown(string dropDownLabel) : base(dropDownLabel)
    {
    }

    public static HeaderDropDown ByLabel(string dropDownLabel) =>
        new(dropDownLabel);

    public static bool IsDropDownMenuDisplayed() =>
        Element.ByXPath("//ul[@class='oxd-dropdown-menu']").IsDisplayed();

    public override void SelectValue(string value) =>
        OpenDropDownMenu()
            .SelectOptionInOpenedMenu(value);

    public bool IsOptionDisplayedInDropDown(string option) =>
        Element.ByXPath(LinkByTextPattern, option).IsDisplayed();

    public HeaderDropDown OpenDropDownMenu()
    {
        Element.ByXPath(SpanByTextPattern, DropDownLabel).Click();

        return this;
    }

    public void SelectOptionInOpenedMenu(string option) =>
        Element.ByXPath(LinkByTextPattern, option).Click();
}