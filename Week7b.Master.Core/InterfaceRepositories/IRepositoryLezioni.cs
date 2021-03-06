using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7b.Master.Core.Entities;

namespace Week7b.Master.Core.InterfaceRepositories
{
    public interface IRepositoryLezioni: IRepository<Lezione>
    {
        public Lezione GetById(int id);
    }
}
