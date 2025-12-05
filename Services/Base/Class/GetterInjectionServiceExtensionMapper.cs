namespace Services.Base.Class;

/// <summary>
/// Essa classe base é responsável por simular uma injeção para as classes de extensões. <br/>
///  Classes estáticas de extensões não podem ser injetadas. 
/// </summary>
public static class GetterInjectionServiceExtensionMapper
{
    internal static IBankServicesMapper? _bankServicesMapper;
    internal static IExpenseServicesMapper? _expenseServicesMapper;
    internal static IExtratoServicesMapper? _extratoServicesMapper;
    public static void Constructor(this WebApplication builder)
    {
        using var scope = builder.Services.CreateScope();
        {
            _bankServicesMapper = scope.ServiceProvider.GetRequiredService<IBankServicesMapper>();
            _expenseServicesMapper = scope.ServiceProvider.GetRequiredService<IExpenseServicesMapper>();
            _extratoServicesMapper = scope.ServiceProvider.GetRequiredService<IExtratoServicesMapper>();
        }

    }
}