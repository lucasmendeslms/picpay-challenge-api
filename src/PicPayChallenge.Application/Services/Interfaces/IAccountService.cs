using PicPayChallenge.Domain.Common;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Application.Services.Interfaces;

public interface IAccountService
{
    Task<Result<Account>> CreateAccountAsync(Guid userId);
}