namespace Repository.Json;

public static class MachineExplorer
{
    public static string GetFilePath(string nameRepository)
    {
        string file = "";

        if (OperatingSystem.IsMacOS())
            file = @"/" + nameRepository + ".json"/* "Data.json" */;
        else if (OperatingSystem.IsWindows())
            file = @"\" + nameRepository /* + "Data.json" */;

        // var x = Environment.SystemDirectory;
        // var x2 = Environment.CommandLine;

        string environment = Environment.CurrentDirectory;
        // var z = typeof(EndOfStreamException ).Assembly.FullName;  
        // string replaceProject = environment.Replace("/bin/Debug/net7.0", ""); /* TestProject */
        string replaceProject = environment.Replace("/Api", "/Repository.Json");
        string fullPath = replaceProject + file;

        return fullPath;
    }
}
