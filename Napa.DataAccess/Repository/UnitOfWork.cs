﻿using Napa.DataAccess.Data;
using Napa.DataAccess.Repository;
using Napa.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DbContextApplication _dbContext;
        public IApplicationUserRepository ApplicationUserRepo { get; private set; }
        public ICategoryRepository CategoryRepo { get; private set; }
        public IAuthorRepository AuthorRepo { get; private set; }
        public IBookRepository BookRepo { get; private set; }

        public UnitOfWork(DbContextApplication dbContext)
        {
            _dbContext = dbContext;
            ApplicationUserRepo = new ApplicationUserRepository(_dbContext);
            CategoryRepo = new CategoryRepository(_dbContext);
            AuthorRepo = new AuhthorRepository(_dbContext);
            BookRepo = new BookRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
