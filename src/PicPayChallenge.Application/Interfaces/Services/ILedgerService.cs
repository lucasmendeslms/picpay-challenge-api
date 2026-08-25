using PicPayChallenge.Domain.Common;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Application.Interfaces.Services;

public interface ILedgerService
{
    Task<Result> CreateLedgerAsync(Guid accountId);
}