using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages;

public class ConfirmationPopUp
{
    private const string ConfirmationPopUpXPath = "//*[contains(@class,'oxd-sheet')]";

    private readonly Element _confirmationPopUp = Element.ByXPath(ConfirmationPopUpXPath);

    private readonly Element _yesButtonOnConfirmationPopUp =
        Element.ByXPath($"{ConfirmationPopUpXPath}//*[contains(@class,'oxd-button--label-danger')]");

    private readonly Element _confirmButtonOnConfirmationPopUp =
        Element.ByXPath($"{ConfirmationPopUpXPath}//*[contains(@class,'oxd-button--secondary')]");

    public bool IsConfirmationPopUpDisplayed() => _confirmationPopUp.IsDisplayed();

    public void ClickYesButton() => _yesButtonOnConfirmationPopUp.Click();

    public void ClickConfirmButton() => _confirmButtonOnConfirmationPopUp.Click();

    public ConfirmationPopUp WaitPopUpVisibility()
    {
        _confirmationPopUp.WaitForVisibility();

        return this;
    }
}