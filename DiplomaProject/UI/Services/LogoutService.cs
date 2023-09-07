using DiplomaProject.UI.Pages;

namespace DiplomaProject.UI.Services;

public class LogoutService
{
    private readonly UserHeaderPage _userHeaderPage = new();

    public void Logout() =>
        _userHeaderPage
            .ClickUserDropDownIcon()
            .ClickLogoutButton();
}