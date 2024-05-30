using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaCommands.Models;
using WpfMVVMAgendaCommands.Models.BusinessLogicLayer;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.ViewModels.Commands
{
    internal class ProdusVM : BasePropertyChanged
{
    private ProdusBLL produsBLL = new ProdusBLL();
    private CategorieBLL categorieBLL = new CategorieBLL();
    private ProducatorBLL producatorBLL = new ProducatorBLL();

    public ProdusVM()
    {
        ProduseList = new ObservableCollection<Produs>();

        // Obține toate produsele și completează detaliile categoriei și producătorului
        var produse = produsBLL.GetAllProducts();
        foreach (var produs in produse)
        {
            produs.Categorie = categorieBLL.GetCategoryForProduct(produs);
            produs.Producator = producatorBLL.GetProducerForProduct(produs);
            ProduseList.Add(produs);
        }
    }

    public ObservableCollection<Produs> ProduseList
    {
        get => produsBLL.ProduseList;
        set => produsBLL.ProduseList = value;
    }

    private ICommand updateCommand;
    public ICommand UpdateCommand
    {
        get
        {
            if (updateCommand == null)
            {
                updateCommand = new RelayCommand<Produs>(produsBLL.ModifyProduct);
            }
            return updateCommand;
        }
    }

    private ICommand addCommand;
    public ICommand AddCommand
    {
        get
        {
            if (addCommand == null)
            {
                addCommand = new RelayCommand<Produs>(produsBLL.AddProduct);
            }
            return addCommand;
        }
    }

    private ICommand deleteCommand;
    public ICommand DeleteCommand
    {
        get
        {
            if (deleteCommand == null)
            {
                deleteCommand = new RelayCommand<Produs>(produsBLL.DeleteProduct);
            }
            return deleteCommand;
        }
    }
        public ObservableCollection<Produs> GetProductsByProducer(int producerId)
        {
            var produse = produsBLL.GetAllProducts().Where(p => p.Producator.IdProducator == producerId).ToList();
            foreach (var produs in produse)
            {
                produs.Categorie = categorieBLL.GetCategoryForProduct(produs);
                produs.Producator = producatorBLL.GetProducerForProduct(produs);
            }
            return new ObservableCollection<Produs>(produse);
        }

        public ObservableCollection<Produs> SearchProducts(string searchTerm, DateTime? dataExpirare = null)
        {
            return produsBLL.SearchProducts(searchTerm, dataExpirare);
        }
    }


}
