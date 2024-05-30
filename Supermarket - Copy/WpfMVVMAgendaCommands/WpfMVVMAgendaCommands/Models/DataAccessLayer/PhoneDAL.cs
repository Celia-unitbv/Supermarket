using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace WpfMVVMAgendaCommands.Models
{
    public class PhoneDAL
    {
        public ObservableCollection<Phone> GetAllPhones()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllPhones", con);
                ObservableCollection<Phone> result = new ObservableCollection<Phone>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Phone p = new Phone();
                    p.PhoneID = (int)(reader[0]);
                    p.PersonID = (int)(reader[1]);
                    p.PhoneNumber = reader.GetString(2);
                    p.Description = reader.GetString(3);
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
        }
        public ObservableCollection<Phone> GetAllPhonesForPerson(Person persoana)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<Phone> result = new ObservableCollection<Phone>();
                SqlCommand cmd = new SqlCommand("GetPhonesForPerson", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@persID", persoana.PersonID);
                cmd.Parameters.Add(paramIdPersoana);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Phone()
                    {
                        PhoneID = reader.GetInt32(0),
                        PersonID = reader.GetInt32(1),
                        PhoneNumber = reader.GetString(2),
                        Description = reader.GetString(3)
                    });
                }
                return result;
            }
        }

        public void AddPhone(Phone telefon)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddPhoneForPerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@persId", telefon.PersonID);
                SqlParameter paramNumarTelefon = new SqlParameter("@number", telefon.PhoneNumber);
                SqlParameter paramDescriere = new SqlParameter("@description", telefon.Description);
                SqlParameter paramIdTelefon = new SqlParameter("@phId", SqlDbType.Int);
                paramIdTelefon.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramIdPersoana);
                cmd.Parameters.Add(paramNumarTelefon);
                cmd.Parameters.Add(paramDescriere);
                cmd.Parameters.Add(paramIdTelefon);
                con.Open();
                cmd.ExecuteNonQuery();
                telefon.PhoneID = paramIdTelefon.Value as int?;
            }
        }

        public void DeletePhone(Phone telefon)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeletePhone", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdTelefon = new SqlParameter("@id", telefon.PhoneID);
                cmd.Parameters.Add(paramIdTelefon);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyPhone(Phone phone)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyPhone", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdTelefon = new SqlParameter("@phoneID", phone.PhoneID);
                SqlParameter paramIdPersoana = new SqlParameter("@persID", phone.PersonID);
                SqlParameter paramNumar = new SqlParameter("@number", phone.PhoneNumber);
                SqlParameter paramDescriere = new SqlParameter("@description", phone.Description);
                cmd.Parameters.Add(paramIdPersoana);
                cmd.Parameters.Add(paramIdTelefon);
                cmd.Parameters.Add(paramNumar);
                cmd.Parameters.Add(paramDescriere);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
