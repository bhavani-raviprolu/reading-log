using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.ReadingLog.Domain;

namespace MySchool.ReadingLog.DataAccess.Configurations
{
    public class StudentConfiguration : BaseEntityConfiguration<Student>
    {
        public StudentConfiguration() : base("Students")
        {
        }

        protected override void AdditionalConfiguration(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.StudentName)
                      .HasColumnName("Name")
                      .IsRequired()
                      .HasMaxLength(30);
            builder.Property(x => x.Grade)
                      .HasColumnName("Grade")
                      .IsRequired()
                      .HasMaxLength(10);
        }
    }
}