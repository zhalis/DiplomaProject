using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Pages.Login;

namespace DiplomaProject.UI.Pages;

public class UserHeaderPage : BasePage
{
    private readonly Element _userDropDownIcon = Element.ByXPath("//i[contains(@class,'oxd-userdropdown-icon')]");
    private readonly Element _dropDownMenu = Element.ByXPath("//ul[@class='oxd-dropdown-menu']");
    private readonly Element _logoutButton = Element.ByXPath(LinkByTextPattern, "Logout");

    public bool IsDropDownMenuDisplayed() => _dropDownMenu.IsDisplayed();

    public UserHeaderPage ClickUserDropDownIcon()
    {
        _userDropDownIcon.Click();

        return this;
    }

    public LoginPage ClickLogoutButton()
    {
        _logoutButton.Click();

        return new LoginPage();
    }

    public UserHeaderPage WaitDropDownMenuVisibility()
    {
        _dropDownMenu.WaitForVisibility();

        return this;
    }
}