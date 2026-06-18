namespace StorageContextJson;

public static class MachineExplorer
{
    public static string GetFilePath(string nameRepository)
    {
        nameRepository = "tb_" + nameRepository;
        string file = "";

        if (OperatingSystem.IsMacOS())
            file = @"/" + nameRepository + ".json";
        else if (OperatingSystem.IsWindows())
            file = @"\" + nameRepository + ".json";


        string environment = Environment.CurrentDirectory;

        // Em caso normal
        string replaceProject = OperatingSystem.IsWindows() ?
            environment.Replace(@"\Api", @"\StorageContextJson") :
            environment.Replace("/Api", "/StorageContextJson");

        // Em caso de testes
        // string replaceProject = environment.Replace("/bin/Debug/net7.0", ""); /* TestProject */

        // Em caso de publicação 
        replaceProject = OperatingSystem.IsWindows() ?
            replaceProject.Replace(@"\publish", @"\StorageContextJson") :
            replaceProject.Replace("/publish", "/StorageContextJson");

        string fullPath = replaceProject + file;

        return fullPath;
    }
}