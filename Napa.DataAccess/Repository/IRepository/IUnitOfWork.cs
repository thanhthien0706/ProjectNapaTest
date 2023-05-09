﻿using Napa.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITestRepository TestRepo { get; }
        IApplicationUserRepository ApplicationUserRepo { get; }

        void Save();
    }
}
