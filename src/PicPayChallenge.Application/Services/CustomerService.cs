using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Application.Interfaces.Services;
using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Domain.Common;
using PicPayChallenge.Domain.ValueObjects;
using PicPayChallenge.Application.Interfaces.Common;

namespace PicPayChallenge.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IAccountService _accountService;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IAccountService accountService, IUnitOfWork unitOfWork)
    {
        _accountService = accountService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> RegisterAsync(RegisterCustomerRequest customerDto)
    {

       var customer = new Customer
       {
           FirstName = customerDto.FirstName,
           LastName = customerDto.LastName,
           Username = customerDto.Username,
           Cpf = new Cpf(customerDto.Cpf),
           Email = customerDto.Email,
           Cep = customerDto.Cep
       };

        customer.SetPassword(customerDto.Password);

        var createAccountResult = await _accountService.CreateAccountAsync(customer.Id);

        if (createAccountResult.IsFailure)
        {
            Result.Failure(Domain.Error.None);    
        }

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }


}