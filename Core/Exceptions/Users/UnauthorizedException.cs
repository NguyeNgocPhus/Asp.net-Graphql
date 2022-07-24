namespace Core.Exceptions.Users;

public class UnauthorizedException : ExceptionBase
{
    public UnauthorizedException(string context, string key, string message)
        : base(context, key, message)
    {
    }

    public UnauthorizedException(
        string context,
        string key,
        string message,
        Exception exception)
        : base(context, key, message, exception)
    {
    }
}