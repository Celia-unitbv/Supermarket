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
    /// Interaction logic for EditCategoryWindow.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window
    {
        private CategoryVM categoryVM;
        private bool isEditMode;

        internal EditCategoryWindow(Categorie category, CategoryVM viewModel, bool editMode)
        {
            InitializeComponent();
            categoryVM = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            isEditMode = editMode;

            if (isEditMode)
            {
                DataContext = category;
                this.Title = "Editează Categoria";
            }
            else
            {
                var newCategory = new Categorie();
                DataContext = newCategory;
                this.Title = "Adaugă Categoria";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Categorie category = DataContext as Categorie;

            try
            {
                if (category != null)
                {
                    if (isEditMode)
                    {
                        categoryVM.UpdateCommand.Execute(category);
                        MessageBox.Show("Categoria actualizată cu succes!");
                    }
                    else
                    {
                        categoryVM.AddCommand.Execute(category);
                        MessageBox.Show("Categoria adăugată cu succes!");
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Categoria este null.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvarea categoriei: {ex.Message}");
            }
        }
    }
}
