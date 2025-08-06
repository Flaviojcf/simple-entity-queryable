using Microsoft.EntityFrameworkCore;
using Search.Entity;
using System.Reflection;

namespace Search.Repository
{
    namespace ToDo.API.Repository
    {
        public class TaskDbContext : DbContext
        {
            public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

            public DbSet<TaskEntity> Task { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
        }
    }

}
