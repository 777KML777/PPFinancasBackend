namespace Services.Mappings;

public class ExpenseMapper : IMappings<ExpenseInputModel, ExpenseDto, ExpenseEntity, ExpenseEntityData>
{
    public ExpenseEntity MappingDtoToEntity(ExpenseDto dto)
    {
        throw new NotImplementedException();
    }

    #region "Object" 

    #endregion 
    public ExpenseEntity MappingEntityDataToEntity(ExpenseEntityData data)
    {
        ExpenseEntity entidade = new();
        entidade.AlterExpenseEntity
        (
            data.Id,
            data.IdBank,
            data.Name,
            data.Amount,
            data.Describe,
            data.PaymentType,
            data.CountInstallments,
            data.Inactive,
            data.Separeted,
            data.DatePurchase,
            new List<Domain.Entities.Installment.InstallmentEntity>()
        );
        return entidade;
    }

    public ExpenseDto MappingEntityToDto(ExpenseEntity entity)
    {
        // List<InstallmentDto> installments = new();

        // entity.Installments.ToList().ForEach(item =>
        //     installments.Add(_installmentServices.MappingEntityToDto(item)));

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
            entity.SumPaidInstallments(),
            entity.SumRemainingInstallments(),
            entity.SumTotalExpense() - entity.SumRemainingInstallments() * entity.CountInstallments,
            entity.DatePurchase,
            entity.DateLastInstallment,
            entity.DateFirstInstallment,
            new List<InstallmentDto>()
        // installments
        );
    }

    public ExpenseEntityData MappingEntityToEntityData(ExpenseEntity entity)
    {
        return new()
        {
            Id = entity.Id,
            IdBank = entity.IdBank,
            Name = entity.Name,
            Inactive = entity.Inactive,
            Separeted = entity.Separeted,
            Amount = entity.Amount,
            Describe = entity.Describe,
            PaymentType = entity.PaymentType,
            CountInstallments = entity.CountInstallments,
            DateLastInstallment = entity.DateLastInstallment,
            DatePurchase = entity.DatePurchase,
            DateFirstInstallment = entity.DateFirstInstallment,
            Installments = new List<InstallmentEntityData>()
        };
    }

    public ExpenseEntity MappingInputModelToEntity(ExpenseInputModel obj)
    {
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

        return new ExpenseEntity();
    }

    #region "Collections" 
    public List<ExpenseDto> MappingListEntityToListDto(List<ExpenseEntity> obj)
    {
        List<ExpenseDto> lst = new();
        obj.ForEach(item => lst.Add(item.ToDto()));
        return lst;
    }

    public List<ExpenseEntity> MappingListEntityDataToListEntity(List<ExpenseEntityData> obj)
    {
        List<ExpenseEntity> lst = new();
        obj.ForEach(item => lst.Add(item.ToEntity()));
        return lst;
    }
    #endregion

}
