using AdreaniExam.Repositories.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdreaniExam.Repositories.EntityFramework.Configuration
{
    public class AddressResultConfiguration : IEntityTypeConfiguration<AddressResult>
    {
        public void Configure(EntityTypeBuilder<AddressResult> builder)
        {
            builder.ToTable("AddressResult");

            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Latitude).IsRequired(false);
            builder.Property(f => f.Longitude).IsRequired(false);
            builder.Property(f => f.State).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();

            //builder.HasOne(f => f.AddressRequest)
            //    .WithOne(f => f.AddressResult)
            //    .HasForeignKey<AddressResult>(f => f.AddressRequestId)
            //    .HasPrincipalKey<AddressRequest>(f => f.Id)
            //    .IsRequired();
        }
    }
}
