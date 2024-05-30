using System.Collections.ObjectModel;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    public class PersonsWOPhoneVM
    {
        public PersonsWOPhoneVM()
        {
            PersonBLL personBLL = new PersonBLL();
            PersonsList = personBLL.GetAllPersonsWithoutPhone();
        }
        public ObservableCollection<Person> PersonsList { get; set; }
    }
}
