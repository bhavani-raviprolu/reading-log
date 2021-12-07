using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.ReadingLog.Domain;

namespace MySchool.ReadingLog.DataAccess.Configurations
{
    public class BooksConfiguration : BaseEntityConfiguration<Book>
    {
        public BooksConfiguration() : base("Books")
        {
        }

        protected override void AdditionalConfiguration(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.BookName)
                     .HasColumnName("Name")
                     .IsRequired()
                     .HasMaxLength(30);
        }
    }
}