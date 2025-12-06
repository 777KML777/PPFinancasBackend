namespace Services.Interfaces;

public interface IBankServices : IService<BankInputModel, BankDto, BankEntity>
{
    List<BankDataList> GetDataList();
}