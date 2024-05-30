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

namespace WpfMVVMAgendaCommands.Views
{
    /// <summary>
    /// Interaction logic for QuantityInputWindow.xaml
    /// </summary>
    public partial class QuantityInputWindow : Window
    {
        public int Quantity { get; private set; }

        public QuantityInputWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(quantityTextBox.Text, out int quantity) && quantity > 0)
            {
                Quantity = quantity;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Introduceți o cantitate validă.");
            }
        }
    }
}
