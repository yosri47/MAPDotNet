using DHTMLX.Scheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Presentation.Models
{
    public class HolidayVM
    {
        [DHXJson(Alias = "id")]
        public int holidayId { get; set; }
   
        [DataType(DataType.Date)]
        [DHXJson(Alias = "end_date")]
        public DateTime endDate { get; set; }

        [DHXJson(Alias = "text")]
        public string name { get; set; }

        [DHXJson(Alias = "start_date")]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }
        
    }
}