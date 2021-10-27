﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Week7b.Master.Core.Entities;
using Week7b.Master.Core.InterfaceRepositories;

namespace Week7b.Master.RepositoryEF.RepositoryEF
{
    public class RepositoryDocentiEF : IRepositoryDocenti
    {
        public Docente Add(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Docente> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Docenti.Include(x => x.Lezioni).ToList();
            }
        }

        public Docente GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Docenti.Include(x => x.Lezioni).FirstOrDefault(d => d.ID == id);
            }
        }

        public Docente Update(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
