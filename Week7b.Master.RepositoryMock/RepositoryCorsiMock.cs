using System.Collections.Generic;
using System.Linq;
using Week7b.Master.Core.Entities;
using Week7b.Master.Core.InterfaceRepositories;

namespace Week7b.Master.RepositoryMock
{
    public class RepositoryCorsiMock : IRepositoryCorsi
    {
        //Dati finti
        public static List<Corso> Corsi = new List<Corso>()
        {
            new Corso{CorsoCodice="C-01", Nome="Grafica Editoriale", Descrizione="Grafica base"},
            new Corso{CorsoCodice="C-02", Nome="Linguistica Generale", Descrizione="studio della Linguistica Italiana"}
        };


        public Corso Add(Corso item)
        {
            Corsi.Add(item);
            return item;
        }

        public bool Delete(Corso item)
        {
            Corsi.Remove(item);
            return true;
        }

        public List<Corso> GetAll()
        {
            return Corsi;
        }

        public Corso GetByCode(string code)
        {
            return Corsi.Find(c => c.CorsoCodice == code);

        }

        public Corso Update(Corso item)
        {
            var old = Corsi.FirstOrDefault(c => c.CorsoCodice == item.CorsoCodice);
            old.Nome = item.Nome;
            old.Descrizione = item.Descrizione;
            return item;
        }
    }
}