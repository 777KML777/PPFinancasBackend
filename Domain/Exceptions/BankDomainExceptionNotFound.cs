using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public class BankDomainExceptionNotFound : DomainException
{


    public BankDomainExceptionNotFound
    (
        int identifier
    ) : base(code: "BANK_NOTFOUND", message: $"Bank Not Found with identifier '{identifier}'.")
    {

    }

}