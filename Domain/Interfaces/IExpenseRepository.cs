namespace Domain.Interfaces;

public interface IExpenseRepository : IRepository
{
    public IEnumerable<ExpenseEntity> GetAllByIdBank(int id);
}