using DiplomaProject.UI.Pages.Admin;

namespace DiplomaProject.UI.Services;

public class AddUserService
{
    private readonly AddUserPage _addUserPage = new();

    public UsersPage CreateNewUser(string userRole, string employeeName,
        string status, string username, string password)
    {
        _addUserPage.WaitLoadingSpinnerInvisibility();
        return _addUserPage.ClickUserRoleDropDownArrow()
            .ClickSelectOptionByName(userRole)
            .ClickStatusDropDownArrow()
            .ClickSelectOptionByName(status)
            .EnterEmployeeName(employeeName)
            .ClickAutocompleteOptionByName(employeeName)
            .EnterUsername(username)
            .EnterPassword(password)
            .EnterConfirmPassword(password)
            .ClickSaveButton();
    }
}