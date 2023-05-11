using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.BusinessLogic.IServices
{
    public interface IBaseService : IService
    {
        bool Delete(int id);

        bool Exist(int id);
    }
}
