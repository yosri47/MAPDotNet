﻿using Data.Infrastructures;
using Domain.Entities;
using Service.IServices;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    class ProjectService : Service<project>, IProjectService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public ProjectService() : base(utk)
        {

        }
    }
}
