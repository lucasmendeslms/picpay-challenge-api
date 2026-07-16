using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.Constants;

namespace PicPayChallenge.Infrastructure.Data.Mappings;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{    
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.FirstName).HasMaxLength(CustomerConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(CustomerConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(c => c.Username).HasMaxLength(UserConstants.MAX_USERNAME_LENGTH).IsRequired();
        builder.Property(c => c.Cpf).HasMaxLength(CustomerConstants.CPF_LENGTH).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(CustomerConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(c => c.PasswordHash).HasMaxLength(CustomerConstants.MAX_STRING_LENGTH).IsRequired();
        builder.Property(c => c.PasswordSalt).HasMaxLength(CustomerConstants.MAX_STRING_LENGTH).IsRequired();

        builder.HasIndex(c => c.Username).IsUnique();
        builder.HasIndex(c => c.Email).IsUnique();
        builder.HasIndex(c => c.Cpf).IsUnique();
    }
}