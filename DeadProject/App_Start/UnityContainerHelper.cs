using DeadEntity.IRepository;
using UnityOfWorck.Repositorys;
using DeadProject.Models;
using Microsoft.Practices.Unity;
using System.Configuration;
using System.Data.Entity;

namespace DeadProject.App_Start
{
    public class UnityContainerHelper
    {
        public static IUnityContainer InitUnityContainer()
        {
            UnityContainer container = new UnityContainer();
            string connectionStrings = ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();

            container.RegisterType<DbContext, AppDbContext>("", new InjectionConstructor(connectionStrings));

            container.RegisterType<IUserRepository , UserRepository>();

            return container;
        }
    }
}