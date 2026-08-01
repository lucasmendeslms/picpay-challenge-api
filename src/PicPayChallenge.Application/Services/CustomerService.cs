using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Application.Services.Interfaces;
using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Domain.Common;

namespace PicPayChallenge.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IAccountService _accountService;

    public CustomerService(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<Result<RegisterCustomerResponse>> RegisterAsync(RegisterCustomerRequest customerDto)
    {

       var customer = new Customer
       {
           FirstName = customerDto.FirstName,
           LastName = customerDto.LastName,
           Username = customerDto.Username,
           Cpf = customerDto.Cpf,
           Email = customerDto.Email,
           Cep = customerDto.Cep
       };

        customer.SetPassword(customerDto.Password);

        var account = _accountService.CreateAccountAsync(customer.Id);

        return Result.Success();
    }


}