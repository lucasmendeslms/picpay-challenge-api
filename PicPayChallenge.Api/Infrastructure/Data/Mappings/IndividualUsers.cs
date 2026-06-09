using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallenge.Api.Config.Constants;
using PicPayChallenge.Api.Model.Entities;

namespace PicPayChallenge.Api.Config.Database.Tables;

public class IndividualUsers : IEntityTypeConfiguration<IndividualUser>
{
    private const int CpfLength = 11;
    
    public void Configure(EntityTypeBuilder<IndividualUser> builder)
    {
        builder.ToTable("IndividualUsers");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.FirstName).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();
        builder.Property(p => p.Cpf).HasMaxLength(CpfLength).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();
        builder.Property(p => p.PasswordHash).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();
        builder.Property(p => p.PasswordSalt).HasMaxLength(DatabaseConstants.MaxStringLength).IsRequired();

        builder.HasIndex(p => p.Email).IsUnique();
        builder.HasIndex(p => p.Cpf).IsUnique();
    }
}