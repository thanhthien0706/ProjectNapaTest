using Napa.BusinessLogic.IServices;
using Napa.DataAccess.Repository.IRepository;
using Napa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Napa.BusinessLogic
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Book category)
        {
            _unitOfWork.BookRepo.Add(category);
            _unitOfWork.Save();
        }

        public bool Delete(int id)
        {
            Book? oldData = _unitOfWork.BookRepo.Get(u => u.Id == id);
            if (oldData == null)
            {
                return false;
            }

            _unitOfWork.BookRepo.Remove(oldData);
            _unitOfWork.Save();

            return true;
        }

        public void Delete(Book? oldData)
        {

            _unitOfWork.BookRepo.Remove(oldData);
            _unitOfWork.Save();

        }


        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Book Get(Expression<Func<Book, bool>> filter)
        {
            Book? data = _unitOfWork.BookRepo.Get(filter);

            if (data == null)
            {
                throw new Exception("Book Not Found");
            }

            return data;
        }

        public List<Book> GetAll()
        {
            return _unitOfWork.BookRepo.GetAll().ToList();
        }

        public Book GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Book data)
        {
            _unitOfWork.BookRepo.Update(data);
            _unitOfWork.Save();

            return true;
        }
    }
}
