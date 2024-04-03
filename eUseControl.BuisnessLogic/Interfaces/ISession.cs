
using eUseControl.Domain.Entities.Response;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BuisnessLogic.Interfaces
{
    public interface ISession
    {
        URegisterResp RegisterNewUserAction(URegisterData regData);
        ULoginResp UserLoginAction(ULoginData data);
    }
}
