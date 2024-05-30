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
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.ViewModels;

namespace WpfMVVMAgendaCommands.Views
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private SearchVM searchVM;

        internal SearchWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            searchVM = new SearchVM(viewModel);
            DataContext = searchVM;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProducer = producerComboBox.SelectedItem as Producator;
            var selectedCategory = categoryComboBox.SelectedItem as Categorie;

            if (selectedProducer != null)
            {
                int? categoryId = selectedCategory?.IdCategorie;
                searchVM.FilterProducts(selectedProducer.IdProducator, categoryId);
            }
            else
            {
                MessageBox.Show("Select a producer.");
            }
        }
    }
}
