using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
    /// Interaction logic for CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        private MainViewModel mainViewModel;
        private List<DetaliuBon> currentBon;

        internal CashierWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            mainViewModel = viewModel;
            DataContext = mainViewModel;
            currentBon = new List<DetaliuBon>();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = searchTextBox.Text;
            DateTime? dataExpirare = expiryDatePicker.SelectedDate;
            var results = mainViewModel.ProdusVM.SearchProducts(searchTerm, dataExpirare);
            searchResultsListBox.ItemsSource = results;
        }

        private void ProductListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddProductToBon();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductToBon();
        }

        private void AddProductToBon()
        {
            var selectedProduct = searchResultsListBox.SelectedItem as Produs;
            if (selectedProduct != null)
            {
                var quantityInput = new QuantityInputWindow();
                if (quantityInput.ShowDialog() == true)
                {
                    int quantity = quantityInput.Quantity;
                    var stoc = mainViewModel.StocuriVM.GetStocByCodBare(selectedProduct.CodBare).FirstOrDefault();
                    if (stoc == null)
                    {
                        MessageBox.Show("Produsul nu are stoc disponibil.");
                        return;
                    }

                    decimal pretVanzare = stoc.PretVanzare;
                    var oferta = mainViewModel.OferteVM.GetOfertaByCodBare(selectedProduct.CodBare);
                    if (oferta != null)
                    {
                        pretVanzare -= pretVanzare * oferta.ProcentReducere / 100;
                    }

                    DetaliuBon detaliuBon = new DetaliuBon
                    {
                        Produs = selectedProduct.CodBare,
                        NumeProdus = selectedProduct.NumeProdus,
                        Cantitate = quantity,
                        Subtotal = pretVanzare * quantity,
                        IsActive = true
                    };
                    currentBon.Add(detaliuBon);
                    RefreshBonList();
                }
            }
        }


        private void RefreshBonList()
        {
            bonListBox.ItemsSource = null;
            bonListBox.ItemsSource = currentBon;
            totalTextBlock.Text = $"Total: {currentBon.Sum(x => x.Subtotal):C2} lei";
        }

        private void FinalizeBonButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentBon.Count > 0)
            {
                mainViewModel.BonVM.SaveBon(currentBon, mainViewModel.CurrentUserId);
                MessageBox.Show("Bonul a fost finalizat!");
                currentBon.Clear();
                RefreshBonList();
            }
            else
            {
                MessageBox.Show("Nu există produse în bon.");
            }
        }
    }
}
