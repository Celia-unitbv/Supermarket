using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models.DataAccessLayer
{
    internal class UserDAL
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;

        public (string, int) AuthenticateUser(string username, string password)
        {
            string userType = "";
            int userId = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("AuthenticateUserAndGetUserType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NumeUtilizator", username);
                    command.Parameters.AddWithValue("@Parola", password);

                    // Adăugăm un parametru pentru tipul de utilizator ca parametru de ieșire
                    SqlParameter outputTypeParam = new SqlParameter("@TipUtilizator", SqlDbType.VarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputTypeParam);

                    
                    SqlParameter outputIdParam = new SqlParameter("@UserId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    connection.Open();
                    command.ExecuteNonQuery();

                    // Obținem valorile tipului de utilizator și ID-ul utilizatorului din parametrii de ieșire
                    userType = outputTypeParam.Value.ToString();
                    userId = (int)outputIdParam.Value;
                }
            }

            return (userType, userId);
        }
    }
}
