using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Application.Services.Interfaces;
using PicPayChallenge.Application.DTOs.Customer;

namespace PicPayChallenge.Application.Services;

public class CustomerService : ICustomerService
{

    public async Task<bool> RegisterAsync(RegisterCustomerDto customerDto)
    {
        return true;
    }


}