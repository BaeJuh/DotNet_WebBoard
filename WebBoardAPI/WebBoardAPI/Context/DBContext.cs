using Microsoft.EntityFrameworkCore;

namespace WebBoardAPI.Context
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        
        public DbSet<Entities.Article> Articles { get; set; }
        public DbSet<Entities.Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entities.Article>()
                .HasMany(a => a.Comments)
                .WithOne();
        }
    }
}
