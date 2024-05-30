using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace WpfMVVMAgendaCommands.Models
{
    public class PersonDAL
    {
        public ObservableCollection<Person> GetAllPersons()
        {

            SqlConnection con = DALHelper.Connection;
            
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllPersons", con);
                ObservableCollection<Person> result = new ObservableCollection<Person>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Person p = new Person();
                    p.PersonID = (int)(reader[0]);//reader.GetInt(0);
                    p.Name = reader.GetString(1);//reader[1].ToString();
                    p.Address = reader.IsDBNull(2) ? null : reader[2].ToString();
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Person> GetAllPersonsWithNoPhone()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllPersonsWithNoPhone", con);
                ObservableCollection<Person> result = new ObservableCollection<Person>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Person()
                        {
                            PersonID = reader["PersonID"] as int?,
                            Address = reader["Address"].ToString(),
                            Name = reader["Name"].ToString()
                        }
                    );
                }
                reader.Close();
                return result;
            }
        }

        public void AddPerson(Person persoana)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddPerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@name", persoana.Name);
                SqlParameter paramAdresa;
                if (string.IsNullOrEmpty(persoana.Address))
                    paramAdresa = new SqlParameter("@address", DBNull.Value);
                else
                    paramAdresa = new SqlParameter("@address", persoana.Address);
                SqlParameter paramIdPersoana = new SqlParameter("@persId", SqlDbType.Int);
                paramIdPersoana.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramAdresa);
                cmd.Parameters.Add(paramIdPersoana);
                con.Open();
                cmd.ExecuteNonQuery();
                persoana.PersonID = paramIdPersoana.Value as int?;
            }
        }

        public void DeletePerson(Person persoana)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeletePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@id", persoana.PersonID);
                cmd.Parameters.Add(paramIdPersoana);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyPerson(Person persoana)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyPerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@persID", persoana.PersonID);
                SqlParameter paramNume = new SqlParameter("@name", persoana.Name);
                SqlParameter paramAdresa = new SqlParameter();
                paramAdresa.ParameterName = "@address";
                if (string.IsNullOrEmpty(persoana.Address))
                {
                    paramAdresa.Value = DBNull.Value;
                }
                else
                {
                    paramAdresa.Value = persoana.Address;
                }
                cmd.Parameters.Add(paramIdPersoana);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramAdresa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
