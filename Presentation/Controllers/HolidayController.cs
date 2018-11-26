using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Controls;
using DHTMLX.Scheduler.Data;
using Domain.Entities;
using Presentation.Models;
using Service.IServices;
using Service.Services;
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
        IHolidayService hs;
        List<HolidayVM> liste;
        public HolidayController()
        {
            hs = new HolidayService();
        }
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;
            scheduler.InitialValues.Add("text", "Holiday");
            scheduler.Config.first_hour = 0;
            scheduler.Config.last_hour = 23;
            scheduler.EnableDynamicLoading(SchedulerDataLoader.DynamicalLoadingMode.Year);
            scheduler.Views.Clear();
            var year = new YearView();
            scheduler.Views.Add(year);
            scheduler.InitialView = year.Name;
            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
            ViewBag.calendrier = scheduler;

            return View(scheduler);
        }
        public ContentResult Data()
        {
            
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/rest/holidays").Result;
            if (response.IsSuccessStatusCode)
            {
                liste = response.Content.ReadAsAsync<List<HolidayVM>>().Result;
            }
            return new SchedulerAjaxData(liste);
        }

        public ActionResult Save(int? id, FormCollection actionValues)
        {

            var action = new DataAction(actionValues);
            try
            {
                var changedEvent = DHXEventsHelper.Bind<HolidayVM>(actionValues);
                holiday h = new holiday { holidayId = changedEvent.holidayId,
                    startDate = changedEvent.startDate, endDate = changedEvent.endDate, name = changedEvent.name };
                switch (action.Type)
                {

                    case DataActionTypes.Insert:
                        hs.Add(h);
                        hs.Commit();
                        break;
                    case DataActionTypes.Delete:
                        hs.Delete(holiday => holiday.holidayId == changedEvent.holidayId);
                        hs.Commit();
                        break;
                    case DataActionTypes.Update:
                        hs.Update(h);
                        hs.Commit();
                        break;
                    default:
                        break;
                }
                action.TargetId = changedEvent.holidayId;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }
        protected override void Dispose(bool disposing)
        {
        }

    }
}
