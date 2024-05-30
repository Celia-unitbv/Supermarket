using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Exceptions;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.BusinessLogicLayer
{
    internal class ProdusBLL
    {
        public ObservableCollection<Produs> ProduseList { get; set; }

        private ProdusDAL produsDAL = new ProdusDAL();

        public ProdusBLL()
        {
            ProduseList = new ObservableCollection<Produs>();
        }

        public ObservableCollection<Produs> GetAllProducts()
        {
            return produsDAL.GetAllProducts();
        }

        public ObservableCollection<Produs> SearchProducts(string searchTerm, DateTime? dataExpirare)
        {
            return produsDAL.SearchProducts(searchTerm, dataExpirare);
        }

        public void ModifyProduct(Produs produs)
        {
            if (produs == null)
            {
                throw new AgendaException("Trebuie selectat un produs");
            }
            if (string.IsNullOrEmpty(produs.NumeProdus))
            {
                throw new AgendaException("Trebuie precizat numele produsului");
            }
            if (string.IsNullOrEmpty(produs.CodBare))
            {
                throw new AgendaException("Trebuie precizat codul de bare");
            }
            if (produs.Categorie == null)
            {
                throw new AgendaException("Trebuie precizată categoria");
            }
            if (produs.Producator == null)
            {
                throw new AgendaException("Trebuie precizat producătorul");
            }

            // Apelați metoda corespunzătoare din ProdusDAL pentru a actualiza produsul în baza de date
            produsDAL.ModifyProduct(produs);
        }

        public void DeleteProduct(Produs product)
        {
            if (product == null || product.CodBare == null)
            {
                throw new AgendaException("Alege un produs!");
            }
            produsDAL.DeleteProduct(product);
            ProduseList.Remove(product);
        }

        public Categorie GetCategoryForProduct(Produs product)
        {
            return produsDAL.GetCategoryForProduct(product);
        }

        public void AddProduct(Produs produs)
        {
            if (produs == null)
            {
                throw new AgendaException("Trebuie specificat un produs");
            }
            if (string.IsNullOrEmpty(produs.NumeProdus))
            {
                throw new AgendaException("Trebuie precizat numele produsului");
            }
            if (string.IsNullOrEmpty(produs.CodBare))
            {
                throw new AgendaException("Trebuie precizat codul de bare");
            }
            if (produs.Categorie == null)
            {
                throw new AgendaException("Trebuie precizată categoria");
            }
            if (produs.Producator == null)
            {
                throw new AgendaException("Trebuie precizat producătorul");
            }

            produsDAL.AddProduct(produs);
            ProduseList.Add(produs);
        }

    }
}
