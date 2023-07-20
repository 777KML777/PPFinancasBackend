using Domain;

namespace Application;

public interface IExpensesService : IService<ExpenseDto, ExpensesEntity>
{
    List<ExpenseDto> GetExpenseByIdBank(int idBank);
}