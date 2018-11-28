using Presentation.Models;
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
    public class RequestController : Controller
    {    // GET: allRequest
        public ActionResult Index()
        {
            string userid = System.Web.HttpContext.Current.Session["idUser"].ToString();
            int id = int.Parse(userid);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/rest/req/send?idsend="+id).Result;
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
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                /* if (Session["authtoken"] == null)
                return RedirectToAction("Login", "Auth");*/
                HttpClient Client = new HttpClient();
                /*Client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session["authtoken"] + "");*/
                Client.BaseAddress = new Uri("http://localhost:18080");
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string ch = "/map-web/rest/req/" + id;
                HttpResponseMessage response = Client.DeleteAsync(ch).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");


                }
                else
                {
                    ViewBag.result = response.IsSuccessStatusCode;
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}