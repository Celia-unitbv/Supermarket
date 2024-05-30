using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models.EntityLayer
{
    internal class Produs : BasePropertyChanged
    {
        private string codBare;
        public string CodBare
        {
            get { return codBare; }
            set
            {
                codBare = value;
                NotifyPropertyChanged("CodBare");
            }
        }

        private string numeProdus;
        public string NumeProdus
        {
            get { return numeProdus; }
            set
            {
                numeProdus = value;
                NotifyPropertyChanged("NumeProdus");
            }
        }

        private Categorie categorie;
        public Categorie Categorie
        {
            get { return categorie; }
            set
            {
                categorie = value;
                NotifyPropertyChanged("Categorie");
            }
        }

        private Producator producator;
        public Producator Producator
        {
            get { return producator; }
            set
            {
                producator = value;
                NotifyPropertyChanged("Producator");
            }
        }

        
    }

}
