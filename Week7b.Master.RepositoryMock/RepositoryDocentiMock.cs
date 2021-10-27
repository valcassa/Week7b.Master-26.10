using System.Collections.Generic;
using System.Linq;
using Week7b.Master.Core.Entities;
using Week7b.Master.Core.InterfaceRepositories;

namespace Week7b.Master.RepositoryMock 
{
    public class RepositoryDocentiMock : IRepositoryDocenti
    {
        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente{ID=1, Nome="Leonardo", Cognome="Aloia", Email="leon@live.it", Telefono="3456785901"},
            new Docente{ID=2, Nome="Valeria", Cognome="Pastore", Email="vale@live.it", Telefono="345675809"}
        };

        public Docente Add(Docente item)
        {
            if (Docenti.Count() == 0)
            {
                item.ID = 1;
            }
            else
            {
                item.ID = Docenti.Max(x => x.ID) + 1;
            }
            Docenti.Add(item);
            return item;
        }

        public bool Delete(Docente item)
        {
            Docenti.Remove(item);
            return true;
        }

        public List<Docente> GetAll()
        {
            return Docenti.ToList();
        }

        public Docente GetById(int id)
        {
            return GetAll().FirstOrDefault(d => d.ID == id);
        }

        public Docente Update(Docente item)
        {
            var old = GetById(item.ID);
            old.Email = item.Email;
            old.Telefono = item.Telefono;
            return item;
        }
    }
}