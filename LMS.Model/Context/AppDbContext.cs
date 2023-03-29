
using LMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace LMS.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Account> TaiKhoan { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        //public DbSet<CT_TeachingSubject> CT_TeachingSubject { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<TeachingSubject> TeachingSubject { get; set; }
        public DbSet<DetailsSubject> DetailsSubject { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<TopicSubject> TopicSubject { get; set; }
        public DbSet<DetailsLesson> DetailsLesson { get; set; }
        public DbSet<StudentSubject> StudentSubject { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(builder =>
            {
                builder.ToTable(nameof(TaiKhoan));
                builder.HasKey(x => x.TaiKhoanId);
            });
            modelBuilder.Entity<ClassRoom>(builder =>
            {
                builder.ToTable(nameof(ClassRoom));
                builder.HasKey(x => x.ClassRoomId);
            });
            modelBuilder.Entity<Subject>(builder =>
            {
                builder.ToTable(nameof(Subject));
                builder.HasKey(x => x.SubjectId);
            });
            modelBuilder.Entity<TeachingSubject>(builder =>
            {
                builder.ToTable(nameof(TeachingSubject));
                builder.HasKey(x => x.TeachingSubjectId);
                builder
               .HasOne(x => x.Account)
               .WithMany(x => x.TeachingSubject)
               .HasForeignKey(x => x.AccountID);
                builder.HasOne(x => x.Subject)
               .WithMany(x => x.TeachingSubject).HasForeignKey(x => x.SubjectID);
                builder.HasOne(x => x.ClassRoom)
               .WithMany(x => x.TeachingSubject).HasForeignKey(x => x.ClassRoomID);
            });
            
        }
    }
}
