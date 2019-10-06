using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.DB;

namespace DAL
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Computing> Computings { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Computing>().HasKey(i => i.Id);
            builder.Entity<Computing>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.Entity<ApplicationUser>()
            .HasMany(m => m.Computings)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);
        }

     }
}
