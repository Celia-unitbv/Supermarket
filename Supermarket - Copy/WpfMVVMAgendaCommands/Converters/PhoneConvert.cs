using System;
using System.Windows.Data;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.Converters
{
    class PhoneConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int personId;
            if (!int.TryParse(values[0].ToString(), out personId))
            {
                return null;
            }
            return new Phone()
            {
                PersonID = personId,
                PhoneNumber = values[1].ToString(),
                Description = values[2].ToString()
            };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            //Phone phone = value as Phone;
            //object[] result = new object[3] { phone.PersonID, phone.PhoneNumber, phone.Description };
            //return result;
            throw new NotImplementedException();
        }
    }
}
