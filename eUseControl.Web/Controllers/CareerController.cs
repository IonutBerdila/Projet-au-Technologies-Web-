using Antlr.Runtime;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class CareerController : Controller
    {
        // GET: Career
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(Career model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ThankYou");
            }

            return View("Index", model);
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}