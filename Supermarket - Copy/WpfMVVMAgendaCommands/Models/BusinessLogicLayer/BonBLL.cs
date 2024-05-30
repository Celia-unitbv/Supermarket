using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.ViewModels;

namespace WpfMVVMAgendaCommands.Models.BusinessLogicLayer
{
    internal class BonBLL
    {
        private BonDAL bonDAL = new BonDAL();

        public Bon GetLargestReceiptForDay(DateTime date)
        {
            return bonDAL.GetLargestReceiptForDay(date);
        }

        public void SaveBon(List<DetaliuBon> detaliiBon, int casierId)
        {
            bonDAL.SaveBon(detaliiBon, casierId);
        }
    }
}
