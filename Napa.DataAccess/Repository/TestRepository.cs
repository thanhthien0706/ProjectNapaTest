using Napa.DataAccess.Data;
using Napa.DataAccess.Repository.IRepository;
using Napa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyWeb.DataAccess.Repository;
using UdemyWeb.DataAccess.Repository.IRepository;

namespace Napa.DataAccess.Repository
{
    public class TestRepository : Repository<TestEntity>, ITestRepository
    {
        public readonly DbContextApplication _dbContext;

        public TestRepository(DbContextApplication dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void DoSomething()
        {
            Console.WriteLine("Do Something test repository/service");
        }
    }
}
