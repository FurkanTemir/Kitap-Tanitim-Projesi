using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KitapOneri.Data.Entities;

namespace KitapOneri.Data.Configuration.BookConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.BookName).IsRequired();
            builder.Property(x => x.BookDescription).IsRequired();
            builder.Property(x => x.BookImage).IsRequired();
            builder.Property(x => x.AuthorName).IsRequired();

        }
    }
}
