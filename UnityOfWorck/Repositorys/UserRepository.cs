using DeadEntity;
using DeadEntity.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityOfWorck.Repositorys
{
    public class UserRepository : Repository<UserEntity> , IUserRepository
    {
        public static readonly List<UserEntity> HashUserEntity = new List<UserEntity>();

        public UserRepository(DbContext context) : base(context)
        {

        }

        public bool CanUserPass(string token, Roles role)
        {
            UserEntity user = GetbyToken(token);
            if (user.Roles == role)
                return true;
            return false;
        }

        public void DeleteUserHash(string token)
        {
            UserEntity user = HashUserEntity.FirstOrDefault(u => u.Token == token);
            if (user != null)
                HashUserEntity.Remove(user);
        }

        public void Edit(UserEntity user)
        {
            UserEntity olduser = GetById(user.Id);
            if(olduser != null)
            {
                olduser.Email = user.Email;
                olduser.FirstName = user.FirstName;
                olduser.LastName = user.LastName;
                olduser.Password = user.Password;
            }
            Commit();
        }

        public UserEntity GetbyToken(string token)
        { 
            return HashUserEntity.FirstOrDefault(u => u.Token == token);
        }

        public UserEntity GetIdByEmail(string Email)
        {
            UserEntity user = HashUserEntity.FirstOrDefault(u => u.Email == Email);
            if (user == null) {
                user = DbSet.FirstOrDefault(u => u.Email == Email);
                if (user != null)
                    HashUserEntity.Add(user);
                return user;
            }
            return user;
        }

        public UserEntity GetUserbyMailandPassword(string email, string password)
        {
            UserEntity user = HashUserEntity.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                user = DbSet.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user != null)
                {
                    user.Token = Guid.NewGuid().ToString();
                    HashUserEntity.Add(user);
                }
                return user;
            }
            return user;
        }

        public bool IsEmailIsExist(string Email)
        {
            return DbSet.Any(n => n.Email == Email);
        }
    }
}
