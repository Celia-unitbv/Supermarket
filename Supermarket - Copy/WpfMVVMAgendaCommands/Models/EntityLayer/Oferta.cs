using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models.EntityLayer
{
    internal class Oferta : BasePropertyChanged
    {
        private int idOferta;
        public int IdOferta
        {
            get { return idOferta; }
            set
            {
                idOferta = value;
                NotifyPropertyChanged(nameof(IdOferta));
            }
        }

        private string produs;
        public string Produs
        {
            get { return produs; }
            set
            {
                produs = value;
                NotifyPropertyChanged(nameof(Produs));
            }
        }

        private decimal procentReducere;
        public decimal ProcentReducere
        {
            get { return procentReducere; }
            set
            {
                procentReducere = value;
                NotifyPropertyChanged(nameof(ProcentReducere));
            }
        }

        // Adăugăm noile proprietăți
        private string numeProdus;
        public string NumeProdus
        {
            get { return numeProdus; }
            set
            {
                numeProdus = value;
                NotifyPropertyChanged(nameof(NumeProdus));
            }
        }

        private int cantitate;
        public int Cantitate
        {
            get { return cantitate; }
            set
            {
                cantitate = value;
                NotifyPropertyChanged(nameof(Cantitate));
            }
        }

        private decimal pretVanzare;
        public decimal PretVanzare
        {
            get { return pretVanzare; }
            set
            {
                pretVanzare = value;
                NotifyPropertyChanged(nameof(PretVanzare));
            }
        }

        private decimal pretReducere;
        public decimal PretReducere
        {
            get { return pretReducere; }
            set
            {
                pretReducere = value;
                NotifyPropertyChanged(nameof(PretReducere));
            }
        }
    }
}
