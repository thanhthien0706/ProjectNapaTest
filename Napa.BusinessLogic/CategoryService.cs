using Napa.BusinessLogic.IServices;
using Napa.DataAccess.Repository.IRepository;
using Napa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Napa.BusinessLogic
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            Category? oldData = _unitOfWork.CategoryRepo.Get(u => u.Id == id);
            if (oldData == null)
            {
                return false;
            }

            _unitOfWork.CategoryRepo.Remove(oldData);
            _unitOfWork.Save();

            return true;
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            Category? category = _unitOfWork.CategoryRepo.Get(filter);

            if (category == null)
            {
                throw new Exception("Category Not Found");
            }

            return category;
        }

        public void Create(Category category)
        {
            _unitOfWork.CategoryRepo.Add(category);

            _unitOfWork.Save();
        }

        public bool IsNameAndDisplayOrderMatch(Category category)
        {
            return category.Title == category.DisplayOrder.ToString();
        }

        public List<Category> GetAll()
        {
            return _unitOfWork.CategoryRepo.GetAll().ToList();
        }

        public Category? GetOne(int id)
        {
            return _unitOfWork.CategoryRepo.Get(c => c.Id == id);
        }

        public bool Update(Category category)
        {
            try
            {

                Category oldData = this.GetOne(category.Id);

                if (oldData != null)
                {
                    oldData.Title = category.Title ?? oldData.Title;
                    oldData.DisplayOrder = category.DisplayOrder;
                }


                _unitOfWork.CategoryRepo.Update(oldData);
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
