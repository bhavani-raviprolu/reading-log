using Microsoft.EntityFrameworkCore;
using MySchool.ReadingLog.Domain;

namespace MySchool.ReadingLog.DataAccess
{
    public class ReadingLogDbContext : DbContext
    {
        public ReadingLogDbContext(DbContextOptions<ReadingLogDbContext> options) : base(options)
        {
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
    }
}