namespace PicPayChallenge.Domain.ValueObjects;

public record Cpf
{
    public const int CpfDigitsLength = 11;

    public string Value { get; init; }

    public Cpf(string value)
    {
        if (!IsValid(value))
        {
            throw new ArgumentException("Invalid document.");
        }

        Value = CleanCpf(value);
    }

    public static bool IsValid(string cpf)
    {

        if (string.IsNullOrWhiteSpace(cpf))
        {
            return false;    
        }

        cpf = CleanCpf(cpf);

        if (cpf.Length != CpfDigitsLength || new string(cpf[0], CpfDigitsLength) == cpf)
        {
            return false;
        }

        var multipliers1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multipliers2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        var tempCpf = cpf.Substring(0, 9);
        var sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(tempCpf[i].ToString()) * multipliers1[i];

        }

        var remainder = sum % CpfDigitsLength;
        var digit1 = remainder < 2 ? 0 : CpfDigitsLength - remainder;

        tempCpf += digit1;
        sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += int.Parse(tempCpf[i].ToString()) * multipliers2[i];
        }

        remainder = sum % CpfDigitsLength;
        var digit2 = remainder < 2 ? 0 : CpfDigitsLength - remainder;

        return cpf.EndsWith(digit1.ToString() + digit2.ToString());
    }

    private static string CleanCpf(string cpf) => cpf.Replace(".", "").Replace("-", "").Trim();
}