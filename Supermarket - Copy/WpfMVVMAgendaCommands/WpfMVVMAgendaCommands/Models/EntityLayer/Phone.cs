namespace WpfMVVMAgendaCommands.Models
{
    public class Phone : BasePropertyChanged
    {
        private int? phoneID;
        public int? PhoneID
        {
            get
            {
                return phoneID;
            }
            set
            {
                phoneID = value;
                NotifyPropertyChanged("PhoneID");
            }
        }

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

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                NotifyPropertyChanged("PhoneNumber");
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }
    }
}
