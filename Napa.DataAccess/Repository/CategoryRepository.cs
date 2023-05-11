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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly DbContextApplication _dbContext;

        public CategoryRepository(DbContextApplication dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
        }
    }
}
