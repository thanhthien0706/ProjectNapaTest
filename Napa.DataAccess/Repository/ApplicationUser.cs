using Napa.DataAccess.Data;
using Napa.DataAccess.Repository.IRepository;
using Napa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyWeb.DataAccess.Repository;

namespace Napa.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        DbContextApplication _dbContext;

        public ApplicationUserRepository(DbContextApplication dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
