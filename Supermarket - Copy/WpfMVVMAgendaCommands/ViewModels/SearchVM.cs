using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    internal class SearchVM : BasePropertyChanged
    {
        private ObservableCollection<Produs> allProducts;

        public SearchVM(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            FilteredProducts = new ObservableCollection<Produs>();
            allProducts = mainViewModel.ProdusVM.ProduseList;
        }

        public MainViewModel MainViewModel { get; set; }
        public ObservableCollection<Produs> FilteredProducts { get; set; }

        public void FilterProducts(int producerId, int? categoryId)
        {
            var filtered = allProducts.Where(p => p.Producator.IdProducator == producerId);

            if (categoryId.HasValue)
            {
                filtered = filtered.Where(p => p.Categorie.IdCategorie == categoryId.Value);
            }

            FilteredProducts.Clear();
            foreach (var product in filtered)
            {
                FilteredProducts.Add(product);
            }
        }
    }
}
