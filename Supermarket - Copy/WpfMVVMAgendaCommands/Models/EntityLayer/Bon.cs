using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.ViewModels
{
    internal class Bon : BasePropertyChanged
    {
        private int idBon;
        public int IdBon
        {
            get { return idBon; }
            set
            {
                idBon = value;
                NotifyPropertyChanged(nameof(IdBon));
            }
        }

        private DateTime dataEliberare;
        public DateTime DataEliberare
        {
            get { return dataEliberare; }
            set
            {
                dataEliberare = value;
                NotifyPropertyChanged(nameof(DataEliberare));
            }
        }

        private decimal sumaIncasata;
        public decimal SumaIncasata
        {
            get { return sumaIncasata; }
            set
            {
                sumaIncasata = value;
                NotifyPropertyChanged(nameof(SumaIncasata));
            }
        }

        public ObservableCollection<DetaliuBon> DetaliiBon { get; set; }
    }

    
}
