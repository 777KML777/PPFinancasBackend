namespace StorageContextJson;

public static class MachineExplorer
{
    public static string GetFilePath(string nameRepository)
    {
        string file = "";

        if (OperatingSystem.IsMacOS())
            file = @"/" + nameRepository + ".json"/* "Data.json" */;
        else if (OperatingSystem.IsWindows())
            file = @"\" + nameRepository + ".json";

        // var x = Environment.SystemDirectory;
        // var x2 = Environment.CommandLine;

        string environment = Environment.CurrentDirectory;
        // var z = typeof(EndOfStreamException ).Assembly.FullName;  
        // string replaceProject = environment.Replace("/bin/Debug/net7.0", ""); /* TestProject */
        string replaceProject = environment.Replace("Api", "StorageContextJson");
        string fullPath = replaceProject + file;

        return fullPath;
    }
}
