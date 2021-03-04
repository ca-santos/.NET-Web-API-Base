using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMaker.Domain.Features.Movies;

namespace MovieMaker.Infra.Data.Features.Movies
{
    public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
    {

        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
            builder.Property(e => e.CreatedAt);
            builder.Property(e => e.Active).HasDefaultValue(false);
            builder.Property(e => e.GenreId);
            builder.HasOne(e => e.Genre);

        }

    }
}
