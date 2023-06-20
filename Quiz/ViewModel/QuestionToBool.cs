using System;
using System.Globalization;

namespace Quiz.ViewModel
{
    public class QuestionToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Diagnostics.Debug.WriteLine(value,value.ToString());
            if (value == null)
            {
                return true;
            }
            string numberString = value.ToString();
            int numberInt = int.Parse(numberString);
            System.Diagnostics.Debug.WriteLine(value.Equals("10"));
            System.Diagnostics.Debug.WriteLine(numberInt<10);
            if (numberInt<10)
            {
                return false;
            }
            return true;
    

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if ( (bool) value)
            {
                return "0";
            }
            return "10";
        }
    }
}

