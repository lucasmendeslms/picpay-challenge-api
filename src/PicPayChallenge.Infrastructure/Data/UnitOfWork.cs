using PicPayChallenge.Application.Interfaces.Common;
using PicPayChallenge.Domain.Common;

namespace PicPayChallenge.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private const int NoRowsAffected = 0;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> SaveChangesAsync() {
        
        var rowsAffected = await _context.SaveChangesAsync();

        return rowsAffected > NoRowsAffected ? Result.Success() : Result.Failure(Domain.Error.None);
    }
}