using PicPayChallenge.Api.Config.Database;
using PicPayChallenge.Api.Model.DTOs;
using PicPayChallenge.Api.Domain.Entities;

namespace PicPayChallenge.Api.Domain.Interfaces;

public interface IUserRepository
{
   Task<int> CreateIndividualUserAsync(IndividualUserDto user);
   Task<int> CreateCompanyUserAsync(CompanyUserDto user);
}