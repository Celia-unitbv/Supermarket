using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models;
using WpfMVVMAgendaCommands.Models.BusinessLogicLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.ViewModels
{
    internal class ProdusWCategories
    {
        public Dictionary<Produs, Categorie> CategoriiProduse { get; set; }

        public ProdusWCategories()
        {
            ProdusBLL produsBLL = new ProdusBLL();
            CategoriiProduse = new Dictionary<Produs, Categorie>();
            foreach (Produs produs in produsBLL.GetAllProducts())
            {

                CategorieBLL categoryBLL = new CategorieBLL();
            
                //CategoriiProduse.Add(produs, categoryBLL.GetCategoryForProduct(produs));
            }
        }
    }
}
