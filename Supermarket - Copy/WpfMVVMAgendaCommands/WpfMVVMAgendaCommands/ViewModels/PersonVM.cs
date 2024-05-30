using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    public class PersonVM : BasePropertyChanged
    {
        PersonBLL persBLL = new PersonBLL();
        public PersonVM()
        {
            PersonsList = persBLL.GetAllPersons();
        }

        #region Data Members

        public ObservableCollection<Person> PersonsList
        {
            get => persBLL.PersonsList;
            set => persBLL.PersonsList = value;
        }

        #endregion

        #region Command Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Person>(persBLL.AddPerson);
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
                    updateCommand = new RelayCommand<Person>(persBLL.ModifyPerson);
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
                    deleteCommand = new RelayCommand<Person>(persBLL.DeletePerson);
                }
                return deleteCommand;
            }
        }
        #endregion
    }
}
