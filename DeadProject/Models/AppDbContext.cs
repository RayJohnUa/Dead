using DeadEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeadProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(string connection)
			: base(connection)
		{
            Database.SetInitializer<AppDbContext>(new DropCreateDatabaseIfModelChanges<AppDbContext>());
        }

        public virtual DbSet<UserEntity> Users { get; set; }
    }
}