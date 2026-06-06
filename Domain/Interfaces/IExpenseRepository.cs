namespace Domain.Interfaces;

public interface IExpenseRepository : IRepository
{
    public IEnumerable<ExpenseEntity> GetAllByIdBank(int id);

    public ExpenseEntity GetById(int identifier);
    public ExpenseEntity Create(ExpenseEntity entity);
    public ExpenseEntity Update(ExpenseEntity entity);
}