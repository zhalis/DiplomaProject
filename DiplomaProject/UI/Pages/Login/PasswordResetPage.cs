using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Login;

public class PasswordResetPage : BasePage
{
    private readonly Element _passwordResetHeaderTitle = Element.ByXPath(HeaderByTextPattern, "Reset Password");

    private readonly Element _usernameInput = Element.ByXPath(InputByPlaceholderPattern, "Username");

    private readonly Element _resetPasswordButton = Element.ByXPath(ButtonTypeSubmit);

    private readonly Element _confirmationMessageForPasswordReset =
        Element.ByXPath(HeaderByTextPattern, "Reset Password link sent successfully");

    public bool IsPasswordResetHeaderDisplayed() => _passwordResetHeaderTitle.IsDisplayed();

    public bool IsConfirmationMessageForPasswordResetDisplayed() => _confirmationMessageForPasswordReset.IsDisplayed();

    public PasswordResetPage EnterUsername(string username)
    {
        _usernameInput.Type(username);

        return this;
    }

    public PasswordResetPage ClickResetPasswordButton()
    {
        _resetPasswordButton.Click();

        return this;
    }
}