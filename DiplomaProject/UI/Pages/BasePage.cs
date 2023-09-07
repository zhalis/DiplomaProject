using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.WebDriver;

namespace DiplomaProject.UI.Pages;

public abstract class BasePage
{
    protected const string InputByPlaceholderPattern = "//input[@placeholder='{0}']";
    protected const string SpanByTextPattern = "//span[text()='{0}']";
    protected const string InputByLabelNamePattern = "//*[text()='{0}']/parent::div//following-sibling::div//input";
    protected readonly Element ButtonTypeSubmit = Element.ByXPath("//*[@type='submit']");
    private const string SuccessfulPopUpPattern = "//*[contains(@class,'oxd-toast--success')]//p[text()='{0}']";
    private const string HeaderByTextPattern = "//h6[text()='{0}']";
    private const string LinkByTextPattern = "//a[text()='{0}']";
    private readonly Element _loadingSpinner = Element.ByXPath("//*[@class='oxd-loading-spinner-container']");
    private readonly Element _successfulSavePopUp =
        Element.ByXPath(SuccessfulPopUpPattern, "Successfully Saved");
    private readonly Element _successfulDeletePopUp =
        Element.ByXPath(SuccessfulPopUpPattern, "Successfully Deleted");

    public static void RefreshPage() => WebDriverSingleton.GetDriver.Navigate().Refresh();

    public bool IsSavedSuccessfullyPopUpDisplayed() => _successfulSavePopUp.IsDisplayed();

    public bool IsDeletedSuccessfullyPopUpDisplayed() => _successfulDeletePopUp.IsDisplayed();

    public void WaitLoadingSpinnerInvisibility() => _loadingSpinner.WaitForInvisibility();

    protected bool IsHeaderDisplayed(string headerName) =>
        Element.ByXPath(HeaderByTextPattern, headerName).IsDisplayed();

    protected void ClickLinkByName(string linkName) => Element.ByXPath(LinkByTextPattern, linkName).Click();

    protected T ExecuteInChain<T>(Action action) where T : BasePage
    {
        action.Invoke();

        return (T)this;
    }
}