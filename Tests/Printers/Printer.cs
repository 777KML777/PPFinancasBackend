using Application.Dtos;
using Application.Models;
using Domain.Entities.Expense;
using Domain.Entities.Bank;

namespace Tests.Printers;

public static class Printer
{
    public static class PrinterSuccessBankServices
    {
        public static void GetByIdInclude(BankDto printerBank)
        {
            string content = $"PrinterSuccessBankServices - GetByIdInclude {DateTime.Now}";

            content = content.Insert(content.Length, "\n\n");

            content = content.Insert(content.Length, $"\nNOME: {printerBank.Name}");
            content = content.Insert(content.Length, $"\n\tBalance: {printerBank.Balance}");
            content = content.Insert(content.Length, $"\n\tQuantidade De Despesas: {printerBank.Expenses.Count}");
            content = content.Insert(content.Length, $"\n\tTotal De Fatura {printerBank.FaturaDoBanco.TotalDeFaturas}");
            content = content.Insert(content.Length, $"\n\tTotal De Parcelas Do Banco {printerBank.FaturaDoBanco.Faturas.Count}"); 
            content = content.Insert(content.Length, $"\n\tFatura Menor Data: {printerBank.FaturaDoBanco.MenorDataFatura.Date}");
            content = content.Insert(content.Length, $"\n\tFatura Maior Data: {printerBank.FaturaDoBanco.MaiorDataFatura.Date}");

            content = content.Insert(content.Length, "\n\n\n");

            printerBank.Expenses.ForEach(item =>
             {
                 content = content.Insert(content.Length, "\nDESPESAS");
                 content = content.Insert(content.Length, $"\n\tIdentificador: {item.Id}");
                 content = content.Insert(content.Length, $"\n\tNome: {item.Name}");
                 content = content.Insert(content.Length, $"\n\tParcelas: {item.CountInstallments}");
                 content = content.Insert(content.Length, $"\n\tData Compra: {item.DatePurchase}");
                 content = content.Insert(content.Length, $"\n\tData Primeiro Pagamento: {item.DateFirstInstallments}");
                 content = content.Insert(content.Length, $"\n\tData Último Pagamento: {item.DateLastInstallments}");
                 content = content.Insert(content.Length, "\n==================================================");
             });


            content = content.Insert(content.Length, "\n\n\n");
            var primeiraData = printerBank.FaturaDoBanco.MenorDataFatura.Date;
            var iteracao = 0;

            while (iteracao <= printerBank.FaturaDoBanco.TotalDeFaturas)
            {

                if (iteracao == 0)
                {
                    printerBank
                    .FaturaDoBanco
                    .Faturas
                    .Where
                    (
                        e =>
                        e.DataCompra.Date <= printerBank.DataPagamento
                        .AddMonths(iteracao)
                    )
                    .ToList()
                    .ForEach
                    (
                        item =>
                        {

                            content = content.Insert(content.Length, $"\n {iteracao}º FATURA MÊS {item.DataCompra.Date}");
                            content = content.Insert(content.Length, $"\n\tNome: {item.Nome}");
                            content = content.Insert(content.Length, $"\n\tParcela: {item.NumeroParcela}");
                            content = content.Insert(content.Length, $"\n\tTotal De Parcelas: {item.QuantidadeTotalParcelas}");
                            content = content.Insert(content.Length, $"\n\tValor: {item.ValorParcela}");
                            content = content.Insert(content.Length, $"\n\tData: {item.DataCompra}");

                            primeiraData = item.DataCompra;
                        }
                    );
                }
                else
                {
                    var dataAnterior = printerBank.DataPagamento.AddMonths(iteracao - 1);

                    printerBank
                    .FaturaDoBanco
                    .Faturas
                    .Where
                    (
                        e =>
                        e.DataCompra.Date <= printerBank.DataPagamento
                        .AddMonths(iteracao).Date
                        && e.DataCompra.Date >= dataAnterior.Date
                    )
                    .ToList()
                    .ForEach
                    (
                        item =>
                        {

                            content = content.Insert(content.Length, $"\n {iteracao}º FATURA MÊS {item.DataCompra.Date}");
                            content = content.Insert(content.Length, $"\n\tNome: {item.Nome}");
                            content = content.Insert(content.Length, $"\n\tParcela: {item.NumeroParcela}");
                            content = content.Insert(content.Length, $"\n\tTotal De Parcelas: {item.QuantidadeTotalParcelas}");
                            content = content.Insert(content.Length, $"\n\tValor: {item.ValorParcela}");
                            content = content.Insert(content.Length, $"\n\tData: {item.DataCompra}");

                            primeiraData = item.DataCompra;
                        }
                    );
                }

                iteracao++;
            }


            File.WriteAllText
                    (
                        "/Users/klebermirandalima/Projetos/PPFinancasBackend/Tests/Logs/LOG-PrinterSuccessBankServicesGetByIdInclude.txt",
                         content
                    );
        }

        public static void UpdateBank(BankEntity oldBank, BankInputModel newBank)
        {
            string content = $"COMPARATIVO";
            // content = content.Insert(content.Length, "\nREALIDADE:");
            // content = content.Insert(content.Length, "\nTotal Disponível: ");
            // content = content.Insert(content.Length, $"{bank.TotalAvailableBalance}");
            // content = content.Insert(content.Length, "\nTotal Despesas: ");
            // content = content.Insert(content.Length, $"{bank.TotalExpenses}");
            // content = content.Insert(content.Length, "\nSaldo Disponível: ");
            // content = content.Insert(content.Length, $"{bank.AvailableBalance}");
            // content = content.Insert(content.Length, "\n==================================================");

            // content = content.Insert(content.Length, "\nTotal Não Disponível (FGTS): ");
            // content = content.Insert(content.Length, $"{dashboard.TotalBalance}");
            // content = content.Insert(content.Length, "\nSaldo Não Disponível (FGTS): ");
            // content = content.Insert(content.Length, $"{dashboard.Balance}");
            // content = content.Insert(content.Length, "\nQTD Total Despesas: ");
            // content = content.Insert(content.Length, $"{dashboard.TotalCountExpenses}");
            // content = content.Insert(content.Length, "\n==================================================");

            File.WriteAllText("/Users/klebermirandalima/Projetos/PPFinancasBackend/Tests/SuccessBankServices.txt", content);
        }


        public static void PrintUpdateBankIdNonExistent(Exception ex)
        {
            string content = $"ValidationsBankServices.UpdateBankIdNonExistent - PrintUpdateBankIdNonExistent";
            content = content.Insert(content.Length, $"\n {ex.Message}");
            File.WriteAllText("/Users/klebermirandalima/Projetos/PPFinancasBackend/Tests/Logs/LOG-ValidationsBankServices.PrintUpdateBankIdNonExistent.txt", content);
        }
    }

    public static class PrinterSuccessExpenseServices
    {
        public static void UpgradeEntity(ExpenseEntity oldExpenses, ExpenseInputModel newExpenses)
        {
            string content = $"COMPARATIVO";
            content = content.Insert(content.Length, "\nREALIDADE:");
            content = content.Insert(content.Length, $"\nIdentificador: {oldExpenses.Id}");
            content = content.Insert(content.Length, $"\nNome: {oldExpenses.Name}");
            content = content.Insert(content.Length, $"\nData Compra: {oldExpenses.DatePurchase}");
            content = content.Insert(content.Length, $"\nData Primeiro Pagamento: {oldExpenses.DateFirstInstallment}");
            content = content.Insert(content.Length, $"\nData Último Pagamento: {oldExpenses.DateLastInstallment}");
            content = content.Insert(content.Length, "\n==================================================");

            oldExpenses.Installments.ToList().ForEach(item =>
            {

                content = content.Insert(content.Length, $"\n Número: {item.Number}");
                content = content.Insert(content.Length, $"\n ExpectedDate: {item.ExpectedDate}");
                content = content.Insert(content.Length, $"\n PaymentDate: {item.PaymentDate}");
                content = content.Insert(content.Length, "\n==================================================");

            });

            File.WriteAllText("/Users/klebermirandalima/Projetos/PPFinancasBackend/Tests/SuccessExpenseServices.txt", content);
        }

    }

}