using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaCommands.Models.BusinessLogicLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    public class CategoryVM : BasePropertyChanged
    {
        private CategorieBLL categorieBLL = new CategorieBLL();

        public CategoryVM()
        {
            CategorieList = categorieBLL.CategorieList;
            CategoryValues = categorieBLL.CategoryValues;
        }

        public ObservableCollection<Categorie> CategorieList
        {
            get => categorieBLL.CategorieList;
            set
            {
                categorieBLL.CategorieList = value;
                NotifyPropertyChanged("CategorieList");
            }
        }

        public ObservableCollection<CategoryValue> CategoryValues
        {
            get => categorieBLL.CategoryValues;
            set
            {
                categorieBLL.CategoryValues = value;
                NotifyPropertyChanged(nameof(CategoryValues));
            }
        }

        public void LoadCategoryValues()
        {
            categorieBLL.LoadCategoryValues();
            NotifyPropertyChanged(nameof(CategoryValues));
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Categorie>(categorieBLL.AddCategory);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Categorie>(categorieBLL.ModifyCategory);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Categorie>(categorieBLL.DeleteCategory);
                }
                return deleteCommand;
            }
        }
    }

}
