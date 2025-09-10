using System.Reflection.Metadata.Ecma335;
using Application.Dtos;
using Application.Models;
using Application.Selects;
using Domain.Entities.Expense;
using Domain.Entities.Installment;
using Repository.JsonFile;
using Repository.JsonFile.Repositories.Bank;

namespace Application.Services;

public class ExpenseServices : IExpenseServices
{
    private readonly IExpenseRepository _repository;
    private readonly IBankServices _bankServices;
    private readonly IInstallmentServices _installmentServices;
    public ExpenseServices()
    {

        _repository = new ExpenseRepository();
        _bankServices = new BankServices();
        _installmentServices = new InstallmentServices();
    }

    public bool Create(ExpenseInputModel obj)
    {
        try
        {
            ExpenseEntity expense = _repository.Create(MappingInputModelToEntity(obj));
            // expense.AddInstallments(obj.CountInstallments);

            expense.Installments.ToList().ForEach(
                item => _installmentServices.Create(
                    new InstallmentInputModel
                    { IdExpense = item.IdExpense, Number = item.Number }
                )
            );
        }
        catch (Exception)
        {
            _repository.Delete(
                _repository.GetById<ExpenseEntityData>(
                    _repository.GetLastId<ExpenseEntityData>()
                )
            );
            // Deletar também os includes. Isso poderia ficar no Generic? 
            throw;
        }

        // Validar se existe o mesmo nome? 
        // Amount deveria ficar talvez em Installment e não em Expense
        // Eu tenho que salvar a entidade principal antes da menor. 

        // Se der erro em alguma operação aborta tudo. 
        // Uma espécie de método de criação virtual 
        // Retornar objeto criado já em Generics? 

        // ExpenseEntity expense = MappingInputModelToEntity(obj);
        // Validar se existe parcelas para essa despesa 
        // Qual seria o critério o valor, e a quantidade? Se for valor tem que estar em Installments. 

        return true;
    }
    public List<ExpenseDto> Read()
    {
        throw new NotImplementedException();
    }

    public bool Delete(ExpenseInputModel obj)
    {
        throw new NotImplementedException();
    }

    public List<ExpenseDto> GetExpenseByIdBank(int idBank)
    {
        List<ExpenseDto> lstExpenses = new List<ExpenseDto>();
        _repository.GetAllByIdBank(idBank).ForEach
        (
            x => lstExpenses.Add
            (

                MappingEntityToDto
                (
                    MappingEntityDataToEntity(x)
                )
            )
        );

        // lstExpenses.ForEach(x => 
        //     x.Installments = _installmentServices.GetAllPaidByIdExpenses(x.Id));

        // lstExpenses.ForEach(x =>
        //     x.Installments.AddRange(_installmentServices.GetAllPaidByIdExpenses(x.Id)));


        // lstExpenses.ForEach(x => x.SumTotalExpensesItem());
        // lstExpenses.ForEach(x => x.SumInstallmentsAndTotalRemaning(x.Installments.Count));

        return lstExpenses;
    }

    #region CRUD OPERATION

    public ExpenseDto Update(ExpenseDto dto)
    {
        throw new NotImplementedException();
    }


    #endregion

    #region MAPPING OBJECT
    public ExpenseInputModel GetById(int id)
    {
        List<BankDataList> bankDataLists = new();
        var dto = MappingEntityToDto
        (
            MappingEntityDataToEntity
            (
                _repository.GetById<ExpenseEntityData>(id)
            )
        );

        var banks = _bankServices.Read().Select(bank => new { bank.Id, bank.Name }).ToList();

        banks.ForEach(item => bankDataLists.Add(new() { Id = item.Id, Name = item.Name }));

        return
            new ExpenseInputModel(dto, bankDataLists);
    }
    #endregion

    #region MAPPING LIST OBJECTS
    #endregion

    #region COMMOM OPERATION 
    #endregion


    public ExpenseDto MappingEntityToDto(ExpenseEntity entity)
    {
        List<InstallmentDto> installments = new();

        entity.Installments.ToList().ForEach(item =>
            installments.Add(_installmentServices.MappingEntityToDto(item)));

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
            installments
        );
    }


    public ExpenseEntityData MappingEntityToEntityData(ExpenseEntity obj)
    {
        return new()
        {
            Id = obj.Id,
            IdBank = obj.IdBank,
            Name = obj.Name,
            Inactive = obj.Inactive,
            Separeted = obj.Separeted,
            Amount = obj.Amount,
            Describe = obj.Describe,
            PaymentType = obj.PaymentType,
            CountInstallments = obj.CountInstallments,
            DateLastInstallment = obj.DateLastInstallment,
            DatePurchase = obj.DatePurchase,
            DateFirstInstallment = obj.DateFirstInstallment,
            Installments = new List<InstallmentEntityData>()
        };
    }

    public ExpenseEntity MappingEntityDataToEntity(ExpenseEntityData obj)
    {
        ExpenseEntity entidade = new();
        entidade.AlterExpenseEntity
        (
            obj.Id,
            obj.IdBank,
            obj.Name,
            obj.Amount,
            obj.Describe,
            obj.PaymentType,
            obj.CountInstallments,
            obj.Inactive,
            obj.Separeted,
            obj.DatePurchase,
            new List<InstallmentEntity>()
        );
        return entidade;
    }

    public List<ExpenseDto> MappingListEntityToListDto(List<ExpenseEntity> obj)
    {
        List<ExpenseDto> lst = new();
        obj.ForEach(item => lst.Add(MappingEntityToDto(item)));
        return lst;
    }

    public List<ExpenseEntityData> MappingListEntityToListEntityData(List<ExpenseEntity> obj)
    {
        List<ExpenseEntityData> lst = new();
        obj.ForEach(item => lst.Add(MappingEntityToEntityData(item)));
        return lst;
    }

    public List<ExpenseEntity> MappingListEntityDataToListEntity(List<ExpenseEntityData> obj)
    {
        List<ExpenseEntity> lst = new();
        obj.ForEach(item => lst.Add(MappingEntityDataToEntity(item)));
        return lst;
    }

    ExpenseDto IService<ExpenseInputModel, ExpenseDto, ExpenseEntity, ExpenseEntityData>.Create(ExpenseInputModel input)
    {
        throw new NotImplementedException();
    }



    public ExpenseEntity MappingDtoToEntity(ExpenseDto dto)
    {
        throw new NotImplementedException();
    }

    public bool Create(ExpenseInputModel input, bool remover = true)
    {
        throw new NotImplementedException();
    }

    #region REMOVER 
    public bool Update(ExpenseInputModel obj, bool remover = true)
    {
        throw new NotImplementedException();
    }

    public ExpenseDto GetById(int id, bool remover = true)
    {
        return MappingEntityToDto
        (
            MappingEntityDataToEntity
            (
                _repository.GetById<ExpenseEntityData>(id)
            )
        );
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
    #endregion
}