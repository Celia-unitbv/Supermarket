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
    /// Interaction logic for Add_Stoc.xaml
    /// </summary>
    public partial class AddStocWindow : Window
    {
        private StocuriVM stocuriVM;

        internal AddStocWindow(StocuriVM stocuriVM)
        {
            InitializeComponent();
            this.stocuriVM = stocuriVM;
            DataContext = stocuriVM;
            productComboBox.ItemsSource = stocuriVM.GetProduse();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (productComboBox.SelectedValue != null && int.TryParse(cantitateTextBox.Text, out int cantitate) && decimal.TryParse(pretAchizitieTextBox.Text, out decimal pretAchizitie))
            {
                string produs = productComboBox.SelectedValue.ToString();
                decimal adaosCommercial = stocuriVM.GetAdaosCommercial();
                decimal pretVanzare = pretAchizitie + (pretAchizitie * adaosCommercial / 100);

                Stoc stoc = new Stoc
                {
                    Produs = produs,
                    Cantitate = cantitate,
                    PretAchizitie = pretAchizitie,
                    PretVanzare = pretVanzare,
                    Unit = "buc", // Exemplu: unitate "buc"
                    DataAprovizionarii = DateTime.Now,
                    DataExpirare = DateTime.Now.AddMonths(6), // Exemplu: adăugare termen de valabilitate
                    IsActive = true,
                    AdaosComercial = adaosCommercial
                };

                stocuriVM.AddStoc(stoc);
                this.Close();
            }
            else
            {
                MessageBox.Show("Completați toate câmpurile corect.");
            }
        }
    }


}

