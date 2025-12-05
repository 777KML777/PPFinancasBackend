namespace Infra.Data.Base.Class;

/// <summary>
/// Essa classe base é responsável por simular uma injeção para as classes de extensões. <br/>
///  Classes estáticas de extensões não podem ser injetadas. 
/// </summary>
public static class GetterInjectionRepositoryExtensionMapper
{
    internal static IBankRepositoryMapper? _bankRepositoryMapper;
    internal static IExpenseRepositoryMapper? _expenseRepositoryMapper;
    internal static IExtratoRepositoryMapper? _extratoRepositoryMapper;
    public static void Constructor(this WebApplication builder)
    {
        using var scope = builder.Services.CreateScope();
        {
            _bankRepositoryMapper = scope.ServiceProvider.GetRequiredService<IBankRepositoryMapper>();
            _expenseRepositoryMapper = scope.ServiceProvider.GetRequiredService<IExpenseRepositoryMapper>();
            _extratoRepositoryMapper = scope.ServiceProvider.GetRequiredService<IExtratoRepositoryMapper>();
        }

    }
}