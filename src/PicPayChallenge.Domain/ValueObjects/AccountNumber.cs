namespace PicPayChallenge.Domain.ValueObjects;

public record AccountNumber
{
    public string Number { get; private set; }
    public string Digit { get; private set; }

    public AccountNumber()
    {
        Number = GenerateAccountNumber();
        Digit = CalculateMod11Digit(Number);
    }

    public static bool IsValid(string number, string digit)
    {
        if(string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(digit))
        {
            return false;
        }

        if(digit != CalculateMod11Digit(number))
        {
          return false;  
        }

        return true;
    }

     public static string GenerateAccountNumber()
    {
        long timestampMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        string full = timestampMs.ToString();
        string basePart = full.Substring(full.Length - 8); // last 8 digits

        string checkDigit = CalculateMod11Digit(basePart);

        return $"{basePart}{checkDigit}";
    }

    private static string CalculateMod11Digit(string number)
    {
        int[] weights = [2, 3, 4, 5, 6, 7, 8, 9];
        int total = 0;

        char[] reversed = number.ToCharArray();
        Array.Reverse(reversed);

        for (int i = 0; i < reversed.Length; i++)
        {
            int digit = reversed[i] - '0';
            int weight = weights[i % weights.Length];
            total += digit * weight;
        }

        int remainder = total % 11;
        int checkDigit = 11 - remainder;

        if (checkDigit >= 10)
        {
            checkDigit = 0;
        }

        return checkDigit.ToString();
    }
}