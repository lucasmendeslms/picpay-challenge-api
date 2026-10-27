using PicPayChallenge.Domain.Common;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Application.Interfaces.Repositories;

public interface ICustomerRepository
{
   Task AddAsync(Customer customer);
}