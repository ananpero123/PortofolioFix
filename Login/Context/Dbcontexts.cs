using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Context
{
    public class Dbcontexts : DbContext
    {
        public Dbcontexts(DbContextOptions<Dbcontexts> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Porto> Porto { get; set; }

        public DbSet<Portofolio> Portofolio { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Porto>().ToTable("Portol");
            modelBuilder.Entity<Portofolio>().ToTable("Portofolio");
        }
    }
}
