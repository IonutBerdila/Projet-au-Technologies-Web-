using eUseControl.BuisnessLogic.DBContext.User;
using eUseControl.Domain.Entities.Response;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.DBModel;
using eUseControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BuisnessLogic.Core
{
    public class UserAPI
    {
        internal ULoginResp RLoginUpService(ULoginData data)
        {
            
            using(var db = new UserContext())
            {
                var user = db.User.FirstOrDefault(u => u.Name == data.Credential);
            };

            return new ULoginResp
            {
                Status = false,
                CurrentUser = new User
                {
                    Name = "Cristi"
                }
            };
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
    }
}
