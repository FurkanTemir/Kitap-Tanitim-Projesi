using KitapOneri.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KitapOneri.Data.Configuration.UserConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
        }
    }
}
