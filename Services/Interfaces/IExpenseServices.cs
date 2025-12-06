namespace Services.Interfaces;

public interface IExpenseServices : IService<ExpenseInputModel, ExpenseDto, ExpenseEntity>
{
    List<ExpenseDto> GetExpenseByIdBank(int idBank);
}