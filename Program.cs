using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: SuppressIldasmAttribute()]
namespace listgit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"listgit starting at {DateTime.Now}..");
            var drives = new List<string>();
            if (args.Length == 0)
            {
                drives.AddRange(Directory.GetLogicalDrives());
                foreach (var drive in drives)
                {
                    try
                    {
                        var folders = new List<string>();
                        GetDirectories(drive, s => folders.Add(s));
                        foreach (var folder in folders)
                        {
                            try
                            {
                                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                                foreach (var folderGit in directoryInfo.GetDirectories(".git"))
                                {
                                    if (folderGit != null)
                                    {
                                        var configFile = Path.Combine(folderGit.FullName, "config");
                                        if (File.Exists(configFile))
                                        {
                                            //var file = File.OpenText(configFile);
                                            var fileLines = File.ReadAllLines(configFile);
                                            //fileText.Substring(fileText.IndexOf("[remote \"origin\"]")).Substring(fileText.Substring(fileText.IndexOf("[remote \"origin\"]")).IndexOf("[remote \"origin\"]\n\turl =") + 25
                                            var remoteMatch = false;
                                            foreach (var line in fileLines)
                                            {
                                                try
                                                {
                                                    if (line.Contains("[remote \"origin\"]"))
                                                    {
                                                        remoteMatch = true;
                                                        continue;
                                                    }
                                                    if (remoteMatch)
                                                    {
                                                        Console.WriteLine("folder = " + folderGit.FullName.Replace("\\.git", "") + "," + line);
                                                        remoteMatch = false;
                                                        break;
                                                    }
                                                }
                                                catch (System.UnauthorizedAccessException uac3)
                                                {
                                                    Console.BackgroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(uac3.Message);
                                                    Console.ResetColor();
                                                    continue;
                                                }
                                                catch (System.Exception e3)
                                                {
                                                    Console.BackgroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(e3.Message);
                                                    Console.ResetColor();
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (System.UnauthorizedAccessException uac2)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine(uac2.Message);
                                Console.ResetColor();
                                continue;
                            }
                            catch (System.Exception e2)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine(e2.Message);
                                Console.ResetColor();
                                continue;
                            }
                        }
                    }
                    catch (System.UnauthorizedAccessException uac)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(uac.Message);
                        Console.ResetColor();
                        continue;
                    }
                    catch (System.Exception e1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(e1.Message);
                        Console.ResetColor();
                        continue;
                    }
                }

            }
            else
            {
                if (args[0] == "*")
                {
                    drives.AddRange(Directory.GetLogicalDrives());
                }
                else
                {
                    drives.Add(new DriveInfo(args[0]).Name);
                }
                foreach (var drive in drives)
                {
                    try
                    {
                        var folders = new List<string>();
                        if (args[0] == "*")
                        {
                            GetDirectories(drive, s => folders.Add(s));
                        }
                        else
                        {
                            folders.Add(args[0]);
                        }
                        foreach (var folder in folders)
                        {
                            try
                            {
                                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                                foreach (var folderGit in directoryInfo.GetDirectories(".git"))
                                {
                                    if (folderGit != null)
                                    {
                                        var configFile = Path.Combine(folderGit.FullName, "config");
                                        if (File.Exists(configFile))
                                        {
                                            var fileLines = File.ReadAllLines(configFile);
                                            var remoteMatch = false;
                                            foreach (var line in fileLines)
                                            {
                                                try
                                                {
                                                    if (line.Contains("[remote \"origin\"]"))
                                                    {
                                                        remoteMatch = true;
                                                        continue;
                                                    }
                                                    if (remoteMatch)
                                                    {
                                                        remoteMatch = false;
                                                        if (args.Length == 2 && line.Contains(args[1]))
                                                        {
                                                            Console.WriteLine("folder = " + folderGit.FullName.Replace("\\.git", "") + "," + line);
                                                            Environment.Exit(0);
                                                        }
                                                        else if (args.Length == 1)
                                                        {
                                                            Console.WriteLine("folder = " + folderGit.FullName.Replace("\\.git", "") + "," + line);
                                                        }
                                                            break;
                                                    }
                                                }
                                                catch (System.UnauthorizedAccessException uac3)
                                                {
                                                    Console.BackgroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(uac3.Message);
                                                    Console.ResetColor();
                                                    continue;
                                                }
                                                catch (System.Exception e3)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(e3.Message);
                                                    Console.ResetColor();
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (System.UnauthorizedAccessException uac2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(uac2.Message);
                                Console.ResetColor();
                                continue;
                            }
                            catch (System.Exception e2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(e2.Message);
                                Console.ResetColor();
                                continue;
                            }
                        }
                    }
                    catch (System.UnauthorizedAccessException uac)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(uac.Message);
                        Console.ResetColor();
                        continue;
                    }
                    catch (System.Exception e1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e1.Message);
                        Console.ResetColor();
                        continue;
                    }
                }

            }
            Console.WriteLine($"listgit end at {DateTime.Now}");
        }

        static void GetDirectories(string path, Action<string> foundDirectory)
        {
            string[] dirs;
            try
            {
                dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            foreach (string dir in dirs)
            {
                foundDirectory(dir);
                GetDirectories(dir, foundDirectory);
            }
        }
    }
}
