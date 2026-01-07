// using Service.Models;
// using Application.Service;
// using Tests.Printers;
// using Service.Bank;

// namespace Tests.Service.Validations;

// public class ValidationsBankService
// {

//     [Fact]
//     public void UpdateBankIdNonExistent()
//     {
//         BankService bankService = new();
//         BankInputModel bank = new BankInputModel { Name = "BankOfTestUpgraded", Balance = 0.01M, Id = 7000 };
//         Printer.PrinterSuccessBankService.PrintUpdateBankIdNonExistent(Assert.Throws<Exception>(() => bankService.Update(bank)));
//     }
// }