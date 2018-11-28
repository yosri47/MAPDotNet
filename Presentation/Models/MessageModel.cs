using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class MessageModel
    {
        public int messageId { get; set; }
        public string content { get; set; }
        public string _object { get; set; }
        public int to;
        public string type { get; set; }
        public DateTime dateSend { get; set; }
        public int rs { get; set; }
        public UserModel adminsend { get; set; }

        public ClientModel clrecu { get; set; }

        public ClientModel clsend { get; set; }

        public RessourceModel rsrecu { get; set; }

        public RessourceModel rssend { get; set; }


    }
}