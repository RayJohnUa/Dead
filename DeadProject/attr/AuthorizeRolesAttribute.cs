using DeadEntity;
using DeadEntity.IRepository;
using DeadProject.Models;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using UnityOfWorck.Repositorys;

namespace DeadProject.attr
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private static IUserRepository _reposetory = new UserRepository(new AppDbContext("AppDbContext"));
        public new Roles Roles;  // new keyword will hide base class Roles Property
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
                return false;
            Roles role = _reposetory.GetbyToken(httpContext.User.Identity.Name).Roles;
            if (Roles != role)
                return false;
            return true;
        }
    }
}