namespace DiplomaProject.UI.Pages.Admin;

public class EditUserPage : BasePage
{
    private const string EditUserTitle = "Edit User";

    public bool IsEditUserTitleDisplayed() => IsHeaderDisplayed(EditUserTitle);
}