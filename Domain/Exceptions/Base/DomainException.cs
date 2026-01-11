namespace Domain.Exceptions.Base;

public abstract class DomainException : Exception
{

    protected DomainException
    (
        string code,
        string message
    ) : base(message)
    {
        Code = code;
    }
    public string Code { get; }
}