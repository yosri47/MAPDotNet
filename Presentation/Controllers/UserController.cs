using Presentation.Models;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(UserVM user)
        {
            var client = new RestClient("http://localhost:18080/map-web/rest/");
            var request = new RestRequest(Method.POST);
            client.AddHandler("application/json", new JsonDeserializer());
            request.RequestFormat = DataFormat.Json;
            request.Resource = "authentication";
            var obj = new
            {
                emailAddress = user.emailAddress,
                password = user.password

            };
            request.AddJsonBody(obj);
            client.AddDefaultHeader("accept", "*/*");
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Session["token"] = response.Content;
                Console.WriteLine(response.Content.ToString());
                if(Session["token"].Equals("Administrator"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Create", "Mandate");

                }
            }
            else
{
                ViewBag.Content = "Bad Credentials";
                return RedirectToAction("Login", "User");
            }
        }
    }
}