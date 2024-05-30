using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models.EntityLayer
{
    internal class Stoc : BasePropertyChanged
    {
        private int idStoc;
        public int IdStoc
        {
            get { return idStoc; }
            set
            {
                idStoc = value;
                NotifyPropertyChanged(nameof(IdStoc));
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

        private decimal pretAchizitie;
        public decimal PretAchizitie
        {
            get { return pretAchizitie; }
            set
            {
                pretAchizitie = value;
                NotifyPropertyChanged(nameof(PretAchizitie));
            }
        }

        private string unit;
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                NotifyPropertyChanged(nameof(Unit));
            }
        }

        private DateTime dataAprovizionarii;
        public DateTime DataAprovizionarii
        {
            get { return dataAprovizionarii; }
            set
            {
                dataAprovizionarii = value;
                NotifyPropertyChanged(nameof(DataAprovizionarii));
            }
        }

        private DateTime dataExpirare;
        public DateTime DataExpirare
        {
            get { return dataExpirare; }
            set
            {
                dataExpirare = value;
                NotifyPropertyChanged(nameof(DataExpirare));
            }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                NotifyPropertyChanged(nameof(IsActive));
            }
        }

        private decimal adaosComercial;
        public decimal AdaosComercial
        {
            get { return adaosComercial; }
            set
            {
                adaosComercial = value;
                NotifyPropertyChanged(nameof(AdaosComercial));
            }
        }
    }
}
