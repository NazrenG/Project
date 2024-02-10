using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Configuration
{
    public class AdminConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(x=>x.Id).UseIdentityColumn();
        }
    }
}
