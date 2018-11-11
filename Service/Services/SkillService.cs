﻿using Data.Infrastructures;
using Domain;
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
    //fiha kol chay, toutes les méthodes spécifiques sauf CRUD

    //Service<Film> classe mère contenant les CRUD
    public class SkillService : Service<skill>, ISkillService
    {
        //Pour utiliser quelque chose de la couche Data, on a besoin de l'Unit of Work
        //L'unit of work nécessite le context(db factory) au niveau du constructeur
        //Le Factory est l'usine de fabrication d'objets
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public SkillService() : base(utk)
        {

        }



    }
}
