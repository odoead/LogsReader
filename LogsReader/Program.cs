using LogsReader.Interfaces;
using System.IO;
using System.Reflection.PortableExecutable;

namespace LogsReader
{
    class MyClassCS
    {
        static void Main()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher("\\logs"))
            {

                watcher.NotifyFilter = NotifyFilters.Attributes
                                     | NotifyFilters.CreationTime
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.FileName
                                     | NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.Security
                                     | NotifyFilters.Size;
                watcher.Changed += (sender, e) => OnChanged(sender, e);
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            IReader reader = new LastLineReader();
            IHandler handler = new ChatGameHandler();
            IWriter writer = new ConsoleWriter();
            writer.Write($"{DateTime.Now.Second}|{DateTime.Now.Millisecond}|Handled:" +
                $" {handler.Handle(reader.Read("\\logs\\log.log"),@"§a(.*?)§c")}");
        }
        
    }
}