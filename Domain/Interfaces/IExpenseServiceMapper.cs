using Domain.Dtos;

namespace Domain.Interfaces; 

public interface IExpenseServiceMapper : IServiceMapper<ExpenseDto, ExpenseEntity>
{
    
}