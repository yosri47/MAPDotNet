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
        public int holidayId { get; set; }
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }

        public string name { get; set; }
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }

        public String startDateEasy { get; set; }
        public String endDateEasy { get; set; }
        [DataType(DataType.Date)]

        public Calendar calendrier { get; set; }
        
        public HolidayVM()
        {
            calendrier = new Calendar();
        }
    }
}