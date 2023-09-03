using DiplomaProject.UI.Framework;
using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.Login;

namespace DiplomaProject.UI.Services;

public class LoginService
{
    private readonly LoginPage _loginPage = new();

    public SidePanelPage LoginAsAdmin()
    {
        _loginPage
            .WaitLoginFormVisibility()
            .TypeUsername(Properties.Login)
            .TypePassword(Properties.Password)
            .ClickLoginButton();
        return new SidePanelPage();
    }
}