using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ValueConverter
{
    //Converter müssen immer das Interface IValueConverter implementieren. Hier wird dann die Umwandlungslogik definiert
    public class DoubleToBrushConverter : IValueConverter
    {
        //Source->Target:
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Rückgabe eines Brushes, welcher seine Farbe aus dem übergebenen Wert (value-Parameter) berechnet
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb((byte)(double)value, 0, 0));
            return brush;
        }

        //Target->Source
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Hier nicht nötig, deshalb nicht implementiert
            throw new NotImplementedException();
        }
    }
}
