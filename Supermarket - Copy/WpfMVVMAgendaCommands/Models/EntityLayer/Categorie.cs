using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models.EntityLayer
{
    public class Categorie : BasePropertyChanged
    {
        private int idCategorie;
        public int IdCategorie
        {
            get { return idCategorie; }
            set
            {
                idCategorie = value;
                NotifyPropertyChanged(nameof(IdCategorie));
            }
        }

        private string numeCategorie;
        public string NumeCategorie
        {
            get { return numeCategorie; }
            set
            {
                numeCategorie = value;
                NotifyPropertyChanged(nameof(NumeCategorie));
            }
        }
    }
}
