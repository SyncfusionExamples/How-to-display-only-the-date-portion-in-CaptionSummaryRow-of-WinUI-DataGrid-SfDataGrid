# How to display only the date portion in CaptionSummaryRow of WinUI DataGrid (SfDataGrid)?

In [WinUI DataGrid](https://www.syncfusion.com/winui-controls/datagrid) (SfDataGrid), you can display only the date portion (for example, MM/dd/yyyy) in the **GroupCaptionSummaryRow**.

This can be achieved by customizing the **GridCaptionSummaryCellRenderer** class and overriding the **OnUpdateEditBinding** method. In this method, you can modify the content of the **GridCaptionSummaryCell** based on your requirements.

In the approach below, the *groupRecord.Key* value is modified to format the DateTime and display only the date portion in the **GridCaptionSummaryCell**.

**Code snippet for customizing the GridCaptionSummaryCellRenderer class:**
```csharp
 public class CustomCaptionSummaryCellRenderer : GridCaptionSummaryCellRenderer
 {
     public override void OnUpdateEditBinding(DataColumnBase dataColumn, GridCaptionSummaryCell element, object dataContext)
     {
         if (element.DataContext is Group group && this.DataGrid.View.GroupDescriptions.Count > 0)
         {
             var groupRecord = element.DataContext as Group;
             var groupedColumn = this.GetGroupedColumn(groupRecord);

             if (this.DataGrid.CaptionSummaryRow == null)
             {
                 if (this.DataGrid.View.GroupDescriptions.Count < groupRecord.Level)
                     return;

                 // Customize the caption text format for DateTime columns
                 element.Content = GetCustomizedCaptionText(groupedColumn.HeaderText, groupRecord.Key, groupRecord.ItemsCount, groupedColumn.MappingName);
             }
             else if (this.DataGrid.CaptionSummaryRow.ShowSummaryInRow)
             {
                 element.Content = SummaryCreator.GetSummaryDisplayTextForRow(groupRecord.SummaryDetails, this.DataGrid.View, groupedColumn.HeaderText);
             }
             else
                 element.Content = SummaryCreator.GetSummaryDisplayText(groupRecord.SummaryDetails, dataColumn.GridColumn.MappingName, this.DataGrid.View);
         }
     }

     private GridColumn GetGroupedColumn(Group group)
     {
         var groupDesc = this.DataGrid.View.GroupDescriptions[group.Level - 1];
         foreach (var column in this.DataGrid.Columns)
         {
             if (column.MappingName == groupDesc.PropertyName)
             {
                 return column;
             }
         }
         return null;
     }

     private string GetCustomizedCaptionText(string columnName, object groupKey, int itemsCount, string mappingName)
     {
         // Check if the group key is a DateTime and format it accordingly
         if (groupKey is DateTime dateTime)
         {
             // Format the DateTime to show only the date portion (MM/dd/yyyy)
             string formattedDate = dateTime.ToString("MM/dd/yyyy");
             return string.Format("{0}: {1} - {2} items", columnName, formattedDate, itemsCount);
         }

         // For non-DateTime columns, use the default format
         return string.Format("{0}: {1} - {2} items", columnName, groupKey, itemsCount);
     }
 }
```
![Display Date Position in CaptionSummaryRow](Display%20Date%20Position%20in%20CaptionSummaryRow.gif)

Take a moment to peruse the [WinUI DataGrid - Summaries](https://help.syncfusion.com/winui/datagrid/summaries) documentation, to learn more about summaries and it types with example.