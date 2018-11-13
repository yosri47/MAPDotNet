using Presentation.Models;
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
        // GET: Resource
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/rest/resoures").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ResourceVM>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: Resource/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(ResourceVM res)
        {
            

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.PostAsJsonAsync<ResourceVM>("map-web/rest/resources", res).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
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
            return View();
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
