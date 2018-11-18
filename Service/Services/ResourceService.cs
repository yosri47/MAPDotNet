using Data.Infrastructures;
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
    public class ResourceService : Service<ressource>, IResourceService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        IUserService users;
        
        public ResourceService() : base(utk) {
            users = new UserService();
        }

        public _break getLeave(int? leaveId)
        {
            throw new NotImplementedException();
        }

        public mandate getMandate(int? mandateId)
        {
            throw new NotImplementedException();
        }

        public string getNameFromId(int id)
        {
            try {
                return users.GetMany(u => u.userId == id).Select(u => u.name).First();
            }catch(Exception e)
            {
                return "Anonymous";
            }
        }

        public project getProject(int? projectId)
        {
            throw new NotImplementedException();
        }

        public int getUserId(string name, string emailaddress)
        {
            try
            {
                return users.GetMany(u => u.emailAddress.Equals(emailaddress) && u.name.Equals(name)).Select(u => u.userId).First();
            }catch(Exception e)
            {
                return 4;
            }
        }
    }
}
