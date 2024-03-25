using eUseControl.BuisnessLogic.DBContext.User;
using eUseControl.Domain.Entities.Response;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.DBModel;
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
                var user = db.User.FirstOrDefault(u => u.UserName == data.Credential);
            };


            return new ULoginResp
            {
                Status = false,
                CurrentUser = new User
                {
                    UserName = "Cristi"  
                }
            };
        }
    }
}
