namespace Services.Dtos;

public class Progresso
{
    public DateTime DataCriacao { get; set; }
    public int QuantidadePendente { get; set; }
    public int PorcentagemPendente { get; set; }
    public int QuantidadeConcluida { get; set; }
    public int PorcentagemConcluida { get; set; }
    public string Nome { get; set; } = string.Empty;
    public List<ItemProgresso> Itens { get; set; } = new();

    // Uma tarefa / ItemProgresso teria que ter vinculado a ele as abordagens. 
    // Para representar de maneira rápida eu deveria ter uma lista de progresso. 
    public void Calcular()
    {
        QuantidadeConcluida = Itens.Count(x => x.Concluido);
        QuantidadePendente = Itens.Count(x => !x.Concluido);

        PorcentagemConcluida = (int)Math.Round((decimal)100 * QuantidadeConcluida / Itens.Count);
        PorcentagemPendente = 100 - PorcentagemConcluida;
    }
}

public class ItemProgresso
{
    public int Ordem { get; set; } // Não se repete. 
    public int Prioridade { get; set; } // Esse número se repete e tem maior peso que a ordem.
    public bool Concluido { get; set; }
    public int Dificuldade { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Importancia { get; set; } = string.Empty;
    public string MotivoRelevancia { get; set; } = string.Empty;
}


// Desenvolvimento Necessário - Refactor
// Criar Banco 
// definir o que será inserindo ao criar o banco. 
// Exibir Dashboard
// Atualizar Banco 
// Atualizar Despesa