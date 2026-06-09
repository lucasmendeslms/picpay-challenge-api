namespace PicPayChallenge.Api.Model.Entities;

public class CompanyUser : User
{
    public required string Cnpj { get; init; }
    public required string CorporateName { get; set; }
    public required string TradeName { get; set; }
}