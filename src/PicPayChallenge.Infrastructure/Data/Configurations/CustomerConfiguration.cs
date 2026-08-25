using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.Constants;
using PicPayChallenge.Domain.ValueObjects;

namespace PicPayChallenge.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{    
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.FirstName)
            .HasMaxLength(Customer.MaxFirstNameLength)
            .IsRequired();

        builder.Property(c => c.LastName).
            HasMaxLength(Customer.MaxLastNameLength)
            .IsRequired();

        builder.Property(c => c.Username)
            .HasMaxLength(User.MaxUsernameLength)
            .IsRequired();

        builder.Property(c => c.Cpf)
            .HasConversion(
                cpf => cpf.Value,
                value => new Cpf(value)
            )
            .HasMaxLength(Cpf.CpfDigitsLength)
            .IsFixedLength()
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(User.MaxEmailLength)
            .IsRequired();

        builder.Property(c => c.PasswordHash)
            .HasMaxLength(CustomerConstants.MAX_STRING_LENGTH)
            .IsRequired();

        builder.Property(c => c.PasswordSalt)
            .HasMaxLength(CustomerConstants.MAX_STRING_LENGTH)
            .IsRequired();

        builder.HasIndex(c => c.Username).IsUnique();
        builder.HasIndex(c => c.Email).IsUnique();
        builder.HasIndex(c => c.Cpf).IsUnique();
    }
}