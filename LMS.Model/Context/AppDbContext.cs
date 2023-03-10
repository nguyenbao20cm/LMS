
using LMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace LMS.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}
        public DbSet<Account> TaiKhoan { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(builder =>
            {
                builder.ToTable(nameof(TaiKhoan));
                builder.HasKey(x => x.TaiKhoanId);
            });
        }
    }
}
