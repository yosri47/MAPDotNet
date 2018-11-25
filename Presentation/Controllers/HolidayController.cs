using Domain.Entities;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Presentation.Controllers
{
    public class HolidayController : Controller
    {
        // GET: Holiday
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/rest/holidays").Result;
            IEnumerable<HolidayVM> liste;
            if (response.IsSuccessStatusCode)
            {
                liste = response.Content.ReadAsAsync<IEnumerable<HolidayVM>>().Result;
            }
            else
            {
                liste = null;
            }
            //calendar view
            foreach (var holiday in liste)
            {
                holiday.startDateEasy = holiday.startDate.ToString("dd/MM/yyyy");
                holiday.endDateEasy = holiday.endDate.ToString("dd/MM/yyyy");
                for (var dt = holiday.startDate; dt <= holiday.endDate; dt = dt.AddDays(1))
                {
                    holiday.calendrier.SelectedDate = dt;
                }
                holiday.calendrier.SelectionMode = CalendarSelectionMode.None;

            }
            
            return View(liste);
        }

        // GET: Holiday/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Holiday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Holiday/Create
        [HttpPost]
        public ActionResult Create(HolidayVM hol)
        {
            holiday holiday = new holiday { startDate = hol.startDate.Date, endDate = hol.endDate.Date, name = hol.name };
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.PostAsJsonAsync<holiday>("map-web/rest/holidays", holiday).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

        // GET: Holiday/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Holiday/Edit/5
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

        // GET: Holiday/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Holiday/Delete/5
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
