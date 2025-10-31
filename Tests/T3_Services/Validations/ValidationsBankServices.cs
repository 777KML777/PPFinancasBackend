// using Services.Models;
// using Application.Services;
// using Tests.Printers;
// using Services.Bank;

// namespace Tests.Services.Validations;

// public class ValidationsBankServices
// {

//     [Fact]
//     public void UpdateBankIdNonExistent()
//     {
//         BankServices bankService = new();
//         BankInputModel bank = new BankInputModel { Name = "BankOfTestUpgraded", Balance = 0.01M, Id = 7000 };
//         Printer.PrinterSuccessBankServices.PrintUpdateBankIdNonExistent(Assert.Throws<Exception>(() => bankService.Update(bank)));
//     }
// }