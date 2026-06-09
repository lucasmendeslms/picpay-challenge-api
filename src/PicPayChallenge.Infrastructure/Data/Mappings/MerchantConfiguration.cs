using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallenge.Infrastructure.Config.Constants;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Infrastructure.Data.Mappings;

public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
{    
    public void Configure(EntityTypeBuilder<Merchant> builder)
    {
        builder.ToTable("Merchants");
        builder.HasKey(m => m.Id);
        builder.Property(p => p.Cnpj).HasMaxLength(DatabaseConstants.CNPJ_LENGTH).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();      
        builder.Property(p => p.CorporateName).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(p => p.TradeName).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(p => p.Cep).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(p => p.PasswordHash).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(p => p.PasswordSalt).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();
        
        builder.HasIndex(p => p.Cnpj).IsUnique();
        builder.HasIndex(p => p.Email).IsUnique();
    }
}