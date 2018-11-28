using Data.Infrastructures;
using Domain.Entities;
using Service.IServices;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        IHolidayService holidays;

        public ResourceService() : base(utk)
        {
            users = new UserService();
            projects = new ProjectService();
            resumes = new ResumeService();
            leaves = new LeaveService();
            mandates = new MandateService();
            holidays = new HolidayService();
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
            }
            catch (Exception)
            {
                return 4;
            }
        }

        public resume getResume(int resumeId)
        {
            return resumes.GetById(resumeId);
        }

        public void updateAvailability()
        {
            DateTime today = DateTime.Today.Date;
            try
            {
                foreach (var holiday in holidays.GetMany())
                {
                    //THERE'S A HOLIDAY
                    if (today.Ticks >= holiday.startDate.Ticks && today.Ticks <= holiday.endDate.Ticks)
                    {
                        foreach (var item in this.GetMany())
                        {
                            item.availability = "Unavailable";
                            this.Update(item);
                            this.Commit();
                        }
                    }
                    //NO HOLIDAYS
                    else
                    {
                        foreach (var res in this.GetMany())
                        {
                            res.availability = "Available";
                            res.isOnLeave = res.isOnLeave ?? false;
                            res.mandateId = res.mandateId ?? 0;
                            res.leaveId = res.leaveId ?? 0;

                            //RESOURCE IS NOT ON A LEAVE
                            if (!(res.isOnLeave ?? false))
                            {
                                //CHECK IF HE HAS A LEAVE
                                //HE HAS A LEAVE COMING UP
                                if (res.leaveId != 0)
                                {
                                    try
                                    {
                                        _break brake = leaves.GetMany().Where(l => l.isGranted && l.leaveId == res.leaveId).FirstOrDefault();
                                        brake.startDate = brake.startDate ?? new DateTime();
                                        brake.endDate = brake.endDate ?? new DateTime();
                                        //TIME TO TAKE HIS LEAVE
                                        if (today.Ticks >= (brake.startDate ?? new DateTime()).Ticks && (brake.endDate ?? new DateTime()).Ticks <= holiday.endDate.Ticks)
                                        {
                                            res.isOnLeave = true;
                                            res.availability = "Unavailable";
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Debug.WriteLine("LEAVE NOT FOUND");
                                    }
                                }
                                //NO LEAVES COMING UP
                                else
                                {
                                    //CHECK IF HE IS WORKING ON A MANDATE
                                    //HE S ON A MANDATE
                                    if (res.mandateId != 0)
                                    {
                                        try
                                        {
                                            mandate m = mandates.GetById((res.mandateId??0));
                                            m.startDate = m.startDate ?? new DateTime();
                                            m.endDate = m.endDate ?? new DateTime();
                                            //IS THE MANDATE OVER ?
                                            if (today.Ticks < (m.startDate ?? new DateTime()).Ticks || today.Ticks > (m.endDate ?? new DateTime()).Ticks)
                                            {
                                                res.availability = "Available";
                                                res.contractType = "InterMandate";
                                                res.mandateId = 0;
                                            }
                                            //IT S NOT
                                            else
                                            {
                                                res.availability = "Unavailable";
                                                res.contractType = "Mandate";
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Debug.WriteLine("mandate not found");
                                        }
                                    }
                                    //HE HAS NO MANDATE
                                    else
                                    {
                                        res.availability = "Available";
                                        res.contractType = "InterMandate";
                                    }
                                }
                            }
                            //ON LEAVE
                            else
                            {
                                try
                                {
                                    _break leave = leaves.GetMany().Where(l => l.isGranted && l.leaveId == res.leaveId).FirstOrDefault();
                                    leave.startDate = leave.startDate ?? new DateTime();
                                    leave.endDate = leave.endDate ?? new DateTime();
                                    //LEAVE HAS ENDED
                                    if (today.Ticks > (leave.endDate ?? new DateTime()).Ticks)
                                    {

                                        res.leaveId = 0;
                                        res.isOnLeave = false;
                                        //DOES HE HAVE A MANDATE HE S WORKING ON
                                        if (res.mandateId != 0)
                                        {
                                            try
                                            {
                                                
                                                mandate man = mandates.GetById((res.mandateId ?? 0));
                                                man.startDate = man.startDate ?? new DateTime();
                                                man.endDate = man.endDate ?? new DateTime();
                                                //THE MANDATE IS OVER
                                                if (today.Ticks < (man.startDate ?? new DateTime()).Ticks || today.Ticks > (man.endDate ?? new DateTime()).Ticks)
                                                {
                                                    res.availability = "Available";
                                                    res.contractType = "InterMandate";
                                                    res.mandateId = 0;
                                                }
                                                //THE MANDATE IS STILL GOING ON
                                                else
                                                {
                                                    res.availability = "Unavailable";
                                                    res.contractType = "Mandate";
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Debug.WriteLine("Mandate not found 2");
                                            }
                                        }
                                        //NOT WORKING ON ANY MANDATE
                                        else
                                        {
                                            res.availability = "Available";
                                            res.contractType = "InterMandate";
                                        }
                                    }
                                    //LEAVE IS STILL UP
                                    else
                                    {
                                        res.availability = "Unavailable";
                                        res.isOnLeave = true;
                                    }
                                }
                                catch (Exception)
                                {
                                    Debug.WriteLine("LEAVE NOT FOUND");
                                }
                            }
                            this.Update(res);
                            this.Commit();
                        }

                    }
                }
            }catch(Exception)
            {
                Debug.WriteLine("No holidays found");
            }
        }
    
            }
}
