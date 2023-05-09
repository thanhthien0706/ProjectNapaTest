using Napa.BusinessLogic.IServices;
using Napa.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.BusinessLogic
{
    public class TestService : ITestService
    {
        public IUnitOfWork _unitOfWork;
        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DoSomething()
        {
            _unitOfWork.TestRepo.DoSomething();
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
