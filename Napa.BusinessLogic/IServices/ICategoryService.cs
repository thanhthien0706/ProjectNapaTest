using Napa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Napa.BusinessLogic.IServices
{
    public interface ICategoryService : IBaseService
    {
        Category Get(Expression<Func<Category, bool>> filter);

        void Create(Category category);

        bool IsNameAndDisplayOrderMatch(Category category);

        List<Category> GetAll();

        Category GetOne(int id);

        bool Update(Category category);

    }
}
