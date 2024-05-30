using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.BusinessLogicLayer
{
    internal class DetaliuBonBLL
    {
        private DetaliuBonDAL detaliuBonDAL = new DetaliuBonDAL();

        public void AddDetaliuBon(DetaliuBon detaliuBon)
        {
            detaliuBonDAL.AddDetaliuBon(detaliuBon);
        }

        public List<DetaliuBon> GetDetaliiBonByBon(int idBon)
        {
            return detaliuBonDAL.GetDetaliiBonByBon(idBon);
        }
    }
}
