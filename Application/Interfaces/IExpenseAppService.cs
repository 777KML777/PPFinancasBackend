using Application.Inputs;

namespace Application.Interfaces;

public interface IExpenseAppService
{
    public ExpenseInputModel Update(int id);
    public ExpenseInputModel GetById(int id);
}