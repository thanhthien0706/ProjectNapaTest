using Napa.DataAccess.Data;
using Napa.DataAccess.Repository;
using Napa.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DbContextApplication _dbContext;
        public ITestRepository TestRepo { get; private set; }
        public IApplicationUserRepository ApplicationUserRepo { get; private set; }

        public UnitOfWork(DbContextApplication dbContext)
        {
            _dbContext = dbContext;
            TestRepo = new TestRepository(_dbContext);
            ApplicationUserRepo = new ApplicationUserRepository(_dbContext);

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
