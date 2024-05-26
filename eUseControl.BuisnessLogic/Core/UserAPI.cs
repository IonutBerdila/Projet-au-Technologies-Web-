using eUseControl.BuisnessLogic.DBContext.User;
using eUseControl.Domain.Entities.Response;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.DBModel;
using eUseControl.Domain.Enums;
using eUseControl.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eUseControl.BuisnessLogic.Core
{
    public class UserAPI
    {
        internal ULoginResp RLoginUpService(ULoginData data)
        {
            User result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelper.HashGen(data.Password);

                using (var db = new UserContext())
                {
                    result = db.User.FirstOrDefault(u => u.Name == data.Credential);
                }
                if (result == null)
                {
                    return new ULoginResp
                    {
                        Status = false,
                        StatusMsg = "Error, Incorrect Credential"
                    };
                }
                using (var up = new UserContext())
                {
                    result.PrivateIp = data.Ip;
                    result.LastLogin = data.LoginTime;
                    up.Entry(result).State = EntityState.Modified;
                    up.SaveChanges();
                }
            }
            return new ULoginResp { Status = true };
        }
        internal URegisterResp RegisterUserAction(URegisterData regData)
        {
            var newUser = new User
            {
                Name = regData.Name,
                Email = regData.Email,
                Password = regData.Password,
                Level = UserRole.User
            };

            using (var db = new UserContext())
            {
                db.User.Add(newUser);
                db.SaveChanges();
            }



            return new URegisterResp();
        }

        internal HttpCookie Cookie(string Credential)
        {
            var apiCookie = new HttpCookie("tsud")
            {
                Value = CookieGenerator.Create(Credential)
            };

            using (var db = new UserContext())
            {
                SessionsDbTable curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(Credential))
                {
                    curent = (from e in db.Sessions where e.User == Credential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.User == Credential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var up = new UserContext())
                    {
                        up.Entry(curent).State = EntityState.Modified;
                        up.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new SessionsDbTable
                    {
                        User = Credential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }
            return apiCookie;
        }

        internal UProfileData UserCookie(string cookie)
        {
            SessionsDbTable session;
            User curentUser;

            using (var db = new UserContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.User))
                {
                    curentUser = db.User.FirstOrDefault(u => u.Email == session.User);
                }
                else
                {
                    curentUser = db.User.FirstOrDefault(u => u.Email == session.User);
                }
            }

            if (curentUser == null) return null;
            var userprofile = new UProfileData
            {
                Id = curentUser.Id,
                Name = curentUser.Name,
                Email = curentUser.Email,
                Level = curentUser.Level
            };

            return userprofile;
        }
    }
}
