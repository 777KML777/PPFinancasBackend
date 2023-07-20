namespace Domain; 

public interface IExpensesRepository : IRepository<ExpensesEntity>
{
    List<ExpensesEntity> GetAll();
    List<ExpensesEntity> GetAllByIdBank(int id);
}