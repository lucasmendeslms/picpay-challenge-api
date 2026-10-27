using System.Text.RegularExpressions;

namespace PicPayChallenge.Domain.ValueObjects;

public readonly record struct Cpf
{
    // Structural constants
    public const int MaxLength = 11;
    private const int BaseLengthWithoutDigits = 9;
    private const int BaseLengthWithFirstDigit = 10;
    
    // Algorithmic validation constants (Brazilian CPF specification rules)
    private const int ModulusDivider = 11;
    private const int RemainderThreshold = 2;
    private const int DefaultCheckDigit = 0;

    // Pattern and formatting constants
    private const string NonDigitPattern = @"[^\d]";
    private const string CpfDisplayFormat = @"000\.000\.000\-00";

    private static readonly int[] Multiplier1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
    private static readonly int[] Multiplier2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

    /// <summary>
    /// Gets the raw unformatted 11-digit CPF value.
    /// </summary>
    public string Value { get; }

    private Cpf(string unformattedValue)
    {
        Value = unformattedValue;
    }

    /// <summary>
    /// Factory method to create a valid CPF instance.
    /// </summary>
    public static Cpf Create(string value)
    {
        if (!TryParse(value, out var cpf))
        {
            throw new ArgumentException("The provided CPF is invalid.", nameof(value));
        }

        return cpf;
    }

    /// <summary>
    /// Tries to parse and validate a CPF string.
    /// </summary>
    public static bool TryParse(string input, out Cpf cpf)
    {
        cpf = default;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        // Strip non-digit characters using the defined pattern constant
        string sanitized = Regex.Replace(input, NonDigitPattern, string.Empty);

        if (!IsValid(sanitized))
            return false;

        cpf = new Cpf(sanitized);
        return true;
    }

    /// <summary>
    /// Validates a raw 11-digit CPF string against Brazilian revenue rules.
    /// </summary>
    public static bool IsValid(string cpfDigits)
    {
        if (string.IsNullOrWhiteSpace(cpfDigits) || cpfDigits.Length != MaxLength)
            return false;

        // Reject sequences composed entirely of identical digits (e.g., "11111111111")
        if (cpfDigits.All(c => c == cpfDigits[0]))
            return false;

        // --- First Verification Digit Calculation ---
        string tempCpf = cpfDigits.Substring(0, BaseLengthWithoutDigits);
        int sum = 0;

        for (int i = 0; i < BaseLengthWithoutDigits; i++)
        {
            sum += (tempCpf[i] - '0') * Multiplier1[i];
        }

        int remainder = sum % ModulusDivider;
        int firstDigit = remainder < RemainderThreshold ? DefaultCheckDigit : ModulusDivider - remainder;

        tempCpf += firstDigit;
        sum = 0;

        // --- Second Verification Digit Calculation ---
        for (int i = 0; i < BaseLengthWithFirstDigit; i++)
        {
            sum += (tempCpf[i] - '0') * Multiplier2[i];
        }

        remainder = sum % ModulusDivider;
        int secondDigit = remainder < RemainderThreshold ? DefaultCheckDigit : ModulusDivider - remainder;

        // Compare calculated digits with the actual ending digits of the input
        string expectedDigits = $"{firstDigit}{secondDigit}";
        return cpfDigits.EndsWith(expectedDigits);
    }

    /// <summary>
    /// Returns the formatted CPF string: XXX.XXX.XXX-XX
    /// </summary>
    public string ToFormattedString()
    {
        if (string.IsNullOrEmpty(Value) || Value.Length != MaxLength)
            return string.Empty;

        return Convert.ToUInt64(Value).ToString(CpfDisplayFormat);
    }

    public override string ToString() => Value;
}