using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Application.Services.Interfaces;
using PicPayChallenge.Application.DTOs.Customer;

namespace PicPayChallenge.Application.Services;

public class CustomerService : ICustomerService
{

    public async Task<bool> RegisterAsync(RegisterCustomerDto customerDto)
    {

       var customer = new Customer
       {
           FirstName = customerDto.FirstName,
           LastName = customerDto.LastName,
           Cpf = customerDto.Cpf,
           Email = customerDto.Email,
           Cep = customerDto.Cep,
       };

        customer.SetPassword(customerDto.Password);

        var account = new Account(customer.Id);

        return true;

    }


}