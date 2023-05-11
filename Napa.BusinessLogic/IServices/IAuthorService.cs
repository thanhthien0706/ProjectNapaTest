using Napa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Napa.BusinessLogic.IServices
{
    public interface IAuthorService : IBaseService
    {
        Author Get(Expression<Func<Author, bool>> filter);

        void Create(Author category);

        List<Author> GetAll();

        Author GetOne(int id);

        bool Update(Author category);

    }
}
