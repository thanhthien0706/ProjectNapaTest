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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        DbContextApplication _dbContex;

        public BookRepository(DbContextApplication dbContext) : base(dbContext)
        {
            _dbContex = dbContext;
        }

        public void Update(Book book)
        {
            var oldData = _dbContex.Books.FirstOrDefault(p => p.Id == book.Id);

            if (oldData != null)
            {
                oldData.Title = book.Title;
                oldData.Description = book.Description;
                oldData.Slug = book.Slug;
                oldData.SubDescription = book.SubDescription;
                oldData.YearPublished = book.YearPublished;
                oldData.CategoryId = book.CategoryId;
                oldData.Author = book.Author;
                if (book.Thumbnail != null)
                {
                    oldData.Thumbnail = book.Thumbnail;
                }
            }

        }
    }
}
