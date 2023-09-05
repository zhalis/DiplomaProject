using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Framework.Element.DropDowns;
using DiplomaProject.UI.Pages.Login;

namespace DiplomaProject.UI.Pages;

public class UserHeaderPage : BasePage
{
    private const string Logout = "Logout";
    private readonly Element _userDropDownIcon = Element.ByXPath("//*[contains(@class,'oxd-userdropdown-icon')]");

    public bool IsDropDownMenuDisplayed() => HeaderDropDown.IsDropDownMenuDisplayed();

    public UserHeaderPage ClickUserDropDownIcon()
    {
        _userDropDownIcon.Click();

        return this;
    }

    public LoginPage ClickLogoutButton()
    {
        ClickLinkByName(Logout);

        return new LoginPage();
    }
}