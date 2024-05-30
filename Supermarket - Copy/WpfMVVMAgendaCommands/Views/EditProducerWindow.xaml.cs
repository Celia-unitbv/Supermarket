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
    /// Interaction logic for EditProducerWindow.xaml
    /// </summary>
    public partial class EditProducerWindow : Window
    {
        private ProducatorVM producerVM;
        private bool isEditMode;

        internal EditProducerWindow(Producator producer, ProducatorVM viewModel, bool editMode)
        {
            InitializeComponent();
            producerVM = viewModel;
            isEditMode = editMode;

            if (isEditMode)
            {
                DataContext = producer;
                this.Title = "Editează Producătorul";
            }
            else
            {
                var newProducer = new Producator();
                DataContext = newProducer;
                this.Title = "Adaugă Producător";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Producator producer = DataContext as Producator;

            try
            {
                if (producer != null)
                {
                    if (isEditMode)
                    {
                        producerVM.UpdateCommand.Execute(producer);
                        MessageBox.Show("Producător actualizat cu succes!");
                    }
                    else
                    {
                        producerVM.AddCommand.Execute(producer);
                        MessageBox.Show("Producător adăugat cu succes!");
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Producătorul este null.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvarea producătorului: {ex.Message}");
            }
        }
    }
}
