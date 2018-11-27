using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class ClientModel
    {
        public string clientAddress { get; set; }
        public string clientCategory { get; set; }

        public string clientLogo { get; set; }

        public string clientNote { get; set; }

        public string clientType { get; set; }
        public Decimal longitude { get; set; }
        public Decimal lattitude { get; set; }

        public int userId { get; set; }

        public virtual ICollection<MessageModel> message { get; set; }
        public virtual ICollection<MessageModel> message1 { get; set; }

        public virtual UserModel user { get; set; }


    }
}