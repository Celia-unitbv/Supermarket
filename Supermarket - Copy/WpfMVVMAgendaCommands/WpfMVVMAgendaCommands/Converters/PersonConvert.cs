using System;
using System.Windows.Data;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.Converters
{
    class PersonConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
                return new Person()
                {
                    Name = values[0].ToString(),
                    Address = values[1].ToString()
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            //Person pers = value as Person;
            //object[] result = new object[2] { pers.Name, pers.Address };
            //return result;
            throw new NotImplementedException();
        }
    }
}
