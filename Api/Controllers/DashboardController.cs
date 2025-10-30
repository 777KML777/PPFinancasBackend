namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DashboardController : ControllerBase
{

    private readonly DashboardAppServices _dashboardService;

    public DashboardController()
    {
        _dashboardService = new DashboardAppServices();
    }

    [HttpGet(Name = "dash-data")]
    public DashboardDto Get() =>
        _dashboardService.DashData();

    [HttpGet, Route("progress")]
    public Progresso Progresso() =>
        Criar();

    private static Progresso Criar()
    {
        // Fazer por etapas e ordem de criação. 
        // Fazer primeiro o simples. 
        // Mais necessário? 
        // Mais difícil? 

        Progresso progresso = new()
        {
            // Total de despesa tem que ser calculado com base nas despesas ativas e os pagamentos pendentes. 
            // Sugestão do que fazer e o que realmente foi feito. 
            Nome = "Corrigir Dashboard",
            Itens = new List<ItemProgresso>()
            {
                // Pendentes
                new() { Ordem = 2, Concluido = false, Nome = "Despesas Ativas", Descricao = "", Importancia = "Importante para preencher o card DTO.", },
                new() { Ordem = 3, Concluido = false, Nome = "Saldo Final", Descricao = "", Importancia = "Importante para preencher o card DTO.", },
                new() { Ordem = 1, Concluido = false, Nome = "Total Das Despesas", Descricao = "", Importancia = "Importante para preencher o card DTO.", },
                new() { Ordem = 6, Concluido = false, Nome = "Despesa Por Banco", Descricao = "", Importancia = "Eu consigo completar o card.", },
                new() { Ordem = 7, Concluido = false, Nome = "Parcelas Pagas", Descricao = "", Importancia = "Importante para preencher o card DTO.", },
                new() { Ordem = 4, Concluido = false, Nome = "Documentar Saldos", Descricao = "", Importancia = "Importante para preencher o card DTO.", },
                new() { Ordem = 5, Concluido = false, Nome = "Include?", Descricao = "", Importancia = "Importante para preencher o card DTO.", },
                new() { Ordem = 8, Concluido = false, Nome = "Usar Porcentagem Concluida", Descricao = "", Importancia = "Importante para preencher o card DTO.", },
                // Concluídos
                new() { Ordem = 6, Concluido = true, Nome = "Calcular Saldo Disponível", Descricao = "", Importancia = "Importante para preencher o card DTO.", }
            }
        };

        progresso.Calcular(); 
        return progresso;
    }
    // {
    //     // Posso dar um jeito aqui de retornar o banco. Ver Evento .NET e pegar ensinamentos desse evento 
    //     // Estou me distanciando muito do Backend - mas nesse momento faz-se um pouco necessário 
    //     // Futuramente ter a opção de criar o banco já com as despesas 

    //     _DashboardService.Create(obj); 
    // }
}