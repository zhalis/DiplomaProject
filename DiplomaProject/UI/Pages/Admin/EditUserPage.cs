using DiplomaProject.UI.Framework.Element;

namespace DiplomaProject.UI.Pages.Admin;

public class EditUserPage : BasePage
{
    private readonly Element _editUserTitle = Element.ByXPath(HeaderByTextPattern, "Edit User");

    public bool IsEditUserTitleDisplayed() => _editUserTitle.IsDisplayed();
}