namespace Services.Dtos;

public class FaturaDoBancoDto
{
    public FaturaDoBancoDto()
    {

    }

    // Se basear na quantidade de meses 
    // restantes no ano. 
    public int TotalDeFaturas { get; set; }
    public DateTime MenorDataFatura { get; set; }
    public DateTime MaiorDataFatura { get; set; }
    public List<FaturaDto> Faturas { get; set; } = new List<FaturaDto>();
}