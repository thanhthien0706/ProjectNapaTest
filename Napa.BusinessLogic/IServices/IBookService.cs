using Napa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Napa.BusinessLogic.IServices
{
    public interface IBookService : IBaseService
    {
        Book Get(Expression<Func<Book, bool>> filter);

        void Create(Book category);

        List<Book> GetAll();

        Book GetOne(int id);

        bool Update(Book category);

        void Delete(Book? oldData);
    }
}
