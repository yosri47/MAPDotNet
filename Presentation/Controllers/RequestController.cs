using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult ListRequest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/rest/req/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<RequestModel>>().Result;
            }

            else
            {
                ViewBag.result = "error";

            }

            return View();

        }
        [HttpGet]
        public ActionResult createRessource()
        {
            return View("createRessource");

        }

        [HttpPost]
        public ActionResult createRessource(RequestModel res)
        {



            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");


            client.PostAsJsonAsync<RequestModel>("map-web/rest/req", res).ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("createRessource");
        }
        [HttpGet]
        public ActionResult ValiderRequest(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/rest/req/valider?idreq=" + id).Result;
            return RedirectToAction("ListRequest");
        }
    }
}