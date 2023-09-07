using DiplomaProject.UI.Framework.Element;
using DiplomaProject.UI.Utils;

namespace DiplomaProject.UI.Pages.Login;

public class LoginPage : BasePage
{
    private readonly Element _loginForm = Element.ByXPath("//*[@class = 'oxd-form']");
    private readonly Element _usernameInput = Element.ByXPath(InputByLabelNamePattern, "Username");
    private readonly Element _passwordInput = Element.ByXPath(InputByLabelNamePattern, "Password");
    private readonly Element _forgotLoginButton = Element.ByXPath("//*[text()='Forgot your password? ']");

    public bool IsLoginFormDisplayed() => _loginForm.IsDisplayed();

    public LoginPage WaitLoginFormVisibility() => ExecuteInChain<LoginPage>(() => _loginForm.WaitForVisibility());

    public LoginPage TypeUsername(string username) =>
        ExecuteInChain<LoginPage>(() => _usernameInput.SendKeys(username));

    public LoginPage TypePassword(string password) =>
        ExecuteInChain<LoginPage>(() => _passwordInput.SendKeys(password));

    public string GetUsernameInputValue() => _usernameInput.GetAttributeValue(Attributes.ValueCssProperty);

    public string GetPasswordInputValue() => _passwordInput.GetAttributeValue(Attributes.ValueCssProperty);

    public SidePanelPage ClickLoginButton()
    {
        ButtonTypeSubmit.Click();

        return new SidePanelPage();
    }

    public PasswordResetPage ClickForgotLoginButton()
    {
        _forgotLoginButton.Click();

        return new PasswordResetPage();
    }
}