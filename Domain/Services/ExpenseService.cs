
using Domain.Dtos;
using Domain.Extensions;
using Domain.Interfaces;

namespace Domain.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repository;
    public ExpenseService
    (
        IExpenseRepository repository
    )
    {
        _repository = repository;
    }

    #region CRUD OPERATION
    // public bool Create(ExpenseInputModel obj)
    // {
    //     try
    //     {
    //         ExpenseEntity expense = _repository.Create(MappingInputModelToEntity(obj));
    //         // expense.AddInstallments(obj.CountInstallments);

    //         // expense.Installments.ToList().ForEach(
    //         //     item => _installmentService.Create(
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
    #endregion

    #region COMMOM OPERATION 
    public ExpenseDto GetById(int identifier)
    {
        try
        {
            return _repository.GetById(identifier).ToDto();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region "SPECIFIC OPERATIONS"
    public List<ExpenseDto> GetExpenseByIdBank(int idBank) =>
        // _repository.GetAllByIdBank(idBank).ToList().ToListEntity().ToDtoEnumerable(); 
        new();


    public IEnumerable<ExpenseDto> Read()
    {
        throw new NotImplementedException();
    }

    public bool Delete(int identifier)
    {
        throw new NotImplementedException();
    }

    public ExpenseDto Create(ExpenseDto dto)
    {
        throw new NotImplementedException();
    }

    public ExpenseDto Update(ExpenseDto dto)
    {
        ExpenseEntity savedExpense = _repository.GetById(dto.Id);
        // TODO: Salvar o objeto acima no tracker. 
        var tracker = savedExpense;

        return _repository.Update(dto.ToEntity()).ToDto();
    }

    #endregion
}