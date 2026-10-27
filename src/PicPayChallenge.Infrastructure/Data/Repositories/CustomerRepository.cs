using PicPayChallenge.Application.Interfaces.Repositories;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Infrastructure.Data;

namespace PicPayChallenge.Infrastructure.Data.Repositories;

public class CustomerRepository(ApplicationDbContext db) : ICustomerRepository
{
    public async Task AddAsync(Customer customer)
    {
        await db.Customers.AddAsync(customer);
    }
}