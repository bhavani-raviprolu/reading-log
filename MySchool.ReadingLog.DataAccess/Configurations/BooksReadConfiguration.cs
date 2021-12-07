using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.ReadingLog.Domain;

namespace MySchool.ReadingLog.DataAccess.Configurations
{
    public class BooksReadConfiguration : BaseEntityConfiguration<BookRead>
    {
        public BooksReadConfiguration() : base("BooksRead")
        {
        }

        protected override void AdditionalConfiguration(EntityTypeBuilder<BookRead> builder)
        {
            builder.Property(x => x.BookId)
                   .HasColumnName("BookId")
                   .IsRequired();

            builder.Property(x => x.StudentId)
                    .HasColumnName("StudentId")
                    .IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.BooksRead)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Book)
                  .WithMany(x => x.BooksRead)
                  .HasForeignKey(x => x.BookId);
        }
    }
}