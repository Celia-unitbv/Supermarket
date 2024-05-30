using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.ViewModels;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.DataAccessLayer
{
    internal class BonDAL
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;

        public Bon GetLargestReceiptForDay(DateTime date)
        {
            Bon largestBon = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetLargestReceiptForDay", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SelectedDate", date);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Bon currentBon = null;
                    while (reader.Read())
                    {
                        if (currentBon == null)
                        {
                            currentBon = new Bon
                            {
                                IdBon = Convert.ToInt32(reader["IdBon"]),
                                DataEliberare = Convert.ToDateTime(reader["DataEliberare"]),
                                SumaIncasata = Convert.ToDecimal(reader["SumaIncasata"]),
                                DetaliiBon = new ObservableCollection<DetaliuBon>()
                            };
                        }

                        var detail = new DetaliuBon
                        {
                            IdDetalii = Convert.ToInt32(reader["IdDetalii"]),
                            //NumeProdus = reader["NumeProdus"].ToString(),
                            Cantitate = Convert.ToInt32(reader["Cantitate"]),
                            Subtotal = Convert.ToDecimal(reader["Subtotal"])
                        };

                        currentBon.DetaliiBon.Add(detail);
                    }

                    largestBon = currentBon;
                    reader.Close();
                }
            }

            return largestBon;
        }
        public void SaveBon(List<DetaliuBon> detaliiBon, int casierId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    SqlCommand cmdBon = new SqlCommand("AddBon", connection, transaction);
                    cmdBon.CommandType = CommandType.StoredProcedure;
                    cmdBon.Parameters.AddWithValue("@DataEliberare", DateTime.Now);
                    cmdBon.Parameters.AddWithValue("@Casier", casierId);
                    cmdBon.Parameters.AddWithValue("@SumaIncasata", detaliiBon.Sum(x => x.Subtotal));

                    SqlParameter outputIdParam = new SqlParameter("@NewIdBon", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmdBon.Parameters.Add(outputIdParam);

                    cmdBon.ExecuteNonQuery();

                    int bonId = (int)outputIdParam.Value;

                    foreach (var detaliu in detaliiBon)
                    {
                        SqlCommand cmdDetaliu = new SqlCommand("AddDetaliuBon", connection, transaction);
                        cmdDetaliu.CommandType = CommandType.StoredProcedure;
                        cmdDetaliu.Parameters.AddWithValue("@Bon", bonId);
                        cmdDetaliu.Parameters.AddWithValue("@Produs", detaliu.Produs);
                        cmdDetaliu.Parameters.AddWithValue("@Cantitate", detaliu.Cantitate);
                        cmdDetaliu.Parameters.AddWithValue("@Subtotal", detaliu.Subtotal);

                        SqlParameter outputDetaliiIdParam = new SqlParameter("@NewIdDetalii", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmdDetaliu.Parameters.Add(outputDetaliiIdParam);

                        cmdDetaliu.ExecuteNonQuery();

                        // Actualizarea stocului
                        SqlCommand cmdUpdateStoc = new SqlCommand("UpdateStocCantitate", connection, transaction);
                        cmdUpdateStoc.CommandType = CommandType.StoredProcedure;
                        cmdUpdateStoc.Parameters.AddWithValue("@Produs", detaliu.Produs);
                        cmdUpdateStoc.Parameters.AddWithValue("@Cantitate", detaliu.Cantitate);
                        cmdUpdateStoc.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }



    }
}
