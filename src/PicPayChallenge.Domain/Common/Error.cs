namespace PicPayChallenge.Domain;

public record Error(string Code, string Description, ErrorType Type)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new("Error.NullValue", "Value not founded", ErrorType.Failure);

    public static Error NotFound(string description) => new("Error.NotFound", description, ErrorType.NotFound);
    public static Error Validation(string description) => new("Error.Validation", description, ErrorType.Validation);
    public static Error Conflict(string description) => new("Error.Conflict", description, ErrorType.Conflict);
    public static Error Unauthorized(string description) => new("Error.Unauthorized", description, ErrorType.Unauthorized);
    public static Error Forbidden(string description) => new("Error.Forbidden", description, ErrorType.Forbidden);
}