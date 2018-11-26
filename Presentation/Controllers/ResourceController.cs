using Domain.Entities;
using Presentation.Models;
using Service.IServices;
using Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ResourceController : Controller
    {
        IResourceService rs;
        IUserService us;
        public ResourceController()
        {
            rs = new ResourceService();
            us = new UserService();
        }
        // GET: Resource
        public ActionResult Index()
        {
            var listres = rs.GetMany();
            var res = new List<ResourceVM>();
            foreach (ressource r in listres)
            {
                res.Add(new ResourceVM {
                    availability = r.availability,
                    contractType = r.contractType,
                    isActive = r.isActive ?? true,
                    isOnLeave = r.isOnLeave ?? false,
                    note = r.note,
                    rate = r.rate,
                    photo = r.photo,
                    userId = r.userId,
                    sector = r.sector,
                    seniority = r.seniority,
                    leaveId = r.leaveId ?? 0,
                    projectId = r.projectId ?? 0,
                    mandateId = r.mandateId ?? 0,
                    name = rs.getNameFromId(r.userId),
                    resumeId = r.resumeId ?? 0
                });
            }
            ViewBag.result = res;
            return View();

        }

        // GET: Resource/Details/5
        public ActionResult Details(int id)
        {
            var r = rs.GetById(id);
            ResourceVM res = new ResourceVM
            {
                availability = r.availability,
                contractType = r.contractType,
                isActive = r.isActive ?? true,
                isOnLeave = r.isOnLeave ?? false,
                note = r.note,
                rate = r.rate,
                photo = r.photo,
                userId = id,
                sector = r.sector,
                seniority = r.seniority,
                leaveId = r.leaveId ?? 0,
                projectId = r.projectId ?? 0,
                mandateId = r.mandateId ?? 0,
                name = rs.getNameFromId(r.userId),
                resumeId = r.resumeId ?? 0
            };
            res.name = rs.getNameFromId(res.userId);
            if (res.leaveId != 0) { res.leave = rs.getLeave(res.leaveId); }
            if (res.resumeId != 0) { res.resume = rs.getResume(res.resumeId); }
            if(res.mandateId != 0){ res.mandate = rs.getMandate(res.mandateId); }
            if(res.projectId != 0) { res.project = rs.getProject(res.projectId); }
            ViewBag.result = res;
            return View();
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(ResourceVM r)
        {
            ResourceVM resource = new ResourceVM();
            us.Add(new user {
                name = r.name,
                emailAddress = r.emailaddress,
                userType = "Resource"
            });
            us.Commit();
            rs.Add(new ressource {
                availability = "Available",contractType = "InterMandate",isActive = true,isOnLeave = false,
                note = r.note,rate = r.rate,photo = "Default.jpeg",userId = rs.getUserId(r.name,r.emailaddress),sector = r.sector,
                seniority = r.seniority
            });
            rs.Commit();
            return RedirectToAction("Index");
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Resource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/rest/resoures/remove?id="+id).Result;
            return RedirectToAction("Index");
        }

        // POST: Resource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult LoadData()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data  
                var listres = rs.GetMany();
                var res = new List<ResourceVM>();
                foreach (ressource r in listres)
                {
                    res.Add(new ResourceVM
                    {
                        availability = r.availability,
                        contractType = r.contractType,
                        isActive = r.isActive ?? true,
                        isOnLeave = r.isOnLeave ?? false,
                        note = r.note,
                        rate = r.rate,
                        photo = r.photo,
                        userId = r.userId,
                        sector = r.sector,
                        seniority = r.seniority,
                        leaveId = r.leaveId ?? 0,
                        projectId = r.projectId ?? 0,
                        mandateId = r.mandateId ?? 0,
                        name = rs.getNameFromId(r.userId),
                        resumeId = r.resumeId ?? 0
                    });
                }

                IEnumerable<ResourceVM> customerData = res;

                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    customerData = customerData.OrderBy(h => sortColumn + " " + sortColumnDir);
                }
                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.name == searchValue);
                }

                //total number of rows count     
                recordsTotal = customerData.Count();
                //Paging     
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
