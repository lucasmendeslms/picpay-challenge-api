using PicPayChallenge.Application.Services.Interfaces;
using PicPayChallenge.Domain.Common;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Application.Services;

public class AccountService : IAccountService
{
    public async Task<Result<Account>> CreateAccountAsync(Guid userId)
    {
        var account = new Account(userId);
    }
}