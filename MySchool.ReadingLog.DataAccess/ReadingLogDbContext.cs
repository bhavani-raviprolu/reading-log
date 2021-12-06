using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySchool.ReadingLog.DataAccess.Extensions;
using MySchool.ReadingLog.Domain;
using System.Linq;

namespace MySchool.ReadingLog.DataAccess
{
    public class ReadingLogDbContext : DbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public ReadingLogDbContext(DbContextOptions<ReadingLogDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRead> BooksRead { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.StudentName)
                      .HasColumnName("Name")
                      .IsRequired()
                      .HasMaxLength(30);
                entity.Property(x => x.Grade)
                      .HasColumnName("Grade")
                      .IsRequired()
                      .HasMaxLength(10);
                entity.Property(x => x.CreatedBy)
                      .HasColumnName("CreatedBy")
                      .IsRequired()
                      .HasMaxLength(30);
                entity.Property(x => x.CreatedDate)
                      .HasColumnName("CreatedDate")
                      .IsRequired();
                entity.Property(x => x.ModifiedBy)
                      .HasColumnName("ModifiedBy")
                      .HasMaxLength(30);
                entity.Property(x => x.ModifiedDate)
                      .HasColumnName("ModifiedDate");
            });
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.BookName)
                      .HasColumnName("Name")
                      .IsRequired()
                      .HasMaxLength(30);
                entity.Property(x => x.CreatedBy)
                      .HasColumnName("CreatedBy")
                      .IsRequired()
                      .HasMaxLength(30);
                entity.Property(x => x.CreatedDate)
                      .HasColumnName("CreatedDate")
                      .IsRequired();
                entity.Property(x => x.ModifiedBy)
                       .HasColumnName("ModifiedBy")
                       .HasMaxLength(30);
                entity.Property(x => x.ModifiedDate)
                      .HasColumnName("ModifiedDate");
            });
            modelBuilder.Entity<BookRead>(entity =>
            {
                entity.ToTable("BooksRead");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.BookId)
                       .HasColumnName("BookId")
                       .IsRequired();
                entity.Property(x => x.StudentId)
                      .HasColumnName("StudentId")
                      .IsRequired();
                entity.Property(x => x.DateRead)
                      .HasColumnName("DateRead")
                      .IsRequired();
                entity.Property(x => x.CreatedBy)
                      .HasColumnName("CreatedBy")
                      .IsRequired()
                      .HasMaxLength(30);
                entity.Property(x => x.CreatedDate)
                      .HasColumnName("CreatedDate")
                      .IsRequired();
                entity.Property(x => x.ModifiedBy)
                      .HasColumnName("ModifiedBy")
                      .HasMaxLength(30);
                entity.Property(x => x.ModifiedDate)
                      .HasColumnName("ModifiedDate");
                entity.HasOne(x => x.Student)
                      .WithMany(x => x.BooksRead)
                      .HasForeignKey(x => x.StudentId);
                entity.HasOne(x => x.Book)
                      .WithMany(x => x.BooksRead)
                      .HasForeignKey(x => x.BookId);
            });
        }


        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries().ToList();
            var addedEntries = entries.Where(c => c.State == EntityState.Added);
            var modifiedEntries = entries.Where(c => c.State == EntityState.Modified);
            var user = this.httpContextAccessor.GetEmail();
            foreach(var entry in addedEntries.OfType<BaseEntity>())
            {
                entry.CreatedBy = user;
                entry.CreatedDate = System.DateTime.Now;
            }

            foreach(var entry in modifiedEntries.OfType<BaseEntity>())
            {
                entry.ModifiedBy = user;
                entry.ModifiedDate = System.DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}