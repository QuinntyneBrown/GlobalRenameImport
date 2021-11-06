using System.Collections.Generic;

namespace GlobalRenameImport.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = @"";
            var invalidToken = "";
            var validImport = "";


            foreach (var path in System.IO.Directory.GetFiles(directory, "*.scss", System.IO.SearchOption.AllDirectories))
            {
                var newLines = new List<string>();
                var writeRequired = false;


                foreach (var line in System.IO.File.ReadAllLines(path))
                {

                    if (line.Contains(invalidToken))
                    {
                        newLines.Add(validImport);
                        writeRequired = true;
                    }
                    else
                    {
                        newLines.Add(line);
                    }
                }

                if (writeRequired)
                {
                    System.IO.File.WriteAllLines(path, newLines.ToArray());
                }
            }
        }
    }
}
