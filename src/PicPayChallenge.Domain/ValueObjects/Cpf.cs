namespace PicPayChallenge.Domain.ValueObjects;

public record Cpf
{
    public string Value { get; init; }

    public Cpf(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !ValidateCpf(value))
        {
            throw new ArgumentException("Invalid document.");
        }

        Value = value.Replace(".", "").Replace("-", "");
    }

    private static bool ValidateCpf(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11 || new string(cpf[0], 11) == cpf)
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

        var remainder = sum % 11;
        var digit1 = remainder < 2 ? 0 : 11 - remainder;

        tempCpf += digit1;
        sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += int.Parse(tempCpf[i].ToString()) * multipliers2[i];
        }

        remainder = sum % 11;
        var digit2 = remainder < 2 ? 0 : 11 - remainder;

        return cpf.EndsWith(digit1.ToString() + digit2.ToString());
    }
}