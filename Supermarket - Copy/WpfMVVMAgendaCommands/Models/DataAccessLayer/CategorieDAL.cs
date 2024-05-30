using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.Models.BusinessLogicLayer;

namespace WpfMVVMAgendaCommands.Models.DataAccessLayer
{
    internal class CategorieDAL
    {
        public ObservableCollection<Categorie> GetAllCategories()
        {
            ObservableCollection<Categorie> categories = new ObservableCollection<Categorie>();

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT IdCategorie, NumeCategorie FROM CATEGORIE WHERE IsActive = 1", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Categorie category = new Categorie
                    {
                        IdCategorie = Convert.ToInt32(reader["IdCategorie"]),
                        NumeCategorie = reader["NumeCategorie"].ToString()
                    };

                    categories.Add(category);
                }

                reader.Close();
            }

            return categories;
        }

        public void AddCategory(Categorie category)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumeCategorie", category.NumeCategorie);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyCategory(Categorie category)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategorie", category.IdCategorie);
                cmd.Parameters.AddWithValue("@NumeCategorie", category.NumeCategorie);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(Categorie category)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategorie", category.IdCategorie);

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
        public ObservableCollection<CategoryValue> GetCategoryValues()
        {
            ObservableCollection<CategoryValue> categoryValues = new ObservableCollection<CategoryValue>();

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetCategoryValues", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategoryValue categoryValue = new CategoryValue
                    {
                        IdCategorie = Convert.ToInt32(reader["IdCategorie"]),
                        NumeCategorie = reader["NumeCategorie"].ToString(),
                        ValoareCategorie = Convert.ToDecimal(reader["ValoareCategorie"])
                    };

                    categoryValues.Add(categoryValue);
                }

                reader.Close();
            }

            return categoryValues;
        }
    }

}
