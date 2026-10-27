using System;
using System.Linq;

namespace PicPayChallenge.Domain.ValueObjects;

public readonly record struct AccountNumber
{
    // Structural constants
    public const int MaxLength = 8;
    public const int DigitLength = 1;

    // Algorithmic validation constants (Modulus 11 rules)
    private const int ModulusDivider = 11;
    private const int CheckDigitLimit = 10;
    private const int FallbackCheckDigit = 0;

    private static readonly int[] Mod11Weights = [2, 3, 4, 5, 6, 7, 8, 9];

    /// <summary>
    /// Gets the raw 8-digit account number.
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// Gets the calculated Mod-11 verification digit.
    /// </summary>
    public string Digit { get; }

    private AccountNumber(string number, string digit)
    {
        Number = number;
        Digit = digit;
    }

    /// <summary>
    /// Factory method to create a valid AccountNumber instance.
    /// </summary>
    public static AccountNumber Create(string number, string digit)
    {
        if (!TryParse(number, digit, out var accountNumber))
        {
            throw new ArgumentException("The provided account number or digit is invalid.", nameof(number));
        }

        return accountNumber;
    }

    /// <summary>
    /// Tries to parse and validate an account number and its verification digit.
    /// </summary>
    public static bool TryParse(string number, string digit, out AccountNumber accountNumber)
    {
        accountNumber = default;

        if (!IsValid(number, digit))
            return false;

        accountNumber = new AccountNumber(number, digit);
        return true;
    }

    /// <summary>
    /// Validates the account number and checks if the provided digit matches the Mod-11 calculation.
    /// </summary>
    public static bool IsValid(string number, string digit)
    {
        if (string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(digit))
        {
            return false;
        }

        if (number.Length != MaxLength || !number.All(char.IsDigit))
        {
            return false;
        }

        if (digit != CalculateMod11Digit(number))
        {
            return false;  
        }

        return true;
    }

    /// <summary>
    /// Generates a new account number using timestamp components and calculates its Mod-11 check digit.
    /// </summary>
    public static AccountNumber Generate()
    {
        var number = GenerateAccountNumber();
        var digit = CalculateMod11Digit(number);
        return new AccountNumber(number, digit);    
    }

    private static string GenerateAccountNumber()
    {
        var timestampMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var full = timestampMs.ToString();
        return full[^MaxLength..];
    }

    private static string CalculateMod11Digit(string number)
    {
        int total = 0;

        char[] reversed = number.ToCharArray();
        Array.Reverse(reversed);

        for (int i = 0; i < reversed.Length; i++)
        {
            int digitValue = reversed[i] - '0';
            int weight = Mod11Weights[i % Mod11Weights.Length];
            total += digitValue * weight;
        }

        int remainder = total % ModulusDivider;
        int checkDigit = ModulusDivider - remainder;

        if (checkDigit >= CheckDigitLimit)
        {
            checkDigit = FallbackCheckDigit;
        }

        return checkDigit.ToString();
    }

    public override string ToString() => $"{Number}-{Digit}";
}