using System.Net;

namespace PicPayChallenge.Api.Exceptions.CustomExceptions;

public sealed class NotFoundException(string resource, object key) 
    : BaseException($"{resource} with identifier '{key}' was not found", HttpStatusCode.NotFound);