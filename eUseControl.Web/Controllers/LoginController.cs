using eUseControl.BuisnessLogic.Interfaces;
using eUseControl.Domain.Entities.Response;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Attributes;
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
            if(ModelState.IsValid)
            {
                var uData = new ULoginData
                {
                    Credential = data.Credential,
                    Password = data.Password,
                    Ip = Request.UserHostAddress,
                    LoginTime = DateTime.Now
                };

                ULoginResp resp = _session.UserLoginAction(uData);

                if(resp.Status)
                {
                    // Cookie
                    HttpCookie cookie = _session.GenCookie(data.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    var profile = _session.GetUserByCookie(cookie.Value);
                    if (profile != null)
                    {
                        if (profile.Level == Domain.Enums.UserRole.Admin)
                        {
                            return RedirectToAction("Index", "Menu");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User profile not found.");
                        return View(data);
                    }
                }
                else
                {
                    ModelState.AddModelError("", resp.StatusMsg);
                    return View(data);
                }
            }

            return View(data);
        }
    }
}