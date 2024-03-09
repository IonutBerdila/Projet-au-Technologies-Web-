using eUseControl.BuisnessLogic.Interfaces;
using eUseControl.Domain.Entities.Response;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly ISession _session;
        public LoginController()
        {
            var bl = new BuisnessLogic.BuisnessLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Post: Login
        [HttpPost]
        public ActionResult Index(UserLogin data)
        {
            var uData = new ULoginData
            { 
                Credential = data.Credential,
                Password = data.Password,
                Ip = "0.0.0.0",
                LoginTime = DateTime.Now
            };

            ULoginResp resp = _session.UserLoginAction(uData);

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}