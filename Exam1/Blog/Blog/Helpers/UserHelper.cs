using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Blog.Helpers
{
    public class UserHelper
    {
        public static string GetUserName(IDbSet<ApplicationUser> Users, IIdentity identity)
        {
            var user = Users.Where(u => u.Email == identity.Name).FirstOrDefault();
            return user.FullName;
        }
    }
}