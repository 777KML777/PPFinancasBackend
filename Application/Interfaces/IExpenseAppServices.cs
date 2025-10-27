namespace Application.Interfaces;

public interface IExpenseAppServices
{
    public ExpenseInputModel Update(int id);
    public ExpenseInputModel GetById(int id);
}