using Domain.Dtos;
using Domain.Extensions;
using Domain.Interfaces;

namespace Domain.Mappers;

public class ExpenseServiceMapper : IExpenseServiceMapper
{
    public ExpenseEntity MappingDtoToEntity(ExpenseDto dto)
    {
        // APRENDIZADO: Dereference nula é quando mais de um objeto pode estar nulo no mesmo acesso. 
        ExpenseEntity entity = new();
        entity.AlterExpenseEntity
        (
            dto.Id,
            dto.Bank != null ? dto.Bank.Id : 0,
            dto.Name ?? string.Empty,
            dto.Amount,
            dto.Describe ?? string.Empty,
            dto.PaymentType ?? string.Empty,
            dto.CountInstallments,
            dto.Inactive,
            false, // dto.Separated,
            dto.DatePurchase ?? new DateTime(),
            null ?? new List<InstallmentEntity>() // dto.Installments 
        );
        return entity;
    }

    #region "Object" 

    #endregion 


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

    #region "Collections" 
    public IEnumerable<ExpenseDto> MappingEntityEnumerableToDtoEnumerable(IEnumerable<ExpenseEntity> entities)
    {
        List<ExpenseDto> lst = new();
        entities.ToList().ForEach(item => lst.Add(item.ToDto()));
        return lst;
    }
    #endregion

}
