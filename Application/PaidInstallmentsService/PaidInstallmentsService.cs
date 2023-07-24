using Domain;
using Repository.JsonFile;

namespace Application;

public class PaidInstallmentsService : IPaidInstallmentsService
{

    private readonly IPaidInstallmentsRepository _paidInstallmentsRepository;

    public PaidInstallmentsService()
    {
        _paidInstallmentsRepository = new PaidInstallmentsRepository();
    }

    public void Create (PaidInstallmentsDto obj) 
    {
        _paidInstallmentsRepository.Create(MappingDtoToEntity(obj));
    }
    public List<PaidInstallmentsDto> GetAllPaidByIdExpenses(int idExpenses)
    {
        List<PaidInstallmentsDto> lstPaidInstallments = new List<PaidInstallmentsDto>();
        _paidInstallmentsRepository.GetAllPaidByIdExpenses(idExpenses).ToList().ForEach(x => lstPaidInstallments.Add(MappingEntityToDto(x)));


        return lstPaidInstallments;
    }
    public int GetNextId() =>
            _paidInstallmentsRepository.GetLastId() + 1;

    // Mappings Method
    public PaidInstallmentsEntity MappingDtoToEntity(PaidInstallmentsDto obj)
    {
        return new PaidInstallmentsEntity()
        {
            Id = obj.Id,
            IdExpenses = obj.IdExpenses,
            PaymentDate = obj.PaymentDate
        };
    }

    public PaidInstallmentsDto MappingEntityToDto(PaidInstallmentsEntity obj)
    {
        return new PaidInstallmentsDto()
        {
            Id = obj.Id,
            IdExpenses = obj.IdExpenses,
            PaymentDate = obj.PaymentDate
        };
    }
}