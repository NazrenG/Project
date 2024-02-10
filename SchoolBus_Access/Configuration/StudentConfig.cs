using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolBus_Model.Entities.Concretes;


namespace SchoolBus_Access.Configuration
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);

            builder.Property(x => x.Name).HasColumnName("FirstName")
                .HasColumnType("nvarchar(15)").IsRequired();

            builder.Property(x => x.LastName).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(x => x.HomeAddress).HasColumnType("nvarchar(15)").IsRequired();
        }
    }
}
