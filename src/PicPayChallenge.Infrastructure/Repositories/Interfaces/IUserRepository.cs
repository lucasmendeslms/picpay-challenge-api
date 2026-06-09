using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
   Task<int> CreateIndividualUserAsync(Customer user);
   Task<int> CreateCompanyUserAsync(Merchant user);
}