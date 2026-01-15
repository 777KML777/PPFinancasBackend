// using Domain.Entities;
// using Domain.Extensions;

// namespace Application.Validators;

// // TODO: Talvez criar um BaseAppService eu poderia chamar o validate direto tipando.
// public class BankAppServiceValidator
// {
//     private static readonly IBankService _bankService;

//     public BankAppServiceValidator
//     (
//         IBankService bankAppService
//     )
//     {
//         _bankService = bankAppService;
//     }
//     // public static BankDto Validate(int id) => new BankEntity().ToDto();
//     public static BankDto Validate(int id) => _bankService.GetById(id);
// }

// TODO: Não obtive sucesso. 