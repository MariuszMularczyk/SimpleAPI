
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleAPI
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasMany(x => x.Mails)
                .WithOne(x => x.Trip)
                .HasForeignKey(x => x.TripId);
        }
    }
}
