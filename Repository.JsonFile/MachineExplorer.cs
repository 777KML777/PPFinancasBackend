namespace Repository.JsonFile;

public static class MachineExplorer
{
    public static string BankFileWindows { get; set; } = @"\JsonBank.json";
    public static string BankFileMac { get; set; } = @"/JsonBank.json";
    public static string ExpensesFileWindows { get; set; } = @"\JsonExpenses.json";
    public static string ExpensesFileMac { get; set; } = @"/JsonExpenses.json";
    public static string PaidInstallmentsFileWindows { get; set; } = @"\JsonPaidInstallments.json";
    public static string PaidInstallmentsFileMac { get; set; } = @"/JsonPaidInstallments.json";

    // Poderia ficar em um repositório genérico
    public static string PegarCaminhoDoArquivo (string repositoryFileMachine)
    {
        string enviroment = Environment.CurrentDirectory;
        string replaceProject = enviroment.Replace("Api", "Repository.JsonFile");
        string fullPath = replaceProject + repositoryFileMachine;

        return fullPath;
    }
    
}
