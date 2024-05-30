using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.DataAccessLayer
{
    internal class StocDAL
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;

        public ObservableCollection<Stoc> GetStocuriByCodBare(string codBare)
        {
            ObservableCollection<Stoc> stocuri = new ObservableCollection<Stoc>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStocuriByCodBare", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodBare", codBare);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Stoc stoc = new Stoc
                    {
                        IdStoc = Convert.ToInt32(reader["IdStoc"]),
                        Produs = reader["Produs"].ToString(),
                        Cantitate = Convert.ToInt32(reader["Cantitate"]),
                        PretVanzare = Convert.ToDecimal(reader["PretVanzare"])
                    };
                    stocuri.Add(stoc);
                }
                reader.Close();
            }

            return stocuri;
        }
        public void UpdateStocCantitate(int idStoc, int cantitate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateStocCantitate", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdStoc", idStoc);
                cmd.Parameters.AddWithValue("@Cantitate", cantitate);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Produs> GetAllProducts()
        {
            List<Produs> produse = new List<Produs>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllProductsStoc", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Produs produs = new Produs
                    {
                        CodBare = reader["CodBare"].ToString(),
                        NumeProdus = reader["NumeProdus"].ToString()
                    };
                    produse.Add(produs);
                }
                reader.Close();
            }

            return produse;
        }

        public ObservableCollection<Stoc> GetAllStocuri()
        {
            ObservableCollection<Stoc> stocuri = new ObservableCollection<Stoc>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllStocuri", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Stoc stoc = new Stoc
                    {
                        IdStoc = Convert.ToInt32(reader["IdStoc"]),
                        Produs = reader["Produs"].ToString(),
                        Cantitate = Convert.ToInt32(reader["Cantitate"]),
                        PretVanzare = Convert.ToDecimal(reader["PretVanzare"]),
                        PretAchizitie = Convert.ToDecimal(reader["PretAchzitie"])
                    };
                    stocuri.Add(stoc);
                }
                reader.Close();
            }

            return stocuri;
        }

        public void AddStoc(Stoc stoc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddStoc", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Produs", stoc.Produs);
                cmd.Parameters.AddWithValue("@Cantitate", stoc.Cantitate);
                cmd.Parameters.AddWithValue("@PretAchizitie", stoc.PretAchizitie);
                cmd.Parameters.AddWithValue("@DataAprovizionarii", DateTime.Now);
                cmd.Parameters.AddWithValue("@DataExpirare", DateTime.Now.AddMonths(6)); 

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
