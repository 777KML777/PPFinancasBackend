using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public class ExpenseExceptionAlreadyExist : DomainException
{


    public ExpenseExceptionAlreadyExist
    (
        string expenseName
    ) : base(code: "EXPENSE_ALREADY_EXISTS", message: $"A expense with the name '{expenseName}' already exists.")
    {

    }

}