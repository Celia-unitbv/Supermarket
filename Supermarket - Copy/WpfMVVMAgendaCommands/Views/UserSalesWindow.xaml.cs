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
using WpfMVVMAgendaCommands.ViewModels;

namespace WpfMVVMAgendaCommands.Views
{
    /// <summary>
    /// Interaction logic for UserSalesWindow.xaml
    /// </summary>
    public partial class UserSalesWindow : Window
    {
        private MainViewModel mainViewModel;

        internal UserSalesWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            mainViewModel = viewModel;
            DataContext = mainViewModel;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.GetUserSalesForMonth();
        }
    }
}
