using System.Net;

namespace PicPayChallenge.Api.Exceptions;

public abstract class BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}