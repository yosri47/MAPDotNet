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
            var listres = rs.GetMany(r => r.isActive ==true);
            var res = new List<ResourceVM>();
            ResourceVM resource = new ResourceVM();
            foreach (ressource r in listres)
            {
                resource.setAttributes(r);
                resource.name = rs.getNameFromId(resource.userId);
                res.Add(resource);
            }
            ViewBag.result = res;
            return View();

        }

        // GET: Resource/Details/5
        public ActionResult Details(int id)
        {
            ressource res = rs.GetById(id);
            ResourceVM r = new ResourceVM();
            r.setAttributes(res);
            r.name = rs.getNameFromId(r.userId);
            r.project = rs.getProject(r.projectId);
            r.leave = rs.getLeave(r.leaveId);
            r.mandate = rs.getMandate(r.mandateId);
            ViewBag.result = r;
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
    }
}
