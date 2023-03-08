
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleAPI
{
    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder.HasOne(x => x.Trip)
                   .WithMany(x => x.Mails)
                   .HasForeignKey(x => x.TripId)
                   .IsRequired();
        }
    }
}
