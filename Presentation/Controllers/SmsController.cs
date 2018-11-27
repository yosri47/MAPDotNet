using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
namespace Presentation.Controllers
{
    public class SmsController : TwilioController
    {
        public ActionResult SendSms()
        {
            var accountSid = "AC74ec3e970780cfb5b8dae585125f2f21";
            var authToken = "7c8bb8c522925c52ad29f6b32f682638";
            TwilioClient.Init(accountSid, authToken);
            var from = new PhoneNumber("+15005550006");
            var phoneNumber = new PhoneNumber("+21623313606");


            var message = MessageResource.Create(
            body: "Test pi 28/11/2018 Daou Habib",
            from: from,
            to: phoneNumber


            );
            return Content(message.Sid);
        }

    }
}