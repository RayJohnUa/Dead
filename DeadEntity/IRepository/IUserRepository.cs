using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadEntity.IRepository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity GetUserbyMailandPassword(string email, string password);
        //void Add(UserEntity user);
        UserEntity GetIdByEmail(string Email);
        bool IsEmailIsExist(string Email);

        UserEntity GetbyToken(string token);

        void DeleteUserHash(string token);
    }
}
