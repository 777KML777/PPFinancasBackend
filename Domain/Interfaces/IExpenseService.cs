using Domain.Dtos;

namespace Domain.Interfaces;

public interface IExpenseService : IService<ExpenseDto, ExpenseEntity>
{
    List<ExpenseDto> GetExpenseByIdBank(int idBank);
}