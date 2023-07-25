namespace Domain;

public interface IExpensesRepository : IRepository<ExpensesEntity>
{
    List<ExpensesEntity> GetAllByIdBank(int id);
}