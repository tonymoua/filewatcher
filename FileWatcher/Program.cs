/*Tony Moua
 *File System Watcher: Run from Command Prompt. After compile run: program.cs followed by a path you desire
 *
 * using FileSystemWatcher watch what is happening to folders and files within the path that has been selected by user
 *report back to the console and log file what is being done. 
*/
using System;
using System.IO;
using System.Security.Permissions;

namespace FileWatcher
{
    class Program
    {
        public static void Main()
        {
            Run();

        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            string[] args = System.Environment.GetCommandLineArgs();

            if (args.Length != 2)
            {
                Console.WriteLine("Usage: Watcher.exe (directory)");
                return;
            }
            string path = args[1];

            while (!Directory.Exists(path))
            {
                Console.WriteLine("Re-enter path please: ");
                path = Console.ReadLine();
            }

            Console.WriteLine("PASS the Reprompt");
            Console.WriteLine(path);
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Filter = "*.*";

            // handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            //quit the program.
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        // Define handlers. 
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            using (StreamWriter w = File.AppendText("logfile.txt"))
            //when a file is changed, created, or deleted.
            w.WriteLine("File: "+e.Name + " Path:" + e.FullPath + " " + e.ChangeType + " Time: " + DateTime.Now);
            Console.WriteLine("File: " + e.Name + " Path:" + e.FullPath + " " + e.ChangeType + " Time: " + DateTime.Now);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            using (StreamWriter w = File.AppendText("logfile.txt"))
            //when a file is renamed.
            w.WriteLine("File: {0} renamed to {1}, Date/time {2}", e.OldFullPath, e.FullPath, DateTime.Now);
            Console.WriteLine("File: {0} renamed to {1}, Date/time {2}", e.OldFullPath, e.FullPath, DateTime.Now);
        }
    }
}
