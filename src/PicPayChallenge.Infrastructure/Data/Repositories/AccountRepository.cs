using PicPayChallenge.Application.Interfaces.Repositories;
using PicPayChallenge.Domain.Common;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Infrastructure.Data.Repositories;

public class AccountRepository : IAccountRepository
{
    public async Task<Result> AddAccountAsync(Account account)
    {
        return Result.Success();
    }
}