using Syncfusion.UI.Xaml.Data;
using Syncfusion.UI.Xaml.DataGrid;
using Syncfusion.UI.Xaml.DataGrid.Renderers;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SfDataGridDemo
{
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
}
