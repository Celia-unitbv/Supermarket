using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models.EntityLayer
{
    public class Producator : BasePropertyChanged
    {
        private int idProducator;
        public int IdProducator
        {
            get { return idProducator; }
            set
            {
                idProducator = value;
                NotifyPropertyChanged(nameof(IdProducator));
            }
        }

        private string numeProducator;
        public string NumeProducator
        {
            get { return numeProducator; }
            set
            {
                numeProducator = value;
                NotifyPropertyChanged(nameof(NumeProducator));
            }
        }

        private string taraOrigine;
        public string TaraOrigine
        {
            get { return taraOrigine; }
            set
            {
                taraOrigine = value;
                NotifyPropertyChanged(nameof(TaraOrigine));
            }
        }
    }
}
