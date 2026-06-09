using PicPayChallenge.Api.Model.Entities;

namespace PicPayChallenge.Api.Services.Interfaces;

public interface IUserService
{
    Task<bool> RegisterUserAsync(IndividualUser individualUser);
    Task<bool> RegisterUserAsync(CompanyUser companyUser);
    
}