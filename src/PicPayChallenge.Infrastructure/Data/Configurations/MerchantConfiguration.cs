using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.ValueObjects;

namespace PicPayChallenge.Infrastructure.Data.Configurations;

public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
{    
    public void Configure(EntityTypeBuilder<Merchant> builder)
    {
        builder.ToTable("Merchants");
        builder.HasKey(m => m.Id);
        builder.Property(p => p.Cnpj).HasMaxLength(Cnpj.MaxLength).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(User.MaxEmailLength).IsRequired();      
        builder.Property(p => p.CorporateName).HasMaxLength(Merchant.MaxCorporateNameLength).IsRequired();
        builder.Property(p => p.TradeName).HasMaxLength(Merchant.MaxTradeNameLength).IsRequired();
        builder.Property(p => p.Cep)
            .HasConversion(
                cep => cep.Value,
                cep => Cep.Create(cep)
            )
            .HasMaxLength(Cep.MaxLength).IsRequired();
        builder.Property(p => p.PasswordHash).HasMaxLength(User.MaxPasswordHashLength).IsRequired();
        builder.Property(p => p.PasswordSalt).HasMaxLength(User.MaxPasswordSaltLength).IsRequired();
        
        builder.HasIndex(p => p.Cnpj).IsUnique();
        builder.HasIndex(p => p.Email).IsUnique();
    }
}