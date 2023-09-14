using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infraestruture;
using Data.Entity;
using Data.IRepository;
using System.Data.Entity;

namespace Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(DbContext dbContext) : base (dbContext)
        {

        }
    }
}
