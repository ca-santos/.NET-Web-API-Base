using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMaker.Domain.Features.Genres;

namespace MovieMaker.Infra.Data.Features.Genres
{
    public class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {

        public void Configure(EntityTypeBuilder<Genre> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.CreatedAt);
            builder.Property(e => e.Active).HasDefaultValue(false);

            builder.HasMany(e => e.Movies)
                .WithOne(f => f.Genre)
                .OnDelete(DeleteBehavior.SetNull);

        }

    }
}
