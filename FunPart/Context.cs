using Microsoft.EntityFrameworkCore;
using FunPart.Entities;

namespace FunPart
{
    public class Context : DbContext
    {
        public DbSet<Users> Users => Set<Users>();
        public DbSet<Tasks> Tasks => Set<Tasks>();
        public DbSet<TaskCategories> taskCategories => Set<TaskCategories>();

        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) 
        {
            //Database.EnsureDeletedAsync();
            //Database.EnsureCreatedAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");
                
                entity.HasKey(x => x.Nickname).HasName("PK_dbo.Users");

                entity.HasMany(x => x.Tasks).WithOne(x => x.User).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TaskCategories>(entity =>
            {
                entity.ToTable("TaskCategories");

                entity.HasKey(x => x.Nickname).HasName("PK_dbo.TaskCategories");

                entity.HasMany(x => x.Tasks).WithOne(x => x.TaskCategory).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("Tasks");

                entity.HasKey(x => x.Id).HasName("PK_dbo.Tasks");

                entity.HasOne(x => x.TaskCategory).WithMany(x => x.Tasks).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.User).WithMany(x => x.Tasks).OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
