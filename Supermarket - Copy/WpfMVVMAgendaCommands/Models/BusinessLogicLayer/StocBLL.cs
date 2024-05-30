using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.BusinessLogicLayer
{
    internal class StocBLL
    {
        private StocDAL stocDAL = new StocDAL();

        public ObservableCollection<Stoc> GetStocuriByCodBare(string codBare)
        {
            return stocDAL.GetStocuriByCodBare(codBare);
        }

        public void UpdateStocCantitate(int idStoc, int cantitate)
        {
            stocDAL.UpdateStocCantitate(idStoc, cantitate);
        }

        public List<Produs> GetAllProducts()
        {
            return stocDAL.GetAllProducts();
        }

        public void AddStoc(Stoc stoc)
        {
            stocDAL.AddStoc(stoc);
        }

        public ObservableCollection<Stoc> GetAllStocuri()
        {
            return stocDAL.GetAllStocuri();
        }
    }
}
