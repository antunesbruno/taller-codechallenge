using Microsoft.EntityFrameworkCore;
using Taller.CodeChallenge.Domain.Entities;
using Taller.CodeChallenge.Infrastructure.Repositories.Mappings;


namespace Taller.CodeChallenge.Infrastructure.Repositories.DbContext
{
    public class DbContextInMemory : Microsoft.EntityFrameworkCore.DbContext
    {      
        public DbContextInMemory(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
     
        /// <summary>
        /// We are using the database in memory for tests but i´ve implemented the option when we will
        /// user a sqlserver database considering the use of PKs and FK´s
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(new UserDbMap().Configure);

            base.OnModelCreating(modelBuilder);
        }      

        public DbSet<Users> Users { get; set; }
    }
}
