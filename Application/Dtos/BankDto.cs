using System.Reflection.Metadata.Ecma335;

namespace Application.Dtos;

public class BankDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public int DiaPagamento { get; set; }
    public int CountExpenses { get; set; }
    public decimal FinalBalance { get; set; }
    public decimal TotalExpenses { get; set; }
    public DateTime DataPagamento { get; set; }
    public List<ExtratoDto> Extratos { get; set; } = new();
    public List<ExpenseDto> Expenses { get; set; } = new List<ExpenseDto>();
    public FaturaDoBancoDto FaturaDoBanco { get; set; } = new FaturaDoBancoDto();
    public List<LancamentoDto> Lancamentos { get; set; } = new List<LancamentoDto>();
    public void CalculateFinalBalance() =>
        FinalBalance = Balance - TotalExpenses;

    public void CalculaLancamento()
    {
        int iteracao = 1;
        while (iteracao <= FaturaDoBanco.TotalDeFaturas)
        {
            Lancamentos.Add
            (
                new LancamentoDto(FaturaDoBanco.MenorDataFatura, iteracao)
            );

            iteracao++;
        }
    }

    public class FaturaDoBancoDto
    {
        public FaturaDoBancoDto()
        {

        }

        public DateTime MenorDataFatura { get; set; }
        public DateTime MaiorDataFatura { get; set; }
        public int TotalDeFaturas { get; set; } // Se tiver 1 parcela com o Tipo TempoIndeterminado somar + 1 aqui com base no valor da parcela que tiver a maior data da última parcela.
        public List<FaturaDto> Faturas { get; set; } = new List<FaturaDto>();


        // Criar um switch case para esse cara
    }

    public class LancamentoDto
    {
        public LancamentoDto(DateTime menorData, int mesLancamento)
        {
            MesLancamento = mesLancamento;

            if (mesLancamento == 1)
            {
                DataLancamento =
                    DataLancamento.Replace("mes", RetornaMes(menorData.Month))
                    .Replace("ano", menorData.Year.ToString());

            }
            else
            {
                DataLancamento =
                  DataLancamento.Replace("mes", RetornaMes(menorData.AddMonths(mesLancamento - 1).Month))
                  .Replace("ano", menorData.AddMonths(mesLancamento - 1).Year.ToString());
            }
        }
        public int MesLancamento { get; set; }
        public string DataLancamento { get; set; } = "mes/ano";

        static string RetornaMes(int numeroMes)
        {
            string mes = "";

            switch (numeroMes)
            {
                case 1:
                    mes = "JAN";
                    break;
                case 2:
                    mes = "FEV";
                    break;
                case 3:
                    mes = "MAR";
                    break;
                case 4:
                    mes = "ABR";
                    break;
                case 5:
                    mes = "MAI";
                    break;
                case 6:
                    mes = "JUN";
                    break;
                case 7:
                    mes = "JUL";
                    break;
                case 8:
                    mes = "AGO";
                    break;
                case 9:
                    mes = "SET";
                    break;
                case 10:
                    mes = "OUT";
                    break;
                case 11:
                    mes = "NOV";
                    break;
                case 12:
                    mes = "DEZ";
                    break;

                default:
                    mes = "mes";
                    break;
            }

            return mes;
        }

    }
    public class FaturaDto
    {
        public FaturaDto()
        {

        }
        public string Nome { get; set; }
        public int NumeroParcela { get; set; }
        public int MesLancamento { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorParcela { get; set; }
        public int QuantidadeTotalParcelas { get; set; }
    }
}