using System;
using System.Collections.Generic;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SfDataGridDemo
{
    public class ViewModel
    {
        public List<MyData> Source { get; set; }

        public ViewModel()
        {
            Source = new List<MyData>();

            int startYear = 2024;
            int endYear = 2025;

            for (int year = startYear; year <= endYear; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    for (int day = 1; day <= 5; day++)
                    {
                        Source.Add(new MyData
                        {
                            Date1 = new DateTime(year, month, day),
                            Value = day,
                            Value2 = month
                        });
                    }

                }
            }
        }
    }
}
