using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tulpep.NotificationWindow;

namespace Presentation.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult ListMessage()
        {
            //int userid = HttpContext.Current.Session["idUser"];
            string userid = System.Web.HttpContext.Current.Session["idUser"].ToString();
            int id = int.Parse(userid);
            System.Diagnostics.Debug.WriteLine(id);
            System.Diagnostics.Debug.WriteLine(id);
            System.Diagnostics.Debug.WriteLine(id);
            System.Diagnostics.Debug.WriteLine(id);
            System.Diagnostics.Debug.WriteLine(id);


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/rest/mes/recu?idrecu=4").Result;
            if (response.IsSuccessStatusCode)
            {


                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<MessageModel>>().Result;

            }

            else
            {
                ViewBag.result = "error";
            }

            return View();
        }


        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(MessageModel res)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");


            client.PostAsJsonAsync<MessageModel>("map-web/rest/mes/add?object=" + res._object + "&content=" + res.content + "&type=" + res.type + "&clsend=2&rsrecu=5", res).ContinueWith((e => e.Result.EnsureSuccessStatusCode()));


            return RedirectToAction("ListMessage");
        }


       


        // GET: Message/map
        public ActionResult Map()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/rest/Clients").Result;

            if (response.IsSuccessStatusCode)
            {


                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ClientModel>>().Result;

            }

            else
            {
                ViewBag.result = "error";

            }

            return View();
        }
    }

}