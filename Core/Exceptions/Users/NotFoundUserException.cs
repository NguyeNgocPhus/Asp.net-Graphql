namespace Core.Exceptions.Users;

public class NotFoundUserException : ExceptionBase
{
    public NotFoundUserException(string context, string key, string message) : base(context, key, message)
    {
    }

    public NotFoundUserException(string context, string key, string message, Exception exception) : base(context, key, message, exception)
    {
    }
}