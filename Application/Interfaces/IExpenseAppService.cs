using Application.Inputs;

namespace Application.Interfaces;

public interface IExpenseAppService
{
    public ExpenseInputModel GetById(int id);
    public ExpenseDto Update(ExpenseInputModel input);
}