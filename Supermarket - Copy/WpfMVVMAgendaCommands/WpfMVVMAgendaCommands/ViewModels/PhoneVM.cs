using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    public class PhoneVM : BasePropertyChanged
    {
        PersonBLL persBLL = new PersonBLL();
        PhoneBLL phoneBLL = new PhoneBLL();
        public PhoneVM()
        {
            PersonsList = persBLL.GetAllPersons();
        }

        #region Data Members

        public ObservableCollection<Person> PersonsList { get; set; }

        public ObservableCollection<Phone> PhonesList
        {
            get => phoneBLL.PhonesList;
            set => phoneBLL.PhonesList = value;
        }

        #endregion

        #region ICommand Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Phone>(phoneBLL.AddPhone);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Phone>(phoneBLL.ModifyPhone);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Phone>(phoneBLL.DeletePhone);
                }
                return deleteCommand;
            }
        }

        private ICommand changePersonCommand;
        public ICommand ChangePersonCommand
        {
            get
            {
                if (changePersonCommand == null)
                {
                    changePersonCommand = new RelayCommand<Person>(phoneBLL.GetPhonesForPerson);
                }
                return changePersonCommand;
            }
        }

        #endregion
    }
}
