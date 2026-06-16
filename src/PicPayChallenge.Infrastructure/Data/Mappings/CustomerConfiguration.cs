using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallenge.Infrastructure.Config.Constants;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Infrastructure.Data.Mappings;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{    
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.PublicId).HasDefaultValueSql("NEXT VALUE FOR UserPublicIdSequence").IsRequired();
        builder.Property(p => p.FirstName).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(p => p.Cpf).HasMaxLength(DatabaseConstants.CPF_LENGTH).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(p => p.PasswordHash).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(p => p.PasswordSalt).HasMaxLength(DatabaseConstants.MAX_STRING_LENGTH).IsRequired();

        builder.HasIndex(p => p.PublicId).IsUnique();
        builder.HasIndex(p => p.Email).IsUnique();
        builder.HasIndex(p => p.Cpf).IsUnique();
    }
}