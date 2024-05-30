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
    /// Interaction logic for LargestReceiptWindow.xaml
    /// </summary>
    public partial class LargestReceiptWindow : Window
    {
        private MainViewModel mainViewModel;

        internal LargestReceiptWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            mainViewModel = viewModel;
            DataContext = mainViewModel;
        }

        private void ShowLargestReceipt_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = calendar.SelectedDate ?? DateTime.Today;
            var largestReceipt = mainViewModel.GetLargestReceiptForDay(selectedDate);
            if (largestReceipt != null)
            {
                receiptDetailsListBox.ItemsSource = largestReceipt.DetaliiBon;
            }
            else
            {
                MessageBox.Show("Nu există bonuri pentru data selectată.");
            }
        }
    }
}
