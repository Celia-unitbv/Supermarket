using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models;
using WpfMVVMAgendaCommands.Models.BusinessLogicLayer;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.ViewModels.Commands;

namespace WpfMVVMAgendaCommands.ViewModels
{
    internal class MainViewModel : BasePropertyChanged
    {
        public CategoryVM CategoryVM { get; set; }
        public ProdusVM ProdusVM { get; set; }
        public ProducatorVM ProducatorVM { get; set; }
        public StocuriVM StocuriVM { get; set; }
        public OferteVM OferteVM { get; set; }
        public BonVM BonVM { get; set; }

        private UtilizatorBLL utilizatorBLL = new UtilizatorBLL();
        private BonBLL bonBLL = new BonBLL();
        
        public ObservableCollection<Utilizator> Users { get; set; }

        private Utilizator selectedUser;
        public Utilizator SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                NotifyPropertyChanged(nameof(SelectedUser));
            }
        }

        private DateTime? selectedMonth;
        public DateTime? SelectedMonth
        {
            get { return selectedMonth; }
            set
            {
                selectedMonth = value;
                NotifyPropertyChanged(nameof(SelectedMonth));
            }
        }

        private ObservableCollection<DailySale> dailySales;
        public ObservableCollection<DailySale> DailySales
        {
            get { return dailySales; }
            set
            {
                dailySales = value;
                NotifyPropertyChanged(nameof(DailySales));
            }
        }
        private int currentUserId;
        public int CurrentUserId
        {
            get { return currentUserId; }
            set
            {
                currentUserId = value;
                NotifyPropertyChanged(nameof(CurrentUserId));
            }
        }

        public MainViewModel()
        {
            CategoryVM = new CategoryVM();
            ProdusVM = new ProdusVM();
            ProducatorVM = new ProducatorVM();
            StocuriVM = new StocuriVM();
            OferteVM = new OferteVM();
            BonVM = new BonVM();
            Users = utilizatorBLL.GetAllUsers();
        }
        public Bon GetLargestReceiptForDay(DateTime date)
        {
            return bonBLL.GetLargestReceiptForDay(date);
        }

        public void GetUserSalesForMonth()
        {
            if (SelectedUser != null && SelectedMonth.HasValue)
            {
                var sales = utilizatorBLL.GetUserSalesForMonth(SelectedUser.IdUtilizator, SelectedMonth.Value);
                DailySales = new ObservableCollection<DailySale>(sales);
            }
        }
    }

    public class DailySale : BasePropertyChanged
    {
        public DateTime Date { get; set; }
        public decimal TotalSales { get; set; }
        public string DisplayText => $"{Date.ToShortDateString()} - {TotalSales:C}";
    }


}
