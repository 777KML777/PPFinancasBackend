namespace Services.Interfaces;

public interface IExpenseServices : IService<ExpenseInputModel, ExpenseDto, ExpenseEntity, ExpenseEntityData>
{
    List<ExpenseDto> GetExpenseByIdBank(int idBank);
}