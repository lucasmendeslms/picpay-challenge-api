namespace PicPayChallenge.Api.Model.DTOs;

public class UserRegisterDto(string name, string cpf, string email, string password)
{
    public string Name { get; set; } = name;
    public string Cpf { get; set; } = cpf;
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}