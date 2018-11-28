using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IResourceService : IService<ressource>
    {
        String getNameFromId(int id);
        int getUserId(string name, string emailaddress);
        project getProject(int projectId);
        _break getLeave(int leaveId);
        mandate getMandate(int mandateId);
        resume getResume(int resumeId);
        void updateAvailability();
    }
}
