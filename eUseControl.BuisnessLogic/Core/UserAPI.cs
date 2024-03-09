using eUseControl.Domain.Entities.Response;
using eUseControl.Domain.Entities.User;
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
            //Step 1 - SELECT FROM DB>Users WHERE CREDENTIAL == data.Creadential AND
            //PASSWORD == data.Password

            //Step 2 - IF object != NULL 
            //CREATE SESSION

            //RETURN SESSION AND STATUS TRUE

            return new ULoginResp { Status = false };
        }
    }
}
