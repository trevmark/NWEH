using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Services;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;

        public HomeController(IMailService mail)
        {
            _mail = mail;
        }

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contactModel)
        {
            var msg = string.Format("Comment from: {1}{0}Email: {2}{0})", Environment.NewLine,
                contactModel.name,
                contactModel.email
          );
          
           if( _mail.SendMail("trevor.nicholas@nweh.co.uk", "trevor.nicholas@nweh.co.uk","Party",msg))
            {
                ViewBag.MailSent = true;
            }
           return View();
           
        }
    }
}