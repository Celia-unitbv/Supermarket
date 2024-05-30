using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.DataAccessLayer
{
    internal class ProducatorDAL
    {
        public ObservableCollection<Producator> GetAllProducers()
        {
            ObservableCollection<Producator> producers = new ObservableCollection<Producator>();

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT IdProducator, NumeProducator, TaraOrigine FROM PRODUCATORI WHERE IsActive = 1", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producator producer = new Producator
                    {
                        IdProducator = Convert.ToInt32(reader["IdProducator"]),
                        NumeProducator = reader["NumeProducator"].ToString(),
                        TaraOrigine = reader["TaraOrigine"].ToString()
                    };

                    producers.Add(producer);
                }

                reader.Close();
            }

            return producers;
        }

        public void AddProducer(Producator producer)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddProducer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumeProducator", producer.NumeProducator);
                cmd.Parameters.AddWithValue("@TaraOrigine", producer.TaraOrigine);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyProducer(Producator producer)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyProducer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducator", producer.IdProducator);
                cmd.Parameters.AddWithValue("@NumeProducator", producer.NumeProducator);
                cmd.Parameters.AddWithValue("@TaraOrigine", producer.TaraOrigine);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProducer(Producator producer)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteProducer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducator", producer.IdProducator);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public Producator GetProducerForProduct(Produs product)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetProducerForProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodBare", product.CodBare);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Producator producer = new Producator
                        {
                            IdProducator = Convert.ToInt32(reader["IdProducator"]),
                            NumeProducator = reader["NumeProducator"].ToString()
                        };
                        return producer;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

    }
}
