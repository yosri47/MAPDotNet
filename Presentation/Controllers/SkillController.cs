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
        IResourceService rs;
        public SkillController()
        {
            skillService = new SkillService();
            rs = new ResourceService();
        }

        // GET: Skill
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            var categories = skillService.GetMany().Select(c => c.category).Distinct();
            List<SkillVM> skills = new List<SkillVM>();
            IEnumerable<SkillVM> resourceSkills;
            var skillstocast = skillService.GetMany();
            foreach (var s in skillstocast)
            {
                skills.Add(new SkillVM { category=s.category,name=s.name,skillId=s.skillId,count=0});
            }
            var resources = rs.GetMany().Where(r => r.resumeId > 0);
            foreach (var resource in resources)
            {
                response = Client.GetAsync("map-web/rest/resources/skills/" +resource.userId).Result;
                if (response.IsSuccessStatusCode)
                {
                    resourceSkills = response.Content.ReadAsAsync<IEnumerable<SkillVM>>().Result;
                    foreach (var s in skills)
                    {
                        if (resourceSkills.Contains(resourceSkills.Where(r=>r.skillId == s.skillId).FirstOrDefault()))
                        {
                            s.count += 1;
                        }
                    }
                }
            }
            ViewBag.result = skills;
            ViewBag.categories = categories;

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
            IEnumerable<String> categories = skillService.GetMany().Select(c => c.category).Distinct();
            ViewBag.result = categories;
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
            skillService.Delete(s => s.skillId == id);
            skillService.Commit();
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
