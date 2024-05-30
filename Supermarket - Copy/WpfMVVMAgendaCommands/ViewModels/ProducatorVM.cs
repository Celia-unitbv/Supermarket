using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.BusinessLogicLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.Models;
using System.Windows.Input;

namespace WpfMVVMAgendaCommands.ViewModels
{
    public class ProducatorVM : BasePropertyChanged
    {
        private ProducatorBLL producatorBLL = new ProducatorBLL();

        public ProducatorVM()
        {
            ProducatorList = producatorBLL.GetAllProducers();
        }

        public ObservableCollection<Producator> ProducatorList
        {
            get => producatorBLL.ProducatorList;
            set => producatorBLL.ProducatorList = value;
        }
        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Producator>(producatorBLL.ModifyProducer);
                }
                return updateCommand;
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Producator>(producatorBLL.AddProducer);
                }
                return addCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Producator>(producatorBLL.DeleteProducer);
                }
                return deleteCommand;
            }
        }
    
}
}
