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
    public List<PaidInstallmentsDto> GetAllPaidByIdExpenses(int idExpenses)
    {
        List<PaidInstallmentsDto> lstPaidInstallments = new List<PaidInstallmentsDto>();
        _paidInstallmentsRepository.GetAllPaidByIdExpenses(idExpenses).ToList().ForEach(x => lstPaidInstallments.Add(MappingEntityToDto(x)));

        
        return lstPaidInstallments;
    }
    public PaidInstallmentsEntity MappingDtoToEntity(PaidInstallmentsDto obj)
    {
        throw new NotImplementedException();
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