using System.Text.RegularExpressions;

namespace PicPayChallenge.Domain.ValueObjects;

public readonly record struct Cep
{
    // Structural constants
    public const int MaxLength = 8;
    
    // Pattern and formatting constants
    private const string NonDigitPattern = @"[^\d]";
    private const string CepDisplayFormat = @"00000\-000";

    /// <summary>
    /// Gets the raw unformatted 8-digit CEP value (without hyphens).
    /// </summary>
    public string Value { get; }

    private Cep(string unformattedValue)
    {
        Value = unformattedValue;
    }

    /// <summary>
    /// Factory method to create a valid CEP instance.
    /// </summary>
    public static Cep Create(string value)
    {
        if (!TryParse(value, out var cep))
        {
            throw new ArgumentException("The provided CEP is invalid.", nameof(value));
        }

        return cep;
    }

    /// <summary>
    /// Tries to parse, sanitize, and validate a CEP string.
    /// </summary>
    public static bool TryParse(string input, out Cep cep)
    {
        cep = default;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        // Strip non-digit characters (removes hyphens, spaces, etc.)
        string sanitized = Regex.Replace(input, NonDigitPattern, string.Empty);

        if (!IsValid(sanitized))
            return false;

        cep = new Cep(sanitized);
        return true;
    }

    /// <summary>
    /// Validates a raw 8-digit CEP string.
    /// </summary>
    public static bool IsValid(string cepDigits)
    {
        if (string.IsNullOrWhiteSpace(cepDigits) || cepDigits.Length != MaxLength)
            return false;

        // Ensure all remaining characters are digits
        return cepDigits.All(char.IsDigit);
    }

    /// <summary>
    /// Returns the formatted CEP string: 00000-000
    /// </summary>
    public string ToFormattedString()
    {
        if (string.IsNullOrEmpty(Value) || Value.Length != MaxLength)
            return string.Empty;

        return Convert.ToUInt64(Value).ToString(CepDisplayFormat);
    }

    public override string ToString() => Value;
}