using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models.EntityLayer
{
    internal class Utilizator : BasePropertyChanged
    {
        private int idUtilizator;
        public int IdUtilizator
        {
            get { return idUtilizator; }
            set
            {
                idUtilizator = value;
                NotifyPropertyChanged(nameof(IdUtilizator));
            }
        }

        private string numeUtilizator;
        public string NumeUtilizator
        {
            get { return numeUtilizator; }
            set
            {
                numeUtilizator = value;
                NotifyPropertyChanged(nameof(NumeUtilizator));
            }
        }

        private string parola;
        public string Parola
        {
            get { return parola; }
            set
            {
                parola = value;
                NotifyPropertyChanged(nameof(Parola));
            }
        }

        private string tipUtilizator;
        public string TipUtilizator
        {
            get { return tipUtilizator; }
            set
            {
                tipUtilizator = value;
                NotifyPropertyChanged(nameof(TipUtilizator));
            }
        }
    }
}
