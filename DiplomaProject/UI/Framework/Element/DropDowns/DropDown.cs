namespace DiplomaProject.UI.Framework.Element.DropDowns;

public abstract class DropDown
{
    protected readonly string DropDownLabel;

    protected DropDown(string dropDownLabel)
    {
        DropDownLabel = dropDownLabel;
    }

    public abstract void SelectValue(string value);
}