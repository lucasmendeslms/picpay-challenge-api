using PicPayChallenge.Domain.Common;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Application.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<Result> AddAccountAsync(Account account);
}