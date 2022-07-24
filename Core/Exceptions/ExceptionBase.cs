namespace Core.Exceptions;

public class ExceptionBase : Exception
{
  

    public ExceptionBase(string context, string key, string message)
        : base(message)
    {
        this.Data[(object) "Context"] = (object) context;
        this.Data[(object) "Key"] = (object) key;
    }

    public ExceptionBase(
        string context,
        string key,
        string message,
        Exception exception
)
        : base(message, exception)
    {
        this.Data[(object) "Context"] = (object) context;
        this.Data[(object) "Key"] = (object) key;
    }

    public ExceptionBase WithData(string name, object value)
    {
        this.Data[(object) name] = value;
        return this;
    }
}