using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Monitor2
{
    public class ProgressForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double progress = (double)value;
            string color = "FFFFFF";

            if (progress < 20d)
                color = UIStyle.Style.LoadBarStyleVeryLow;
            else if (progress >= 20d && progress < 40d)
                color = UIStyle.Style.LoadBarStyleLow;
            else if (progress >= 40d && progress < 60d)
                color = UIStyle.Style.LoadBarStyleMed;
            else if (progress >= 60d && progress < 80d)
                color = UIStyle.Style.LoadBarStyleHigh;
            else if (progress >= 80d && progress <= 100d)
                color = UIStyle.Style.LoadBarStyleVeryHigh;

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}