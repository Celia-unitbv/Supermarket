using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.DataAccessLayer
{
    internal class DetaliuBonDAL
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;

        public void AddDetaliuBon(DetaliuBon detaliuBon)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO DETALIIBON (Bon, Produs, Cantitate, Subtotal, IsActive) VALUES (@Bon, @Produs, @Cantitate, @Subtotal, @IsActive)", con);
                cmd.Parameters.AddWithValue("@Bon", detaliuBon.Bon);
                cmd.Parameters.AddWithValue("@Produs", detaliuBon.Produs);
                cmd.Parameters.AddWithValue("@Cantitate", detaliuBon.Cantitate);
                cmd.Parameters.AddWithValue("@Subtotal", detaliuBon.Subtotal);
                cmd.Parameters.AddWithValue("@IsActive", detaliuBon.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<DetaliuBon> GetDetaliiBonByBon(int idBon)
        {
            List<DetaliuBon> detaliiBon = new List<DetaliuBon>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM DETALIIBON WHERE Bon = @Bon AND IsActive = 1", con);
                cmd.Parameters.AddWithValue("@Bon", idBon);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DetaliuBon detaliu = new DetaliuBon
                    {
                        IdDetalii = Convert.ToInt32(reader["IdDetalii"]),
                        Bon = Convert.ToInt32(reader["Bon"]),
                        Produs = reader["Produs"].ToString(),
                        Cantitate = Convert.ToInt32(reader["Cantitate"]),
                        Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    };
                    detaliiBon.Add(detaliu);
                }
                reader.Close();
            }

            return detaliiBon;
        }
    }
}
