﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Data;
using System.Data.Entity;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using DHTMLX.Common;
using reCAPTCHA.MVC;
using AHA.Models;

namespace AHA_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Programs()
        {

            return View();
        }

        public ActionResult Students()
        {

            return View();
        }

        public ActionResult GetInvolved()
        {

            return View();
        }

        public ActionResult Sponsors()
        {

            return View();
        }

        public ActionResult StudentOfMonth()
        {

            return View();
        }
        public ActionResult MentoringEnrichment()
        {
            return View();
        }
        public ActionResult CollegeReadiness() { return View(); }
        public ActionResult AST() { return View(); }
        public ActionResult ParentInvolvement() { return View(); }
        public ActionResult Ambassadors() { return View(); }
        public ActionResult TJXScholarship() { return View(); }
        public ActionResult BAM() { return View(); }

        [HttpPost]
      /*  [CaptchaValidator(
PrivateKey = "6Lcd6wcUAAAAALyfSPaS1UOZADXj6eDcFNCgqcUa",
ErrorMessage = "Invalid input captcha.",
RequiredMessage = "The captcha field is required.")] */
        public ActionResult Contact(MailViewModel Model)
        {
            //For help on setting up the captcha visit the link below and refer to the "Quick Start" guide.
            //http://recaptchamvc.apphb.com/


            //To get your site and private keys for the captcha, visit the link below.
            // https://www.google.com/recaptcha/intro/index.html


            //Below is how to set up a contact form for GMAIL ONLY!.

            //If you receive an error on Line smtp.Send(mail) then you might need to log into that Gmail 
            //account you are trying to send the emails from and find the option to "Enable Less Secure Apps"
            //Google is being nice and disabling the Gmail account to be accessed by less secure applications.

            //See the referenced code for explanation of this example.
            //http://www.c-sharpcorner.com/uploadfile/sourabh_mishra1/sending-an-e-mail-using-asp-net-mvc/
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("ahawebconfig@gmail.com");
                Model.Email = mail.From.Address;
                Model.Name = mail.From.DisplayName;
                mail.Subject = Model.Subject;
                string Body = Model.Messge;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("AHAWebConfig@gmail.com", "ahawebconfig123"); // ("user", "pass");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("ThankYou"); // TODO: make thank you page
            }
            else
            {
                return View("Error"); //TODO: make error page
            }

        }
    }
}