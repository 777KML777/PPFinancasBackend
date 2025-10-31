namespace Services.Dtos;

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