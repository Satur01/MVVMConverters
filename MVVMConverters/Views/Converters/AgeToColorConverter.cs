using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MVVMConverters.Views.Converters
{
    public class AgeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.Green);
            int valueResult = (int)value;
            if (valueResult < 18)
            {
                brush.Color = Colors.Red;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
