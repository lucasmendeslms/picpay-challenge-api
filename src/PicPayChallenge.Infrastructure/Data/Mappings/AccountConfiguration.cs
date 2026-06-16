using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Infrastructure.Config.Constants;

namespace PicPayChalleng.Infrastructure.Data.Mappings;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.Agency)
            .HasDefaultValue(DatabaseConstants.DEFAULT_AGENCY_DIGITS)
            .HasMaxLength(DatabaseConstants.MAX_AGENCY_DIGITS)
            .IsRequired();
    }
}