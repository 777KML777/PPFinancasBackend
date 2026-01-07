using Domain.Dtos;
using Domain.Interfaces;

namespace Domain.Mappers;

public class ExpenseServiceMapper : IExpenseServiceMapper
{
    public ExpenseEntity MappingDtoToEntity(ExpenseDto dto)
    {
        throw new NotImplementedException();
    }

    #region "Object" 

    #endregion 
    // public ExpenseEntity MappingEntityDataToEntity(ExpenseEntityData data)
    // {
    //     ExpenseEntity entidade = new();
    //     entidade.AlterExpenseEntity
    //     (
    //         data.Id,
    //         data.IdBank,
    //         data.Name,
    //         data.Amount,
    //         data.Describe,
    //         data.PaymentType,
    //         data.CountInstallments,
    //         data.Inactive,
    //         data.Separeted,
    //         data.DatePurchase,
    //         new List<InstallmentEntity>()
    //     );
    //     return entidade;
    // }

    public ExpenseDto MappingEntityToDto(ExpenseEntity entity)
    {
        // List<InstallmentDto> installments = new();

        // entity.Installments.ToList().ForEach(item =>
        //     installments.Add(_installmentService.MappingEntityToDto(item)));

        return new
        (
            entity.Id,
            entity.IdBank,
            entity.Name,
            entity.Inactive,
            entity.Separeted,
            entity.Amount,
            entity.Describe,
            entity.PaymentType,
            entity.SumTotalExpense(),
            entity.CountInstallments,
            entity.CountPaidInstallments(),
            entity.CountRemainingInstallments(),
            entity.SumTotalExpense() - entity.CountRemainingInstallments() * entity.CountInstallments,
            entity.DatePurchase,
            entity.DateLastInstallment,
            entity.DateFirstInstallment,
            new List<InstallmentDto>()
        // installments
        );
    }



    // public ExpenseEntity MappingInputModelToEntity(ExpenseInputModel obj)
    // {
        // if (obj.Id > 0)
        // {
        //     ExpenseEntity expenseEntity = new();
        //     expenseEntity.AlterExpenseEntity
        //     (
        //         obj.Id,
        //         obj.IdBank,
        //         obj.Name,
        //         obj.Amount,
        //         obj.Describe,
        //         obj.PaymentType,
        //         obj.CountInstallments,
        //         false, // TODO - rever isso aqui
        //         false, // TODO - rever isso aqui
        //         DateTime.Now, // TODO - rever isso aqui,
        //         new List<InstallmentEntity>()
        //     );

        //     return expenseEntity;
        // }
        // else
        // {
        //     ExpenseEntity expenseEntity = new
        //     (
        //         obj.Name,
        //         obj.Amount,
        //         obj.Describe,
        //         obj.PaymentType,
        //         obj.CountInstallments
        //     );

        //     return expenseEntity;
        // }

    //     return new ExpenseEntity();
    // }

    #region "Collections" 
    public List<ExpenseDto> MappingEntityEnumerableToDtoEnumerable(List<ExpenseEntity> obj)
    {
        List<ExpenseDto> lst = new();
        obj.ForEach(item => lst.Add(/* item.ToDto() */null));
        return lst;
    }
    public IEnumerable<ExpenseDto> MappingEntityEnumerableToDtoEnumerable(IEnumerable<ExpenseEntity> entities)
    {
        throw new NotImplementedException();
    }
    #endregion

}
