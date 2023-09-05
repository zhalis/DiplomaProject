using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Login;

public class PasswordResetPage : BasePage
{
    private const string PasswordResetHeaderTitle = "Reset Password";

    private const string ConfirmationMessageForPasswordReset = "Reset Password link sent successfully";

    private readonly Element _usernameInput = Element.ByXPath(InputByLabelNamePattern, "Username");

    public bool IsPasswordResetHeaderDisplayed() => IsHeaderDisplayed(PasswordResetHeaderTitle);

    public bool IsConfirmationMessageForPasswordResetDisplayed() =>
        IsHeaderDisplayed(ConfirmationMessageForPasswordReset);

    public PasswordResetPage EnterUsername(string username)
    {
        _usernameInput.SendKeys(username);

        return this;
    }

    public PasswordResetPage ClickResetPasswordButton()
    {
        ButtonTypeSubmit.Click();

        return this;
    }
}