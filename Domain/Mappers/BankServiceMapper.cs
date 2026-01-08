using Domain.Dtos;
using Domain.Extensions;
using Domain.Interfaces;

namespace Domain.Mappers;

public class BankServiceMapper : IBankServiceMapper
{

    #region "OBJECTS" 
    public BankDto MappingEntityToDto(BankEntity entity) =>
        new
        (
            entity.Id, 
            entity.Name, 
            entity.Available, 
            entity.Balance, 
            entity.PaymentDay, 
            entity.Expenses.Count, 
            entity.TotalExpenses(), 
            entity.LiquidedBalance(),
            entity.Image,
            entity.Expenses.ToDtoEnumerable()
        );

    #endregion

    public BankEntity MappingDtoToEntity(BankDto dto)
    {
        throw new NotImplementedException();
    }

    #region "COLLECTIONS" 
    public IEnumerable<BankDto> MappingEntityEnumerableToDtoEnumerable(IEnumerable<BankEntity> entities)
    {
        List<BankDto> lst = new();
        entities.ToList().ForEach(item => lst.Add(item.ToDto()));
        return lst;
    }
    #endregion
}