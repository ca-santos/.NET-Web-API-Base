using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMaker.Domain.Features.Rentals;

namespace MovieMaker.Infra.Data.Features.Rentals
{
    public class RentalEntityConfiguration : IEntityTypeConfiguration<Rental>
    {

        public void Configure(EntityTypeBuilder<Rental> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.CustomerCPF).HasMaxLength(14).IsRequired();
            builder.Property(e => e.RentedAt).IsRequired();

            builder.HasMany(e => e.Movies)
                .WithOne(f => f.ActiveRental)
                .OnDelete(DeleteBehavior.SetNull);            

        }

    }
}
