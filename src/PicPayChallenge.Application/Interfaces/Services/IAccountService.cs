using PicPayChallenge.Domain.Common;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Application.Interfaces.Services;

public interface IAccountService
{
    Task<Result> CreateAccountAsync(Guid userId);
}