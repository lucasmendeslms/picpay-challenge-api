using PicPayChallenge.Api.Config.Database;
using PicPayChallenge.Api.Model.DTOs;

namespace PicPayChallenge.Api.Repositories;

public class UserRepository(ApplicationDbContext db) : IUserRepository
{
    private readonly ApplicationDbContext _db = db;

    public async Task<int> CreateIndividualUserAsync(IndividualUserDto user)
    {
        await _db.IndividualUsers.AddAsync(user);
        return await _db.SaveChangesAsync();
    }

    public async Task<int> CreateCompanyUserAsync(CompanyUserDto user)
    {
        
    }
}