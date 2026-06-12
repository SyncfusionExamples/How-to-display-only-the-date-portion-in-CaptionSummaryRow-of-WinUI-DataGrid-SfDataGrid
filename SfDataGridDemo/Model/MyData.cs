using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SfDataGridDemo
{
    public class MyData
    {
        private DateTime _date1;

        public DateTime Date1
        {
            get => _date1;
            set
            {
                _date1 = value;
            }
        }

        public int Value { get; set; }

        public int Value2 { get; set; }
    }
}
