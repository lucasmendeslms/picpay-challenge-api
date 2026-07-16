using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.Constants;

namespace PicPayChalleng.Infrastructure.Data.Mappings;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.Agency)
            .HasDefaultValue(AccountConstants.DEFAULT_AGENCY_DIGITS)
            .HasMaxLength(AccountConstants.MAX_AGENCY_DIGITS)
            .IsRequired();

        builder.Property(a => a.AccountNumber)
            .HasDefaultValueSql("NEXT VALUE FOR AccountNumberSequence")
            .IsRequired();

        builder.Property(a => a.Digit)
            .HasComputedColumnSql("dbo.CalculateAccountDigit([AccountNumber])")
            .IsRequired();
        
        builder.Property(a => a.Balance)
            .HasColumnType(AccountConstants.BALANCE_COLUMN_TYPE)
            .HasDefaultValue(AccountConstants.DEFAULT_INITIAL_BALANCE)
            .IsRequired();

        builder.HasOne<User>()
            .WithOne(u => u.Account)
            .HasForeignKey<Account>(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasIndex(a => a.AccountNumber).IsUnique();
    }
}