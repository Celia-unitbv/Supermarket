using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfMVVMAgendaCommands.Models;
using WpfMVVMAgendaCommands.ViewModels;

namespace WpfMVVMAgendaCommands.Views
{
    /// <summary>
    /// Interaction logic for PhoneWindow.xaml
    /// </summary>
    public partial class PhoneWindow : Window
    {
        public PhoneWindow()
        {
            InitializeComponent();
        }

        //private void comboPers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    PhoneBLL p = new PhoneBLL();
        //    ((PhoneVM)DataContext).PhonesList = p.GetPhonesForPerson(((ComboBox)sender).SelectedItem as Person);
        //}
    }
}
