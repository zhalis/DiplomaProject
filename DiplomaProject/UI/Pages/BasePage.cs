using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.WebDriver;

namespace DiplomaProject.UI.Pages;

public abstract class BasePage
{
    protected const string HeaderByTextPattern = "//h6[text()='{0}']";

    protected const string InputByPlaceholderPattern = "//input[@placeholder='{0}']";

    protected const string LinkByTextPattern = "//a[text()='{0}']";

    protected const string SpanByTextPattern = "//span[text()='{0}']";

    protected const string ButtonTypeSubmit = "//button[@type='submit']";

    protected const string SelectDropDownOptionPattern =
        "//div[contains(@class,'oxd-select-dropdown')]//span[contains(text(),'{0}')]";

    protected const string AutocompleteDropDownOptionPattern =
        "//div[contains(@class,'oxd-autocomplete-dropdown')]//span[contains(text(),'{0}')]";

    private const string SuccessfulPopUpPattern = "//div[contains(@class,'oxd-toast--success')]//p[text()='{0}']";

    private readonly Element _loadingSpinner = Element.ByXPath("//div[@class='oxd-loading-spinner-container']");

    private readonly Element _successfulSavePopUp =
        Element.ByXPath(SuccessfulPopUpPattern, "Successfully Saved");

    private readonly Element _successfulDeletePopUp =
        Element.ByXPath(SuccessfulPopUpPattern, "Successfully Deleted");

    public bool IsSavedSuccessfullyPopUpDisplayed() => _successfulSavePopUp.IsDisplayed();

    public bool IsDeletedSuccessfullyPopUpDisplayed() => _successfulDeletePopUp.IsDisplayed();

    public static void ClickRefreshButton() => WebDriverSingleton.GetDriver.Navigate().Refresh();

    public void WaitLoadingSpinnerInvisibility() => _loadingSpinner.WaitForInvisibility();
}