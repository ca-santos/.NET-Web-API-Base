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
            builder.Property(e => e.ActiveRentalId);

            builder.HasOne(e => e.Genre)
                .WithMany(f => f.Movies)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.ActiveRental)
                .WithMany(f => f.Movies)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

        }

    }
}
