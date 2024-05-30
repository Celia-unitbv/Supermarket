using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.ViewModels;

namespace WpfMVVMAgendaCommands.Models.BusinessLogicLayer
{
    internal class UtilizatorBLL
    {
        private UtilizatorDAL utilizatorDAL = new UtilizatorDAL();

        public ObservableCollection<Utilizator> GetAllUsers()
        {
            return utilizatorDAL.GetAllUsers();
        }

        public List<DailySale> GetUserSalesForMonth(int userId, DateTime month)
        {
            return utilizatorDAL.GetUserSalesForMonth(userId, month);
        }
    }
}
