using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallenge.Api.Infrastructure.Config.Constants;
using PicPayChallenge.Api.Domain.Entities;

namespace PicPayChallenge.Api.Infrastructure.Data.Mappings;

public class CompanyUsers : IEntityTypeConfiguration<CompanyUser>
{
    private const int CnpjLength = 14;
    
    public void Configure(EntityTypeBuilder<CompanyUser> builder)
    {
        builder.ToTable("CompanyUsers");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Cnpj).HasMaxLength(CnpjLength).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();      
        builder.Property(p => p.CorporateName).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();
        builder.Property(p => p.TradeName).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();
        builder.Property(p => p.Cep).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();
        builder.Property(p => p.PasswordHash).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();
        builder.Property(p => p.PasswordSalt).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();
        
        builder.HasIndex(p => p.Cnpj).IsUnique();
        builder.HasIndex(p => p.Email).IsUnique();
    }
}