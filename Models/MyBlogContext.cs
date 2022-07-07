using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace razorweb.models
{
    public class MyBlogContext : IdentityDbContext<AppUser>
    {
        public MyBlogContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = item.GetTableName();
                if (tableName.StartsWith("AspNet"))
                    item.SetTableName(tableName.Substring(6));
            }
        }

        public DbSet<Article> articles { get; set; }
    }

}