namespace WpfMVVMAgendaCommands.Models
{
    public class Person : BasePropertyChanged
    {
        private int? personID;
        public int? PersonID 
        {
            get
            {
                return personID;
            }
            set
            {
                personID = value;
                NotifyPropertyChanged("PersonID");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                NotifyPropertyChanged("Address");
            }
        }
    }
}
