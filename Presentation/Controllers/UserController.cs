using Presentation.Models;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public async System.Threading.Tasks.Task<ActionResult> Login(UserVM user)
        {
            //var client = new RestClient("http://localhost:18080/map-web/rest/");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/map-web/rest/");
            var request = new RestRequest(Method.POST);
            var obj = new
            {
                emailAddress = user.emailAddress,
                password = user.password

            };
            /*client.AddHandler("application/json", new JsonDeserializer());
            request.RequestFormat = DataFormat.Json;
            request.Resource = "authentication";
            
            request.AddJsonBody(obj);*/
            HttpResponseMessage response = await client.PostAsJsonAsync("authentication", obj);
            //response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            UserModel u = await response.Content.ReadAsAsync<UserModel>();

            //client.AddDefaultHeader("accept", "*/*");
            //var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                System.Diagnostics.Debug.WriteLine(u.ToString());
                //Session["token"] = response.Content;
                Session["userType"] = u.userType;

                

                Session["idUser"] = u.userId;
                //Console.WriteLine(response.Content.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Content = "Bad Credentials";
                return RedirectToAction("Login", "User");
            }
        }
        public ActionResult AdminDashboard()
        {
            return View("~/Views/_ViewStart.cshtml");

        }
    }
}