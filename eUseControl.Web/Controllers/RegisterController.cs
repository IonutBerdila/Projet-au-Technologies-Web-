using eUseControl.BuisnessLogic.Interfaces;
using eUseControl.Domain.Entities.Response;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;
        public RegisterController()
        {
            var bl = new BuisnessLogic.BuisnessLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Register
        public ActionResult Index()
        {
            var regData = new URegisterData
            {
                Name = "Ionut",
                Email = "ionut123@gmail.com",
                Password = "Ionut123"
            };

            URegisterResp resp = _session.RegisterNewUserAction(regData);

            return View();
        }
    }
}