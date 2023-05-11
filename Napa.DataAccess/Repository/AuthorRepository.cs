using Napa.DataAccess.Data;
using Napa.DataAccess.Repository.IRepository;
using Napa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.DataAccess.Repository
{
    public class AuhthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly DbContextApplication _dbContext;

        public AuhthorRepository(DbContextApplication dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Author author)
        {
            _dbContext.Authors.Update(author);
        }
    }
}
