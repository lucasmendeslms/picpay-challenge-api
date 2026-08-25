using PicPayChallenge.Domain.Common;

namespace PicPayChallenge.Application.Interfaces.Common;

public interface IUnitOfWork
{
    Task<Result> SaveChangesAsync();
}