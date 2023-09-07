using DiplomaProject.UI.Pages.PIM;
using DiplomaProject.UI.Services;
using NUnit.Framework;

namespace Tests.PIMPage;

[TestFixture]
public class CustomFieldsEmployeeProfileTest : BaseTest
{
    private const string FirstName = "Alexsey";
    private const string LastName = "Ivanov";
    private const string CustomFieldName = "AutomationQA";
    private const string Screen = "Personal Details";
    private const string FieldType = "Text or Number";
    private const string Value = "Yes";
    private string _employeeId;

    [SetUp]
    public void LoginAsAdminAndCreateNewEmployee()
    {
        new LoginService()
            .LoginAsAdmin()
            .ClickPimButton()
            .ClickAddEmployeeButton();
        _employeeId = new EmployeeService()
            .CreateEmployee(FirstName, LastName);
    }

    [Test]
    public void Scenario19ValidateAddCustomFieldsEmployeeProfile()
    {
        var customFieldsPage = new PimHeaderPage()
            .OpenCustomFieldsPage();
        Assert.IsTrue(customFieldsPage.IsCustomFieldsTitleDisplayed(), "Custom Fields title isn't displayed");
        var addCustomFieldPage = customFieldsPage
            .ClickAddButton();
        addCustomFieldPage.WaitLoadingSpinnerInvisibility();
        Assert.IsTrue(addCustomFieldPage.IsAddCustomFieldTitleDisplayed(), "'Add Custom Field' form isn't displayed");
        addCustomFieldPage
            .EnterFieldName(CustomFieldName)
            .SelectScreen(Screen)
            .SelectType(FieldType)
            .ClickSaveButton();
        Assert.IsTrue(addCustomFieldPage.IsSavedSuccessfullyPopUpDisplayed(), "New custom field isn't saved");
        new PimHeaderPage()
            .ClickEmployeeListButton();
        var personalDetailsPage = new EmployeeService()
            .SearchEmployee(_employeeId)
            .ClickEditButtonByEmployeeId(_employeeId);
        personalDetailsPage.WaitLoadingSpinnerInvisibility();
        Assert.IsTrue(personalDetailsPage.IsFieldDisplayed(CustomFieldName),
            "Custom field isn't available in the respective section");
        personalDetailsPage
            .EnterFieldValue(CustomFieldName, Value)
            .ClickCustomFieldsSaveButton();
        Assert.IsTrue(personalDetailsPage.IsSavedSuccessfullyPopUpDisplayed(), "Custom field information isn't saved");
    }

    [TearDown]
    public void DeleteEmployeeAndCustomField()
    {
        new PimHeaderPage().ClickEmployeeListButton();
        new EmployeeService().DeleteEmployee(_employeeId);
        new PimHeaderPage()
            .OpenCustomFieldsPage()
            .ClickTrashBinButtonBuCustomFieldName(FieldType)
            .WaitPopUpVisibility()
            .ClickYesButton();
    }
}