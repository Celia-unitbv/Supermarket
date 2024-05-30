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
using WpfMVVMAgendaCommands.ViewModels.Commands;

namespace WpfMVVMAgendaCommands.Views
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private MainViewModel mainViewModel;
        private bool isEditMode;

        internal EditProductWindow(Produs product, MainViewModel viewModel, bool editMode)
        {
            InitializeComponent();
            mainViewModel = viewModel;
            isEditMode = editMode;

            if (isEditMode)
            {
                DataContext = product;
                this.Title = "Editează Produs";
            }
            else
            {
                var newProduct = new Produs
                {
                    Categorie = mainViewModel.CategoryVM.CategorieList.FirstOrDefault(),
                    Producator = mainViewModel.ProducatorVM.ProducatorList.FirstOrDefault()
                };
                DataContext = newProduct;
                this.Title = "Adaugă Produs";
            }

            categoryComboBox.ItemsSource = mainViewModel.CategoryVM.CategorieList;
            producatorComboBox.ItemsSource = mainViewModel.ProducatorVM.ProducatorList;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Produs product = DataContext as Produs;

            try
            {
                product.Categorie = (Categorie)categoryComboBox.SelectedItem;
                product.Producator = (Producator)producatorComboBox.SelectedItem;

                if (isEditMode)
                {
                    mainViewModel.ProdusVM.UpdateCommand.Execute(product);
                    MessageBox.Show("Produs actualizat cu succes!");
                }
                else
                {
                    mainViewModel.ProdusVM.AddCommand.Execute(product);
                    MessageBox.Show("Produs adăugat cu succes!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvarea produsului: {ex.Message}");
            }
        }
    }


}
