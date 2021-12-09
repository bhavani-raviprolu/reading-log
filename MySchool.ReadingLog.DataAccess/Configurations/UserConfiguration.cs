using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.ReadingLog.Domain;

namespace MySchool.ReadingLog.DataAccess.Configurations
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public UserConfiguration() : base("Users")
        {
        }

        protected override void AdditionalConfiguration(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(30);
            builder.Property(c => c.EmailAddress).IsRequired().HasMaxLength(30);
            builder.Property(c => c.Role).IsRequired();
            builder.HasMany(c => c.Students);
        }
    }
}