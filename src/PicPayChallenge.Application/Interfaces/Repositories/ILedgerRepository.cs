using PicPayChallenge.Domain.Common;

namespace PicPayChallenge.Application.Interfaces.Repositories;

public interface ILedgerRepository
{
    Task<Result> AddLedgerAsync();
}