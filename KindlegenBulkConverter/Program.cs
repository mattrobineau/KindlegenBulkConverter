using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace KindlegenBulkConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Usage: KindlegenBulkConverter.exe [c:/path/to/file.pdf] [c:/path/to/*.pdf]");
                Console.WriteLine("Supports wild cards for files.");
                return;
            }

            List<string> files = new List<string>();

            foreach (var arg in args)
            {
                if (arg.Contains("*"))
                {
                    var location = arg.Split('*');
                    var directory = location[0];

                    if (string.IsNullOrEmpty(directory))
                    {
                        directory = ".\\";
                    }

                    if (!Directory.Exists(directory))
                    {
                        Console.WriteLine($"Directory not found. {directory}");
                        return;
                    }

                    files.AddRange(Directory.GetFiles(directory, $"*{location[1]}"));

                    if (files.Count < 1)
                    {
                        Console.WriteLine($"No files found. {arg}");
                        return;
                    }
                }
                else
                {
                    if (!File.Exists(arg))
                    {
                        Console.WriteLine($"File not found. {arg}");
                        return;
                    }

                    files.Add(arg);
                }

                foreach (var file in files)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\kindlegen.exe";
                    p.StartInfo.Arguments = $"\"{file}\"";
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.Start();

                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();

                    Console.WriteLine("Output:");
                    Console.WriteLine(output);
                }
            }
        }
    }
}
