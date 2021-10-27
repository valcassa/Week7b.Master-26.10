using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Week7b.Master.MVC.Models
{
    public class CorsoViewModel
    {
        [DisplayName("Codice Corso")]

        public string CodiceCorso { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }

        internal static object ToCorso()
        {
            throw new NotImplementedException();
        }
    }
}
