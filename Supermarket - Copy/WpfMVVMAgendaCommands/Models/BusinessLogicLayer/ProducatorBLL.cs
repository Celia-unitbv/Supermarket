using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.BusinessLogicLayer
{
    internal class ProducatorBLL
    {
        public ObservableCollection<Producator> ProducatorList { get; set; }

        private ProducatorDAL producatorDAL = new ProducatorDAL();

        public ProducatorBLL()
        {
            ProducatorList = new ObservableCollection<Producator>();
            LoadAllProducers();
        }

        private void LoadAllProducers()
        {
            ProducatorList = producatorDAL.GetAllProducers();
        }

        public ObservableCollection<Producator> GetAllProducers()
        {
            return producatorDAL.GetAllProducers();
        }

        public Producator GetProducerForProduct(Produs product)
        {
            return producatorDAL.GetProducerForProduct(product);
        }
        public void AddProducer(Producator producer)
        {
            if (producer == null)
            {
                throw new ArgumentException("Producătorul nu poate fi null");
            }
            if (string.IsNullOrEmpty(producer.NumeProducator))
            {
                throw new ArgumentException("Numele producătorului nu poate fi gol");
            }
            if (string.IsNullOrEmpty(producer.TaraOrigine))
            {
                throw new ArgumentException("Țara de origine nu poate fi goală");
            }

            producatorDAL.AddProducer(producer);
            ProducatorList.Add(producer);
        }

        public void ModifyProducer(Producator producer)
        {
            if (producer == null)
            {
                throw new ArgumentException("Trebuie selectat un producător");
            }
            if (string.IsNullOrEmpty(producer.NumeProducator))
            {
                throw new ArgumentException("Numele producătorului nu poate fi gol");
            }
            if (string.IsNullOrEmpty(producer.TaraOrigine))
            {
                throw new ArgumentException("Țara de origine nu poate fi goală");
            }

            producatorDAL.ModifyProducer(producer);
            LoadAllProducers(); // Reload all producers to reflect changes
        }

        public void DeleteProducer(Producator producer)
        {
            if (producer == null)
            {
                throw new ArgumentException("Trebuie selectat un producător");
            }

            producatorDAL.DeleteProducer(producer);
            ProducatorList.Remove(producer);
        }

    }
}
