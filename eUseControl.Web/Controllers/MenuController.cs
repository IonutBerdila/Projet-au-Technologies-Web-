using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web.Attributes;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        [AdminMode]
        public ActionResult Index()
        {           
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}