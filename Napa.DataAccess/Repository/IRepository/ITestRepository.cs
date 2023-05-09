using Napa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyWeb.DataAccess.Repository.IRepository;

namespace Napa.DataAccess.Repository.IRepository
{
    public interface ITestRepository : IRepository<TestEntity>
    {
        void DoSomething();
    }
}
