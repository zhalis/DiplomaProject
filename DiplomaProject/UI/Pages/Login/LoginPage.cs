using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Login;

public class LoginPage : BasePage
{
    private readonly Element _loginForm = Element.ByXPath("//form[@class = 'oxd-form']");
    private readonly Element _usernameInput = Element.ByXPath(InputByPlaceholderPattern, "Username");
    private readonly Element _passwordInput = Element.ByXPath(InputByPlaceholderPattern, "Password");
    private readonly Element _loginButton = Element.ByXPath(ButtonTypeSubmit);
    private readonly Element _forgotLoginButton = Element.ByXPath("//p[text()='Forgot your password? ']");

    public bool IsLoginFormDisplayed() => _loginForm.IsDisplayed();

    public LoginPage WaitLoginFormVisibility()
    {
        _loginForm.WaitForVisibility();

        return this;
    }

    public LoginPage TypeUsername(string username)
    {
        _usernameInput.Type(username);

        return this;
    }

    public LoginPage TypePassword(string password)
    {
        _passwordInput.Type(password);

        return this;
    }

    public string GetUsernameInputValue() => _usernameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public string GetPasswordInputValue() => _passwordInput.GetAttributeValue(Attributes.ValueCssProperty);

    public SidePanelPage ClickLoginButton()
    {
        _loginButton.Click();

        return new SidePanelPage();
    }

    public PasswordResetPage ClickForgotLoginButton()
    {
        _forgotLoginButton.Click();

        return new PasswordResetPage();
    }
}