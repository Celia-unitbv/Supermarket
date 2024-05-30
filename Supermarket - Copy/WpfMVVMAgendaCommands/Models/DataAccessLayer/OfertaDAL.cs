using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.DataAccessLayer
{
    internal class OfertaDAL
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;

        public Oferta GetOfertaByCodBare(string codBare)
        {
            Oferta oferta = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetOfertaByCodBare", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodBare", codBare);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    oferta = new Oferta
                    {
                        IdOferta = Convert.ToInt32(reader["IdOferta"]),
                        Produs = reader["Produs"].ToString(),
                        ProcentReducere = Convert.ToDecimal(reader["ProcentReducere"])
                    };
                }
                reader.Close();
            }

            return oferta;
        }
        public List<Oferta> GetOferteByExpirare(int zileInainteDeExpirare, decimal procentReducere)
        {
            List<Oferta> oferte = new List<Oferta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetOferteByExpirare", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ZileInainteDeExpirare", zileInainteDeExpirare);
                cmd.Parameters.AddWithValue("@ProcentReducere", procentReducere);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Oferta oferta = new Oferta
                    {
                        Produs = reader["CodBare"].ToString(),
                        NumeProdus = reader["NumeProdus"].ToString(),
                        Cantitate = Convert.ToInt32(reader["Cantitate"]),
                        PretVanzare = Convert.ToDecimal(reader["PretVanzare"]),
                        PretReducere = Convert.ToDecimal(reader["PretReducere"])
                    };
                    oferte.Add(oferta);
                }
                reader.Close();
            }

            return oferte;
        }

        public List<Oferta> GetOferteLichidareStoc(decimal procentReducere, int pragStoc)
        {
            List<Oferta> oferte = new List<Oferta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetOferteLichidareStoc", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProcentReducere", procentReducere);
                cmd.Parameters.AddWithValue("@PragStoc", pragStoc);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Oferta oferta = new Oferta
                    {
                        Produs = reader["CodBare"].ToString(),
                        NumeProdus = reader["NumeProdus"].ToString(),
                        Cantitate = Convert.ToInt32(reader["Cantitate"]),
                        PretVanzare = Convert.ToDecimal(reader["PretVanzare"]),
                        PretReducere = Convert.ToDecimal(reader["PretReducere"])
                    };
                    oferte.Add(oferta);
                }
                reader.Close();
            }

            return oferte;
        }
    }
}
