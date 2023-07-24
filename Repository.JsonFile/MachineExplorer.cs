namespace Repository.JsonFile;

public static class MachineExplorer
{
    public static string ExpensesFileWindows { get; set; } = @"\JsonExpenses.json";
    public static string ExpensesFileMac { get; set; } = @"/JsonExpenses.json";
    public static string PaidInstallmentsFileWindows { get; set; } = @"\JsonPaidInstallments.json";
    public static string PaidInstallmentsFileMac { get; set; } = @"/JsonPaidInstallments.json";
}
