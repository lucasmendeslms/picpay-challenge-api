using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Domain.Common;

namespace PicPayChallenge.Application.Interfaces.Services;

public interface ICustomerService
{
    Task<Result> RegisterAsync(RegisterCustomerRequest customerDto);
}