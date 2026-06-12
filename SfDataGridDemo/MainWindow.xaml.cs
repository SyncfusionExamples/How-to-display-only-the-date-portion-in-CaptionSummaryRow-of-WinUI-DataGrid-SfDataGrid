using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Animation;
using Syncfusion.UI.Xaml.Grids;
using Syncfusion.UI.Xaml.Grids.ScrollAxis;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SfDataGridDemo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Customize the cell renderer for the "CaptionSummary" type to use our custom renderer
            this.SortsDataGrid.CellRenderers.Remove("CaptionSummary");
            this.SortsDataGrid.CellRenderers.Add("CaptionSummary", new CustomCaptionSummaryCellRenderer());
        }
    }
}
