using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using static Presentation.Controllers.RequestsController.Enum;

namespace Presentation.Controllers
{
    public class RequestsController : Controller
    {
        public class Enum
        {
            public enum NotificationType
            {
                error,
                success,
                warning,
                info
            }

        }

        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "";
            TempData["notification"] = msg;
        }

        // GET: Requests
        public ActionResult Index()
        {
            return View();
        }

        // GET: Requests/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        [HttpPost]
        public ActionResult Create(RequestModel res)
        {
            string userid = System.Web.HttpContext.Current.Session["idUser"].ToString();
            int id = int.Parse(userid);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");


            client.PostAsJsonAsync<RequestModel>("map-web/rest/req/add?idcl="+id+"&idad=1", res).ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("Create");
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Requests/Edit/5
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

        // GET: Requests/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Requests/Delete/5
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
