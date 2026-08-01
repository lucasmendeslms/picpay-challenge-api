namespace PicPayChallenge.Domain.Exceptions;

using System.Net;
using static System.Net.HttpStatusCode;

public abstract class CustomException(string message, HttpStatusCode statusCode = BadRequest) : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}

public class UserNotFoundException(string message) : CustomException(message, NotFound) { }