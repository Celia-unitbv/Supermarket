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
    internal class BonVM : BasePropertyChanged
    {
        private BonBLL bonBLL = new BonBLL();

        public ObservableCollection<DetaliuBon> DetaliiBon { get; set; }

        public BonVM()
        {
            DetaliiBon = new ObservableCollection<DetaliuBon>();
        }

        public void AddDetaliuBon(DetaliuBon detaliuBon)
        {
            DetaliiBon.Add(detaliuBon);
        }

        public void SaveBon(List<DetaliuBon> detaliiBon, int casierId)
        {
            bonBLL.SaveBon(detaliiBon, casierId);
        }
    }
}
