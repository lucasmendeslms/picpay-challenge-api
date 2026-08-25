using PicPayChallenge.Application.Interfaces.Repositories;
using PicPayChallenge.Application.Interfaces.Services;
using PicPayChallenge.Domain.Common;
using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Application.Services;

public class AccountService : IAccountService
{
    private readonly ILedgerService _ledgerService;
    private readonly IAccountRepository _accountRepository;
    
    public AccountService(IAccountRepository accountRepository, ILedgerService ledgerService)
    {
        _accountRepository = accountRepository;
        _ledgerService = ledgerService;
    }

    public async Task<Result> CreateAccountAsync(Guid userId)
    {
        var account = new Account(userId);

        var addAccountResult = await _accountRepository.AddAccountAsync(account);
        var createLedgerResult = await _ledgerService.CreateLedgerAsync(account.Id);

        if (addAccountResult.IsFailure || createLedgerResult.IsFailure)
        {
            return Result.Failure(Domain.Error.None);
        }

        return Result.Success();
    }
}