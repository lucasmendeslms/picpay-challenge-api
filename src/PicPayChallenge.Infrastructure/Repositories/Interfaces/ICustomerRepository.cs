using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Infrastructure.Repositories.Interfaces;

public interface ICustomerRepository
{
   Task AddAsync(Customer customer);
   Task<bool> SaveChangesAsync();
}