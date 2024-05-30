using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.BusinessLogicLayer
{
    internal class CategorieBLL
    {
        public ObservableCollection<Categorie> CategorieList { get; set; }
        public ObservableCollection<CategoryValue> CategoryValues { get; set; }

        private CategorieDAL categorieDAL = new CategorieDAL();

        public CategorieBLL()
        {
            CategorieList = new ObservableCollection<Categorie>();
            CategoryValues = new ObservableCollection<CategoryValue>();
            LoadAllCategories();
        }

        private void LoadAllCategories()
        {
            CategorieList = categorieDAL.GetAllCategories();
        }

        public void LoadCategoryValues()
        {
            CategoryValues = categorieDAL.GetCategoryValues();
        }

        public void AddCategory(Categorie category)
        {
            if (category == null)
            {
                throw new ArgumentException("Categoria nu poate fi null");
            }
            if (string.IsNullOrEmpty(category.NumeCategorie))
            {
                throw new ArgumentException("Numele categoriei nu poate fi gol");
            }

            categorieDAL.AddCategory(category);
            CategorieList.Add(category);
        }

        public void ModifyCategory(Categorie category)
        {
            if (category == null)
            {
                throw new ArgumentException("Trebuie selectată o categorie");
            }
            if (string.IsNullOrEmpty(category.NumeCategorie))
            {
                throw new ArgumentException("Numele categoriei nu poate fi gol");
            }

            categorieDAL.ModifyCategory(category);
            LoadAllCategories(); // Reload all categories to reflect changes
        }

        public void DeleteCategory(Categorie category)
        {
            if (category == null)
            {
                throw new ArgumentException("Trebuie selectată o categorie");
            }

            categorieDAL.DeleteCategory(category);
            CategorieList.Remove(category);
        }
        public Categorie GetCategoryForProduct(Produs product)
        {
            return categorieDAL.GetCategoryForProduct(product);
        }

    }

}
