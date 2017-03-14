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
        private static IUserRepository _reposetory = null;

        public new Roles Roles;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (_reposetory == null)
                _reposetory = new UserRepository(new AppDbContext("AppDbContext"));
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