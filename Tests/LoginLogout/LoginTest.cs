using DiplomaProject.UI.Framework;
using DiplomaProject.UI.Pages;
using DiplomaProject.UI.Pages.Login;
using DiplomaProject.UI.Services;
using NUnit.Framework;

namespace Tests.LoginLogout;

[TestFixture]
public class LoginTest : BaseTest
{
    [Test]
    public void Scenario1ValidateSuccessfulLogin()
    {
        var loginPage = new LoginPage()
            .WaitLoginFormVisibility();
        Assert.IsTrue(loginPage.IsLoginFormDisplayed(), "The login page isn't displayed");
        loginPage
            .TypeUsername(Properties.Login)
            .TypePassword(Properties.Password);
        Assert.AreEqual(Properties.Login, loginPage.GetUsernameInputValue(),
            "Username isn't present in the username field");
        Assert.AreEqual(Properties.Password, loginPage.GetPasswordInputValue(),
            "Password isn't present in the password field");
        var sidePanelPage = loginPage
            .ClickLoginButton();
        Assert.IsTrue(sidePanelPage.IsBrandBannerDisplayed(),
            "User isn't logged in and/or redirected to dashboard");
    }

    [Test]
    public void Scenario2ValidateSuccessfulLogout()
    {
        new LoginService()
            .LoginAsAdmin();
        var userHeaderPage = new UserHeaderPage()
            .ClickUserDropDownIcon()
            .WaitDropDownMenuVisibility();
        Assert.IsTrue(userHeaderPage.IsDropDownMenuDisplayed(), "Dropdown options aren't displayed");
        var loginPage = userHeaderPage
            .ClickLogoutButton();
        Assert.IsTrue(loginPage.IsLoginFormDisplayed(), "Login screen is not opened after logout");
    }

    [Test]
    public void Scenario17ResetPassword()
    {
        var passwordResetPage = new LoginPage()
            .ClickForgotLoginButton();
        Assert.IsTrue(passwordResetPage.IsPasswordResetHeaderDisplayed(), "Password reset page isn't displayed");
        passwordResetPage
            .EnterUsername(Properties.Login)
            .ClickResetPasswordButton();
        Assert.IsTrue(passwordResetPage.IsConfirmationMessageForPasswordResetDisplayed(),
            "Confirmation message for password reset is not displayed");
    }
}