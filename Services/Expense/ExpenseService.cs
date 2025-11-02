namespace Services.Expense;

public class ExpenseServices : IExpenseServices
{
    private readonly IExpenseRepository _repository;
    public ExpenseServices()
    {
        _repository = new ExpenseRepository();
    }

    #region CRUD OPERATION
    // public bool Create(ExpenseInputModel obj)
    // {
    //     try
    //     {
    //         ExpenseEntity expense = _repository.Create(MappingInputModelToEntity(obj));
    //         // expense.AddInstallments(obj.CountInstallments);

    //         // expense.Installments.ToList().ForEach(
    //         //     item => _installmentServices.Create(
    //         //         new InstallmentInputModel
    //         //         { IdExpense = item.IdExpense, Number = item.Number }
    //         //     )
    //         // );
    //     }
    //     catch (Exception)
    //     {
    //         _repository.Delete(
    //             _repository.GetById<ExpenseEntityData>(
    //                 _repository.GetLastId<ExpenseEntityData>()
    //             )
    //         );
    //         // Deletar também os includes. Isso poderia ficar no Generic? 
    //         throw;
    //     }

    //     // Validar se existe o mesmo nome? 
    //     // Amount deveria ficar talvez em Installment e não em Expense
    //     // Eu tenho que salvar a entidade principal antes da menor. 

    //     // Se der erro em alguma operação aborta tudo. 
    //     // Uma espécie de método de criação virtual 
    //     // Retornar objeto criado já em Generics? 

    //     // ExpenseEntity expense = MappingInputModelToEntity(obj);
    //     // Validar se existe parcelas para essa despesa 
    //     // Qual seria o critério o valor, e a quantidade? Se for valor tem que estar em Installments. 

    //     return true;
    // }
    public ExpenseDto Create(ExpenseInputModel input)
    {
        throw new NotImplementedException();
    }
    public List<ExpenseDto> Read(bool inactived = false) =>
        _repository.ReadAll<ExpenseEntityData>().ToList().ToListEntity().ToListDto();
    public ExpenseDto Update(ExpenseInputModel dto)
    {
        throw new NotImplementedException();
    }
    public bool Delete(ExpenseInputModel obj)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region COMMOM OPERATION 
    public ExpenseDto GetById(int id)
    {
        try
        {
            var data = _repository.GetById<ExpenseEntityData>(id);
            return data.ToEntity().ToDto();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region "SPECIFIC OPERATIONS"
    public List<ExpenseDto> GetExpenseByIdBank(int idBank) =>
        _repository.GetAllByIdBank(idBank).ToList().ToListEntity().ToListDto();

    #endregion
}