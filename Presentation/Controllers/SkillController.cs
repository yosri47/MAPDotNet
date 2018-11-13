using Domain.Entities;
using Newtonsoft.Json;
using Presentation.Models;
using Service.IServices;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class SkillController : Controller
    {
        ISkillService skillService;
        public SkillController()
        {
            skillService = new SkillService();
        }

        // GET: Skill
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/rest/skills").Result;
            if(response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<SkillVM>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();

        }

        // GET: Skill/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Skill/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Skill/Create
        [HttpPost]
        public ActionResult Create(SkillVM sk)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.PostAsJsonAsync<SkillVM>("map-web/rest/skills", sk).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

        // GET: Skill/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Skill/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skill/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/rest/skills/"+id).Result;
            return RedirectToAction("Index");
        }

        // POST: Skill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
