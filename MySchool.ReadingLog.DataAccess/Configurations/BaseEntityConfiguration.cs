using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.ReadingLog.Domain;

namespace MySchool.ReadingLog.DataAccess.Configurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        private readonly string tableName;

        protected BaseEntityConfiguration(string tableName)
        {
            this.tableName = tableName;
        }

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(this.tableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedBy)
                     .HasColumnName("CreatedBy")
                     .IsRequired()
                     .HasMaxLength(30);
            builder.Property(x => x.CreatedDate)
                  .HasColumnName("CreatedDate")
                  .IsRequired();
            builder.Property(x => x.ModifiedBy)
                  .HasColumnName("ModifiedBy")
                  .HasMaxLength(30);
            builder.Property(x => x.ModifiedDate)
                  .HasColumnName("ModifiedDate");

            AdditionalConfiguration(builder);
        }

        protected abstract void AdditionalConfiguration(EntityTypeBuilder<T> builder);
    }
}