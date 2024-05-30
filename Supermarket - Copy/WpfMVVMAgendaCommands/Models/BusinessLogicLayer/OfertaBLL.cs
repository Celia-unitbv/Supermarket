using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;
using WpfMVVMAgendaCommands.Models.EntityLayer;

namespace WpfMVVMAgendaCommands.Models.BusinessLogicLayer
{
    internal class OfertaBLL
    {
        private OfertaDAL ofertaDAL = new OfertaDAL();

        public Oferta GetOfertaByCodBare(string codBare)
        {
            return ofertaDAL.GetOfertaByCodBare(codBare);
        }

        public List<Oferta> GetOferteByExpirare(int zileInainteDeExpirare, decimal procentReducere)
        {
            return ofertaDAL.GetOferteByExpirare(zileInainteDeExpirare, procentReducere);
        }

        public List<Oferta> GetOferteLichidareStoc(decimal procentReducere, int pragStoc)
        {
            return ofertaDAL.GetOferteLichidareStoc(procentReducere, pragStoc);
        }
    }
}
