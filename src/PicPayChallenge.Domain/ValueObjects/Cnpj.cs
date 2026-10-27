using System.Text.RegularExpressions;

namespace PicPayChallenge.Domain.ValueObjects;

public readonly record struct Cnpj
{
    // Structural constants
    public const int MaxLength = 14;
    private const int BaseLengthWithoutDigits = 12;
    private const int BaseLengthWithFirstDigit = 13;
    
    // Algorithmic validation constants (Brazilian CNPJ specification rules)
    private const int ModulusDivider = 11;
    private const int RemainderThreshold = 2;
    private const int DefaultCheckDigit = 0;

    // Pattern and formatting constants
    private const string NonDigitPattern = @"[^\d]";
    private const string CnpjDisplayFormat = @"00\.000\.000\/0000\-00";

    private static readonly int[] Multiplier1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
    private static readonly int[] Multiplier2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

    /// <summary>
    /// Gets the raw unformatted 14-digit CNPJ value.
    /// </summary>
    public string Value { get; }

    private Cnpj(string unformattedValue)
    {
        Value = unformattedValue;
    }

    /// <summary>
    /// Factory method to create a valid CNPJ instance.
    /// </summary>
    public static Cnpj Create(string value)
    {
        if (!TryParse(value, out var cnpj))
        {
            throw new ArgumentException("The provided CNPJ is invalid.", nameof(value));
        }

        return cnpj;
    }

    /// <summary>
    /// Tries to parse and validate a CNPJ string.
    /// </summary>
    public static bool TryParse(string input, out Cnpj cnpj)
    {
        cnpj = default;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        // Strip non-digit characters using the defined pattern constant
        string sanitized = Regex.Replace(input, NonDigitPattern, string.Empty);

        if (!IsValid(sanitized))
            return false;

        cnpj = new Cnpj(sanitized);
        return true;
    }

    /// <summary>
    /// Validates a raw 14-digit CNPJ string against Brazilian revenue rules.
    /// </summary>
    public static bool IsValid(string cnpjDigits)
    {
        if (string.IsNullOrWhiteSpace(cnpjDigits) || cnpjDigits.Length != MaxLength)
            return false;

        // Reject sequences composed entirely of identical digits (e.g., "00000000000000")
        if (cnpjDigits.All(c => c == cnpjDigits[0]))
            return false;

        // --- First Verification Digit Calculation ---
        string tempCnpj = cnpjDigits.Substring(0, BaseLengthWithoutDigits);
        int sum = 0;

        for (int i = 0; i < BaseLengthWithoutDigits; i++)
        {
            sum += (tempCnpj[i] - '0') * Multiplier1[i];
        }

        int remainder = sum % ModulusDivider;
        int firstDigit = remainder < RemainderThreshold ? DefaultCheckDigit : ModulusDivider - remainder;

        tempCnpj += firstDigit;
        sum = 0;

        // --- Second Verification Digit Calculation ---
        for (int i = 0; i < BaseLengthWithFirstDigit; i++)
        {
            sum += (tempCnpj[i] - '0') * Multiplier2[i];
        }

        remainder = sum % ModulusDivider;
        int secondDigit = remainder < RemainderThreshold ? DefaultCheckDigit : ModulusDivider - remainder;

        // Compare calculated digits with the actual ending digits of the input
        string expectedDigits = $"{firstDigit}{secondDigit}";
        return cnpjDigits.EndsWith(expectedDigits);
    }

    /// <summary>
    /// Returns the formatted CNPJ string: XX.XXX.XXX/XXXX-XX
    /// </summary>
    public string ToFormattedString()
    {
        if (string.IsNullOrEmpty(Value) || Value.Length != MaxLength)
            return string.Empty;

        return Convert.ToUInt64(Value).ToString(CnpjDisplayFormat);
    }

    public override string ToString() => Value;
}