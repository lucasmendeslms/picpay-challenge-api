using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.Constants;
using PicPayChallenge.Domain.ValueObjects;

namespace PicPayChalleng.Infrastructure.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(a => a.Id);

        // builder.OwnsOne
        
        builder.Property(a => a.Agency)
            .HasMaxLength(Account.MaxAgencyDigitsLength)
            .IsRequired();


        // builder.Property(a => a.Digit)
        //     .HasComputedColumnSql("dbo.CalculateAccountDigit([AccountNumber])")
        //     .IsRequired();
        
        builder.Property(a => a.Balance)
            .HasColumnType(Account.BalanceColumnType)
            .HasDefaultValue(Account.DefaultInitialBalance)
            .IsRequired();

        builder.HasOne<User>()
            .WithOne(u => u.Account)
            .HasForeignKey<Account>(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasIndex(a => a.AccountNumber).IsUnique();
    }
}