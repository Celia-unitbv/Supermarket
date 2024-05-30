using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.BusinessLogicLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    internal class OferteVM : BasePropertyChanged
    {
        private OfertaBLL ofertaBLL = new OfertaBLL();

        public Oferta GetOfertaByCodBare(string codBare)
        {
            return ofertaBLL.GetOfertaByCodBare(codBare);
        }

        public List<Oferta> GetOferteByExpirare(int zileInainteDeExpirare, decimal procentReducere)
        {
            return ofertaBLL.GetOferteByExpirare(zileInainteDeExpirare, procentReducere);
        }

        public List<Oferta> GetOferteLichidareStoc(decimal procentReducere, int pragStoc)
        {
            return ofertaBLL.GetOferteLichidareStoc(procentReducere, pragStoc);
        }
    }
}
