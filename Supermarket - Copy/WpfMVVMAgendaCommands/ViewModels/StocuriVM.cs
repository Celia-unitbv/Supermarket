using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.BusinessLogicLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    internal class StocuriVM : BasePropertyChanged
    {
        private StocBLL stocBLL = new StocBLL();
        public ObservableCollection<Stoc> Stocuri { get; set; }

        public StocuriVM()
        {
            Stocuri = new ObservableCollection<Stoc>(stocBLL.GetAllStocuri());
        }

        public ObservableCollection<Stoc> GetStocByCodBare(string codBare)
        {
            return stocBLL.GetStocuriByCodBare(codBare);
        }

        public ObservableCollection<Produs> GetProduse()
        {
            return new ObservableCollection<Produs>(stocBLL.GetAllProducts());
        }

        public void AddStoc(Stoc stoc)
        {
            stocBLL.AddStoc(stoc);
            Stocuri.Add(stoc); // actualizează colecția locală
        }

        public decimal GetAdaosCommercial()
        {
            // Returnează adaosul comercial (valoare exemplificativă)
            return 20.0m;
        }

    }

}
