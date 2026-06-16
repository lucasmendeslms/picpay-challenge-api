using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Infrastructure.Config.Constants;
using PicPayChallenge.Infrastructure.Data;
using PicPayChallenge.Infrastructure.Repositories.Interfaces;

namespace PicPayChallenge.Infrastructure.Repositories;

public class CustomerRepository(ApplicationDbContext db) : ICustomerRepository
{
    public async Task AddAsync(Customer customer)
    {
        await db.Customers.AddAsync(customer);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await db.SaveChangesAsync() > DatabaseConstants.NoRowsAffected;
    }
}