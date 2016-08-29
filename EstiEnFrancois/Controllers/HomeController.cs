using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Web.Mvc;
using EstiEnFrancois.Common;
using EstiEnFrancois.Models;
using Newtonsoft.Json;

namespace EstiEnFrancois.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index(bool success = false)
        {
            ViewBag.Title = "Esti en Francois";

            var slideshowUrls =
                Directory.GetFiles(Server.MapPath("~/Content/Images/Slideshow"), "*.jpg")
                    .Select(x => string.Format("~/Content/Images/Slideshow/{0}", Path.GetFileName(x)))
                    .ToList();
             
            slideshowUrls.Shuffle();
            
            var model = new Home
            {
                SlideshowImageUrls = slideshowUrls,
                RsvpModel = new RsvpModel() { Sent = success }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Rsvp(RsvpModel model)
        {
            var response = Request.Form["g-Recaptcha-Response"];

            if (!ModelState.IsValid || string.IsNullOrEmpty(response))
            {
                return RedirectToAction("Index");
            }

            ReCaptchaClass recaptchaResult;
            using (var client = new WebClient())
            {
                var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", ConfigurationManager.AppSettings["ReCaptchaSecretKey"], response));

                recaptchaResult = JsonConvert.DeserializeObject<ReCaptchaClass>(reply);
            }

            if (recaptchaResult.Success.ToLower() == "true")
            {
                SendMail(model);
                return RedirectToAction("Index", new { success = true });
            }

            return RedirectToAction("Index");
        }

        public class ReCaptchaClass
        {
            [JsonProperty("success")]
            public string Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }

        private void SendMail(RsvpModel model)
        {
            var u = Cryptography.Decrypt("Z69AeMNeFqwnNWMBjvWre6HgQUK3wfeabPVQAfwfh/A=", ConfigurationManager.AppSettings["ReCaptchaSecretKey"]);
            var p = Cryptography.Decrypt("4ow1fJbCsY0gQ15BMIsi8v7aE4T05TT6Gu/LkcFoBB0=", ConfigurationManager.AppSettings["ReCaptchaSecretKey"]);

            using (var smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"], 587))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(u, p);
                
                var from = new MailAddress(u, model.Names);
                var to = new MailAddress(ConfigurationManager.AppSettings["ToAddress"]);

                var message = new MailMessage(from, to)
                {
                    Body = string.Format("RSVP \r\nNaam: {0}\r\nEpos: {1} \r\nTel Nr: {2}\r\n", model.Names, model.Email, model.TelNumber),
                    Subject = "RSVP:" + model.Names,
                    IsBodyHtml = false
                };

                smtpClient.Send(message);
            }
        }
	}
}