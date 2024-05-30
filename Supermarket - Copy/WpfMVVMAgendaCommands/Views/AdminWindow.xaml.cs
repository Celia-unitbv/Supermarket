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
using WpfMVVMAgendaCommands.Models.BusinessLogicLayer;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.ViewModels;
using WpfMVVMAgendaCommands.ViewModels.Commands;

namespace WpfMVVMAgendaCommands.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private MainViewModel mainViewModel;
        internal AdminWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            mainViewModel = viewModel;
            DataContext = mainViewModel;
        }
      

        private void EditButtonProduct_Click(object sender, RoutedEventArgs e)
        {
            Produs selectedProduct = productListBox.SelectedItem as Produs;
            if (selectedProduct != null)
            {
                EditProductWindow editWindow = new EditProductWindow(selectedProduct, DataContext as MainViewModel, true);
                editWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a product to edit.");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EditProductWindow addWindow = new EditProductWindow(null, DataContext as MainViewModel, false);
            addWindow.ShowDialog();
        }




        private void DeleteButtonProduct_Click(object sender, RoutedEventArgs e)
        {
            Produs selectedProduct = productListBox.SelectedItem as Produs;
            if (selectedProduct != null)
            {
                try
                {
                    MainViewModel mainViewModel = DataContext as MainViewModel;
                    if (mainViewModel != null)
                    {
                        ProdusVM produsVM = mainViewModel.ProdusVM;
                        produsVM.DeleteCommand.Execute(selectedProduct);
                        MessageBox.Show("Produsul a fost șters cu succes!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la ștergerea produsului: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Selectați un produs pentru a-l șterge.");
            }
        }
        private void EditButtonCategory_Click(object sender, RoutedEventArgs e)
        {
            Categorie selectedCategory = categoryListBox.SelectedItem as Categorie;
            if (selectedCategory != null)
            {
                CategoryVM categoryVM = ((MainViewModel)DataContext).CategoryVM;
                EditCategoryWindow editWindow = new EditCategoryWindow(selectedCategory, categoryVM, true);
                editWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selectați o categorie pentru a edita.");
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryVM categoryVM = ((MainViewModel)DataContext).CategoryVM;
            EditCategoryWindow addWindow = new EditCategoryWindow(new Categorie(), categoryVM, false);
            addWindow.ShowDialog();
        }



        private void DeleteButtonCategory_Click(object sender, RoutedEventArgs e)
        {
            Categorie selectedCategory = categoryListBox.SelectedItem as Categorie;
            if (selectedCategory != null)
            {
                try
                {
                    MainViewModel mainViewModel = DataContext as MainViewModel;
                    if (mainViewModel != null)
                    {
                        CategoryVM categoryVM = mainViewModel.CategoryVM;
                        categoryVM.DeleteCommand.Execute(selectedCategory);
                        MessageBox.Show("Categoria a fost ștearsă cu succes!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la ștergerea categoriei: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Selectați o categorie pentru a o șterge.");
            }
        }
        private void EditButtonProducer_Click(object sender, RoutedEventArgs e)
        {
            Producator selectedProducer = producerListBox.SelectedItem as Producator;
            if (selectedProducer != null)
            {
                ProducatorVM producerVM = ((MainViewModel)DataContext).ProducatorVM;
                EditProducerWindow editWindow = new EditProducerWindow(selectedProducer, producerVM, true);
                editWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selectați un producător pentru a edita.");
            }
        }

        private void AddProducerButton_Click(object sender, RoutedEventArgs e)
        {
            ProducatorVM producerVM = ((MainViewModel)DataContext).ProducatorVM;
            EditProducerWindow addWindow = new EditProducerWindow(new Producator(), producerVM, false);
            addWindow.ShowDialog();
        }

        private void DeleteButtonProducer_Click(object sender, RoutedEventArgs e)
        {
            Producator selectedProducer = producerListBox.SelectedItem as Producator;
            if (selectedProducer != null)
            {
                try
                {
                    MainViewModel mainViewModel = DataContext as MainViewModel;
                    if (mainViewModel != null)
                    {
                        ProducatorVM producerVM = mainViewModel.ProducatorVM;
                        producerVM.DeleteCommand.Execute(selectedProducer);
                        MessageBox.Show("Producătorul a fost șters cu succes!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la ștergerea producătorului: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Selectați un producător pentru a-l șterge.");
            }
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow(DataContext as MainViewModel);
            searchWindow.ShowDialog();
        }
        private void OpenSearchWindow_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = DataContext as MainViewModel;
            SearchWindow searchWindow = new SearchWindow(mainViewModel);
            searchWindow.ShowDialog();
        }

        private void OpenCategoryValuesWindow_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = DataContext as MainViewModel;
            CategoryValuesWindow categoryValuesWindow = new CategoryValuesWindow(mainViewModel.CategoryVM);
            categoryValuesWindow.ShowDialog();
        }

        private void ViewUserSalesButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = DataContext as MainViewModel;
            UserSalesWindow userSalesWindow = new UserSalesWindow(mainViewModel);
            userSalesWindow.ShowDialog();
        }

        private void ViewLargestReceiptButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = DataContext as MainViewModel;
            LargestReceiptWindow largestReceiptWindow = new LargestReceiptWindow(mainViewModel);
            largestReceiptWindow.ShowDialog();
        }

        private void AddStocButton_Click(object sender, RoutedEventArgs e)
        {
            AddStocWindow addStocWindow = new AddStocWindow(mainViewModel.StocuriVM);
            addStocWindow.ShowDialog();
        }

        private void ViewOferteButton_Click(object sender, RoutedEventArgs e)
        {
            int zileInainteDeExpirare = 2; 
            decimal procentReducere = 10m; 
            int pragStoc = 5; 

            var oferteExpirare = mainViewModel.OferteVM.GetOferteByExpirare(zileInainteDeExpirare, procentReducere);
            var oferteLichidare = mainViewModel.OferteVM.GetOferteLichidareStoc(procentReducere, pragStoc);

            
            OferteWindow oferteWindow = new OferteWindow(oferteExpirare, oferteLichidare);
            oferteWindow.ShowDialog();
        }

    }
}
