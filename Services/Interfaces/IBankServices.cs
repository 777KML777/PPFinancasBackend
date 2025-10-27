namespace Services.Interfaces;

public interface IBankServices : IService<BankInputModel, BankDto, BankEntity, BankEntityData>
{
    List<BankDataList> GetDataList();
}