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
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            Author? oldData = _unitOfWork.AuthorRepo.Get(u => u.Id == id);
            if (oldData == null)
            {
                return false;
            }

            _unitOfWork.AuthorRepo.Remove(oldData);
            _unitOfWork.Save();

            return true;
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Author Get(Expression<Func<Author, bool>> filter)
        {
            Author? data = _unitOfWork.AuthorRepo.Get(filter);

            if (data == null)
            {
                throw new Exception("Category Not Found");
            }

            return data;
        }

        public void Create(Author data)
        {
            _unitOfWork.AuthorRepo.Add(data);

            _unitOfWork.Save();
        }

        public List<Author> GetAll()
        {
            return _unitOfWork.AuthorRepo.GetAll().ToList();
        }

        public Author? GetOne(int id)
        {
            return _unitOfWork.AuthorRepo.Get(c => c.Id == id);
        }

        public bool Update(Author data)
        {
            try
            {
                Author oldData = this.GetOne(data.Id);

                if (oldData != null)
                {
                    oldData.Name = data.Name ?? oldData.Name;
                    oldData.Description = data.Description ?? oldData.Description;
                    oldData.Dob = data.Dob ?? oldData.Dob;
                }

                _unitOfWork.AuthorRepo.Update(oldData);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
