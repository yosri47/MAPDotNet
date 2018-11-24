using Domain.Entities;
using Presentation.Models;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class MandateController : Controller
    {

        // GET: Mandate
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/rest/mandates").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<MandateVM>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View(ViewBag.result);
        }

        // GET: Mandate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mandate/Create
        public ActionResult Create()
        {
            ResourceDropList();
           ProjectDropList();
            return View("Create");
        }
       

        // POST: Mandate/Create
        [HttpPost]
        public ActionResult Create(MandateVM m)
        {

            ResourceDropList();
            ProjectDropList();
            string pId = Request.Form["Project"].ToString();
            string rId = Request.Form["Resource"].ToString();


            var client = new RestClient("http://localhost:18080/map-web/rest/");
            var request = new RestRequest(Method.POST);
            client.AddHandler("application/json", new JsonDeserializer());
            request.RequestFormat = DataFormat.Json;
            request.Resource = "mandates";
            var obj = new
            {
                startDate="2015-11-30",
	            endDate="2018-12-30",
                mandatepk = new
                {
                    projectId = Int32.Parse(pId),
                    resourceId = Int32.Parse(rId)
                }
               

            };
            request.AddJsonBody(obj);
            request.AddHeader("Authorization", "Bearer " + Session["token"]);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Create","Mandate");
            }




         
        }

        // GET: Mandate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mandate/Edit/5
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

        // GET: Mandate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mandate/Delete/5
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

        public void ResourceDropList()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/rest/resources").Result;
            ViewBag.Resource = response.Content.ReadAsAsync<IEnumerable<ResourceVM>>().Result;

        }
        public void ProjectDropList()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/rest/Projects").Result;
            ViewBag.Project = response.Content.ReadAsAsync<IEnumerable<ProjectVM>>().Result;
        }
    }
}
