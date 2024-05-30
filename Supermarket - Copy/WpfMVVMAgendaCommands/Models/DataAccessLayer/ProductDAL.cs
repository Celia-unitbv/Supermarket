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
    internal class ProdusDAL
    {
        public ObservableCollection<Produs> GetAllProducts()
        {
            SqlConnection con = DALHelper.Connection;

            try
            {
                SqlCommand cmd = new SqlCommand("GetAllProducts", con);
                ObservableCollection<Produs> result = new ObservableCollection<Produs>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Produs p = new Produs();
                    p.CodBare = reader["CodBare"].ToString();
                    p.NumeProdus = reader["NumeProdus"].ToString();

                    // Populăm obiectul Categorie
                    p.Categorie = new Categorie
                    {
                        IdCategorie = Convert.ToInt32(reader["CategorieId"]),
                        NumeCategorie = reader["NumeCategorie"].ToString()
                    };

                    // Populăm obiectul Producator
                    p.Producator = new Producator
                    {
                        IdProducator = Convert.ToInt32(reader["IdProducator"]),
                        NumeProducator = reader["NumeProducator"].ToString(),
                        TaraOrigine = reader["TaraOrigine"].ToString()
                    };

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

        public void ModifyProduct(Produs product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodBare", product.CodBare);
                cmd.Parameters.AddWithValue("@NumeProdus", product.NumeProdus);
                cmd.Parameters.AddWithValue("@CategorieId", product.Categorie.IdCategorie);
                cmd.Parameters.AddWithValue("@ProducatorId", product.Producator.IdProducator);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(Produs product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdPrduct = new SqlParameter("@CodBare", product.CodBare);
                cmd.Parameters.Add(paramIdPrduct);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Categorie GetCategoryForProduct(Produs product)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("GetCategoryForProduct", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodBare", product.CodBare);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Categorie category = new Categorie
                            {
                                IdCategorie = Convert.ToInt32(reader["IdCategorie"]),
                                NumeCategorie = reader["NumeCategorie"].ToString()
                            };
                            return category;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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
                            NumeProducator = reader["NumeProducator"].ToString(),
                            TaraOrigine = reader["TaraOrigine"].ToString()
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
        public void AddProduct(Produs product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodBare", product.CodBare);
                cmd.Parameters.AddWithValue("@NumeProdus", product.NumeProdus);
                cmd.Parameters.AddWithValue("@CategorieId", product.Categorie.IdCategorie);
                cmd.Parameters.AddWithValue("@ProducatorId", product.Producator.IdProducator);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<Produs> SearchProducts(string searchTerm, DateTime? dataExpirare)
        {
            ObservableCollection<Produs> products = new ObservableCollection<Produs>();

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SearchProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);
                if (dataExpirare.HasValue)
                {
                    cmd.Parameters.AddWithValue("@DataExpirare", dataExpirare.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DataExpirare", DBNull.Value);
                }

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Produs p = new Produs
                    {
                        CodBare = reader["CodBare"].ToString(),
                        NumeProdus = reader["NumeProdus"].ToString(),
                        Categorie = new Categorie
                        {
                            IdCategorie = Convert.ToInt32(reader["IdCategorie"]),
                            NumeCategorie = reader["NumeCategorie"].ToString()
                        },
                        Producator = new Producator
                        {
                            IdProducator = Convert.ToInt32(reader["IdProducator"]),
                            NumeProducator = reader["NumeProducator"].ToString(),
                            TaraOrigine = reader["TaraOrigine"].ToString()
                        }
                    };

                    products.Add(p);
                }
                reader.Close();
            }

            return products;
        }
    


}


}
