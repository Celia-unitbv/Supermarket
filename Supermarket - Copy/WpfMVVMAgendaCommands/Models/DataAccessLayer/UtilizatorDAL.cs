using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.ViewModels;

namespace WpfMVVMAgendaCommands.Models.DataAccessLayer
{
    internal class UtilizatorDAL
    {
        public ObservableCollection<Utilizator> GetAllUsers()
        {
            ObservableCollection<Utilizator> users = new ObservableCollection<Utilizator>();

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT IdUtilizator, NumeUtilizator FROM UTILIZATOR WHERE IsActive = 1", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Utilizator user = new Utilizator
                    {
                        IdUtilizator = Convert.ToInt32(reader["IdUtilizator"]),
                        NumeUtilizator = reader["NumeUtilizator"].ToString()
                    };
                    users.Add(user);
                }

                reader.Close();
            }

            return users;
        }

        public List<DailySale> GetUserSalesForMonth(int userId, DateTime month)
        {
            List<DailySale> sales = new List<DailySale>();

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT DataEliberare, SUM(SumaIncasata) AS TotalSales " +
                    "FROM BONURICASA " +
                    "WHERE Casier = @UserId AND MONTH(DataEliberare) = @Month AND YEAR(DataEliberare) = @Year AND IsActive = 1 " +
                    "GROUP BY DataEliberare", con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Month", month.Month);
                cmd.Parameters.AddWithValue("@Year", month.Year);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DailySale sale = new DailySale
                    {
                        Date = Convert.ToDateTime(reader["DataEliberare"]),
                        TotalSales = Convert.ToDecimal(reader["TotalSales"])
                    };
                    sales.Add(sale);
                }

                reader.Close();
            }

            return sales;
        }
    }
}
