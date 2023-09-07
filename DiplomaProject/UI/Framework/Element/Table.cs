namespace DiplomaProject.UI.Framework.Element;

public class Table
{
    private const string ColumnValueByIndexPattern = "//*[contains(@class,'oxd-table-cell')][{0}]/div";
    private const string TableCellByValuePattern = "//*[contains(@class,'oxd-table-row')][.//text()='{0}']";
    private const string TrashBinButtonPattern = $"{TableCellByValuePattern}//*[contains(@class,'bi-trash')]";
    private const string EditButtonPattern = $"{TableCellByValuePattern}//*[contains(@class,'bi-pencil-fill')]";
    private const string CheckboxInputByColumnValuePattern = $"{TableCellByValuePattern}//*[@type='checkbox']";
    private const string CheckboxByColumnValuePattern = 
        $"{TableCellByValuePattern}//span[contains(@class,'oxd-checkbox-input')]";
    private readonly Element _columnHeader = Element.ByXPath("//*[contains(@class,'oxd-table-header-cell')]");
    private readonly Element _deleteSelectedButton = Element.ByXPath(
        "//*[contains(@class,'oxd-button')]//*[contains(@class,'bi-trash-fill')]");
    private readonly Dictionary<string, int> _columnNamesByIndex;

    public Table()
    {
        var columnIndex = 0;
        _columnNamesByIndex = _columnHeader.WaitForPresenceOfAllElements()
            .Select(element => element.Text)
            .ToDictionary(columnName => columnName, _ => ++columnIndex);
    }

    public bool IsColumnValueDisplayed(string columnValue) =>
        Element.ByXPath(TableCellByValuePattern, columnValue).IsDisplayed();

    public List<string> GetElementsByColumn(string columnName) =>
        Element.ByXPath(ColumnValueByIndexPattern, _columnNamesByIndex[columnName])
            .WaitForPresenceOfAllElements()
            .Select(element => element.Text)
            .ToList();

    public void ClickTrashBinButtonByColumnValue(string columnValue) =>
        Element.ByXPath(TrashBinButtonPattern, columnValue).Click();

    public void ClickEditButtonByColumnValue(string columnValue) =>
        Element.ByXPath(EditButtonPattern, columnValue).Click();

    public void ClickTableCellByValue(string value) =>
        Element.ByXPath(TableCellByValuePattern, value).Click();

    public void ClickCheckboxByColumnValue(string columnValue) =>
        Element.ByXPath(CheckboxByColumnValuePattern, columnValue).Click();

    public bool IsCheckboxCheckedByColumnValue(string columnValue) =>
        Element.ByXPath(CheckboxInputByColumnValuePattern, columnValue).IsSelected();

    public void ClickDeleteSelected() => _deleteSelectedButton.Click();
}