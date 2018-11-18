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
        IProjectService projects;
        IResumeService resumes;
        ILeaveService leaves;
        IMandateService mandates;
        
        public ResourceService() : base(utk) {
            users = new UserService();
            projects = new ProjectService();
            resumes = new ResumeService();
            leaves = new LeaveService();
            mandates = new MandateService();
        }

        public _break getLeave(int leaveId)
        {
            return leaves.GetById(leaveId);
        }

        public mandate getMandate(int mandateId)
        {
             return mandates.GetById(mandateId);
        }

        public string getNameFromId(int id)
        {
            return users.GetMany(u => u.userId == id).Select(u => u.name).First();
        }

        public project getProject(int projectId)
        {
            return projects.GetById(projectId);
        }

        public int getUserId(string name, string emailaddress)
        {
            try
            {
                return users.GetMany(u => u.emailAddress.Equals(emailaddress) && u.name.Equals(name)).Select(u => u.userId).First();
            }catch(Exception)
            {
                return 4;
            }
        }

        public resume getResume(int resumeId)
        {
            return resumes.GetById(resumeId);
        }
    }
}
