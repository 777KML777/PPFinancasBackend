namespace Application.Interfaces;

public interface IExpenseAppService
{
    public ExpenseDto Create(ExpenseInputModel input);
    public IEnumerable<ExpenseDto> Read();
    public ExpenseDto Update(ExpenseInputModel input);
    public ExpenseInputModel GetById(int id);
}