using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BuisnessLogic.DBContext.User
{
    public class UserContext : DbContext
    {
        public UserContext() : base ("name=eUseControl") { }

        public virtual DbSet<SessionsDbTable> Sessions { get; set; }

        public virtual DbSet<Domain.Entities.User.DBModel.User> User { get; set; }

    }
}
