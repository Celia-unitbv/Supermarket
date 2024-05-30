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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMVVMAgendaCommands.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void persMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow window = new PersonWindow();
            window.Show();
        }

        private void telMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PhoneWindow window = new PhoneWindow();
            window.Show();
        }

        private void persWoPhoneMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PersonsWOPhpneWindow window = new PersonsWOPhpneWindow();
            window.Show();
        }

        private void persAndPhoneMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PersonsAndPhonesWindow window = new PersonsAndPhonesWindow();
            window.Show();
        }
    }
}
