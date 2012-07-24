using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;

namespace Client.Converter
{
    public class RowBackgroundValueConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? boundItem = (int?)value;

            if (boundItem != null)
            {
                if (boundItem >= -20 && boundItem <= 0)
                {
                    return new SolidColorBrush(Colors.Green);
                }
                else if (boundItem >= 1 && boundItem <= 10)
                {
                    return new SolidColorBrush(Colors.Orange);
                }
                else
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }

            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
