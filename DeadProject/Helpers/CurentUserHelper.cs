using DeadEntity;
using DeadEntity.IRepository;
using DeadProject.Models;
using System.Web;
using UnityOfWorck.Repositorys;

namespace DeadProject.Helpers
{
    public static class CurentUserHelper
    {
        private static IUserRepository _reposetory = new UserRepository(new AppDbContext("AppDbContext"));

        public static string UserToken
        {
            get
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    return HttpContext.Current.User.Identity.Name;
                }
                return null;
            }
        }

        public static bool IsAutorize
        {
            get { return (!string.IsNullOrEmpty(UserToken)); }
        }

        public static UserEntity GetcurrentUser()
        {
            return _reposetory.GetbyToken(UserToken);
        }
    }
}