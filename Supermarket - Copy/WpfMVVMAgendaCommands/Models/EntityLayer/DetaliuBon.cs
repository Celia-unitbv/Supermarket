using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models.EntityLayer
{
    internal class DetaliuBon : BasePropertyChanged
    {
        private int idDetalii;
        public int IdDetalii
        {
            get { return idDetalii; }
            set
            {
                idDetalii = value;
                NotifyPropertyChanged(nameof(IdDetalii));
            }
        }

        private int bon;
        public int Bon
        {
            get { return bon; }
            set
            {
                bon = value;
                NotifyPropertyChanged(nameof(Bon));
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

        private decimal subtotal;
        public decimal Subtotal
        {
            get { return subtotal; }
            set
            {
                subtotal = value;
                NotifyPropertyChanged(nameof(Subtotal));
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
    }
}
