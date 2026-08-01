using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Domain.Common;

namespace PicPayChallenge.Application.Services.Interfaces;

public interface ICustomerService
{
    Task<Result<RegisterCustomerResponse>> RegisterAsync(RegisterCustomerRequest customerDto);
}