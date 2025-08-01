using Application.Dtos;
using Application.Models;
using Application.Services;
using Tests.Printers;

namespace Tests.T3_Services.Success;

public class SuccessBankServices
{
    BankServices _services = new();
    ExpenseServices _expenseServices = new();

    [Fact]
    public void CalculandoMeses()
    {
        // Calcula meses 
        // Multiplica a diferença dos anos por 12. 
        // Se 0 = Subtrai os meses. Se der negativo transforme em positivo. Posito permanece. 
        // Pega a diferença anual - a diferença dos meses 

        // Na verdade eu quero saber o tanto de meses entre uma data e outra.
        var primeiraDataCompara = new DateTime(2024, 03, 7);
        var ultimaDataCompra = new DateTime(2025, 06, 7);
        // var ultimaDataCompra2 = new DateTime(2025, 01, 7);

        var diferencaAnual = ultimaDataCompra.Year - primeiraDataCompara.Year;
        var diferencaMensal = ultimaDataCompra.Month - primeiraDataCompara.Month;
        var qtdFatura = 0;
        var qtdMeses = diferencaAnual + diferencaMensal;

        if (diferencaAnual >= 0)
            qtdFatura = qtdMeses > 0 ? (12 * diferencaAnual) + qtdMeses : 0;
        else
            qtdFatura = 0;

        // 1 * 12 = 12 + 3 = 15
        // 1 * 12 = 12 - 2 = 10


        string content = $"LOG";
        content = content.Insert(content.Length, $"\nResultado: {qtdFatura}");
        File.WriteAllText
        (
            "/Users/klebermirandalima/Projetos/PPFinancasBackend/Tests/Logs/LOG-CalculandoMeses.txt",
             content
        );
    }
    [Fact]
    public void EquivalenteAoDateTimeCompare()
    {
        var dtMenor = DateTime.Now.AddMonths(-1);
        var dtMaior = DateTime.Now;
        var verificando = DateTime.Now.AddMonths(12);

        var resultado = dtMaior > dtMenor;

        string content = $"LOG";
        content = content.Insert(content.Length, $"\nResultado: {resultado}");
        content = content.Insert(content.Length, $"\nVerificando: {verificando}");
        File.WriteAllText
        (
            "/Users/klebermirandalima/Projetos/PPFinancasBackend/Tests/Logs/LOG.txt",
             content
        );
    }
    [Fact]
    public void Update()
    {
        // Selecionar o número da parcela. 
        // Se a lista estiver vazia então eu faço nada. 
        BankServices bankService = new();
        BankInputModel bank = new BankInputModel { Name = "BankOfTestUpgraded", Balance = 0.01M, Id = 777 };

        if (bankService.Update(bank)) // É para atualizar o banco junto das despesas?
            Printer.PrinterSuccessBankServices.UpdateBank(null, bank);

    }

    [Fact]
    public void GetByIdInclude()
    {
        BankDto bank = _services.GetById(2, true); // Id = 2 Banco Santander.
        // Mostrar as faturas funcionando aqui. 

        Printer.PrinterSuccessBankServices.GetByIdInclude(bank);
    }

}