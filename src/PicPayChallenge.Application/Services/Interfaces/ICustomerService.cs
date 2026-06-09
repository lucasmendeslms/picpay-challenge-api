using PicPayChallenge.Application.DTOs.Customer;

namespace PicPayChallenge.Application.Services.Interfaces;

public interface ICustomerService
{
    Task<bool> RegisterAsync(RegisterCustomerDto customerDto);
    
}