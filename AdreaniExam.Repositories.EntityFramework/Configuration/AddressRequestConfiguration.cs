using AdreaniExam.Repositories.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdreaniExam.Repositories.EntityFramework.Configuration
{
    public class AddressRequestConfiguration : IEntityTypeConfiguration<AddressRequest>
    {
        public void Configure(EntityTypeBuilder<AddressRequest> builder)
        {
            builder.ToTable("AddressRequest");

            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Country).IsRequired();
            builder.Property(f => f.City).IsRequired();
            builder.Property(f => f.Country).IsRequired();
            builder.Property(f => f.Number).IsRequired();
            builder.Property(f => f.Street).IsRequired();
            builder.Property(f => f.ZipCode).IsRequired();
        }
    }
}
