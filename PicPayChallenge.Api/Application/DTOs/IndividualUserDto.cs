using System.ComponentModel.DataAnnotations;

namespace PicPayChallenge.Api.Model.DTOs;

public class IndividualUserDto(string name, string cpf, string email, string password)
{
    [Required]
    public string Name { get; set; } = name;
    
    [Required]
    [StringLength(11, MinimumLength = 11, ErrorMessage =  "CPF invalid")]
    [RegularExpression(@"^\d{11}$")]
    public string Cpf { get; set; } = cpf;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = email;
    
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = password;
}