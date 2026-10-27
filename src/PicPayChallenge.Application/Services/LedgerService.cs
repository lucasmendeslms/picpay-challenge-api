using PicPayChallenge.Application.Interfaces.Services;
using PicPayChallenge.Domain.Common;

namespace PicPayChallenge.Application.Services;

public class LedgerService : ILedgerService
{
    public async Task<Result> CreateLedgerAsync(Guid guid)
    {
        return Result.Success();
    }
}