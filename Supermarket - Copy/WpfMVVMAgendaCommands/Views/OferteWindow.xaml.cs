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

namespace WpfMVVMAgendaCommands.Views
{
    /// <summary>
    /// Interaction logic for OferteWindow.xaml
    /// </summary>
    public partial class OferteWindow : Window
    {
        internal OferteWindow(List<Oferta> oferteExpirare, List<Oferta> oferteLichidare)
        {
            InitializeComponent();

            expirareListBox.ItemsSource = oferteExpirare;
            lichidareListBox.ItemsSource = oferteLichidare;
        }
    }
}
