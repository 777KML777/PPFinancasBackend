namespace Domain.Interfaces;

public interface IExpenseRepository : IRepository
{
    public IEnumerable<ExpenseEntity> GetAllByIdBank(int id);

    public ExpenseEntity GetById(int identifier);
    public ExpenseEntity Update(ExpenseEntity entity);
}