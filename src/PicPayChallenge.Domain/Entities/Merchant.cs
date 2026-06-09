using PicPayChallenge.Domain.Exceptions;

namespace PicPayChallenge.Domain.Entities;

public class Merchant : User
{
    public string Cnpj { get; private set; }
    public string CorporateName { get; set; }
    public string TradeName { get; set; }

    public Merchant(string cnpj, string corporateName, string tradeName)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
        {
            throw new DomainException($"{nameof(cnpj)} cannot be null or empty");
        }
        
        Cnpj = cnpj;
        CorporateName = corporateName;
        TradeName = tradeName;
    }
}