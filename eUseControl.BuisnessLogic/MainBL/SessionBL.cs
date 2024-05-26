using System.Web;
using eUseControl.BuisnessLogic.Core;
using eUseControl.BuisnessLogic.Interfaces;
using eUseControl.Domain.Entities.Response;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BuisnessLogic.MainBL
{
    public class SessionBL : UserAPI, ISession
    {
        public ULoginResp UserLoginAction(ULoginData data)
        {
            return RLoginUpService(data);
        }

        public URegisterResp RegisterNewUserAction(URegisterData regData)
        {
            return RegisterUserAction(regData);
        }

        public HttpCookie GenCookie(string data)
        {
            return Cookie(data);
        }
        public UProfileData GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}
