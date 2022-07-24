namespace Core.Exceptions.Users;

public class DuplicateUserException : ExceptionBase
{
    public DuplicateUserException(string context, string key, string message) : base(context, key, message)
    {
    }

    public DuplicateUserException(string context, string key, string message, Exception exception) : base(context, key, message, exception)
    {
    }
}