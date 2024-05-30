using System.Collections.ObjectModel;
using WpfMVVMAgendaCommands.Exceptions;

namespace WpfMVVMAgendaCommands.Models
{
    public class PhoneBLL
    {
        public ObservableCollection<Phone> PhonesList { get; set; }

        PhoneDAL telefoaneDAL = new PhoneDAL();
        public PhoneBLL()
        {
            PhonesList = new ObservableCollection<Phone>();
        }

        public void GetPhonesForPerson(Person persoana)
        {
            PhonesList.Clear();
            var phones = telefoaneDAL.GetAllPhonesForPerson(persoana);
            foreach (var ph in phones)
            {
                PhonesList.Add(ph);
            }
        }

        public void AddPhone(Phone telefon)
        {
            if (string.IsNullOrEmpty(telefon.PhoneNumber))
            {
                throw new AgendaException("Numarul de telefon nu poate sa lipseasca");

            }
            else if (telefon.PersonID == null)
            {
                throw new AgendaException("Precizati persoana careia ii apartine numarul");
            }
            else
            {
                telefoaneDAL.AddPhone(telefon);
                PhonesList.Add(telefon);
            }
        }

        public void ModifyPhone(Phone phone)
        {
            if (phone == null)
            {
                throw new AgendaException("Trebuie selectat un numar de telefon");
            }
            if (string.IsNullOrEmpty(phone.PhoneNumber))
            {
                throw new AgendaException("Trebuie precizat numarul de telefon");
            }
            if (string.IsNullOrEmpty(phone.Description))
            {
                throw new AgendaException("Trebuie precizata o descriere");
            }
            telefoaneDAL.ModifyPhone(phone);
        }

        public void DeletePhone(Phone telefon)
        {
            if (telefon == null || telefon.PhoneID == null)
            {
                throw new AgendaException("Alege un numar de telefon!");
            }
            telefoaneDAL.DeletePhone(telefon);
            PhonesList.Remove(telefon);
        }
    }
}
