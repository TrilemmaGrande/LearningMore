namespace Beispiel.FileManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BeispielWatcher();
        }
        static void BeispielWatcher()
        {
            string path = Directory.GetCurrentDirectory();

            using (FileSystemWatcher watcher = new FileSystemWatcher(path))
            {
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
                watcher.Created += Watcher_Event;
                watcher.Renamed += Watcher_Event;
                watcher.Changed += Watcher_Event;
                watcher.Deleted += Watcher_Event;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Watcher gestartet ....");
                Console.ReadLine();
            }
        }
        static void Watcher_Event(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} => {e.ChangeType}");
        }
        static void BeispielFile()
        {
            string path = Directory.GetCurrentDirectory();
            string filename = path + "\\testfile.txt";

            File.WriteAllText(filename, "Hallo\n");

            File.AppendAllText(filename, "Ein wenig Text ...");

            string gelesen = File.ReadAllText(filename);
            Console.WriteLine(gelesen);
        }
        static void BeispielDirectoryInfo()
        {
            string path = Directory.GetCurrentDirectory();
            path += @"\Testverzeichnis";

            DirectoryInfo di = new DirectoryInfo(path);

            if (di.Exists)
            {
                Console.WriteLine("Verzeichnis existiert schon");
            }
            else
            {
                di.Create();
                di.CreateSubdirectory("NochEinTest");
                FileSystemInfo[] infos = di.GetFileSystemInfos();

                foreach (FileSystemInfo fsi in infos)   
                {
                    Console.WriteLine(fsi.FullName);
                }
                Console.ReadLine();

                di.Delete(true);
            }
        }
        static int ListFileSystem(string path, int counter = 0)
        {
            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    counter++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(counter + " " + dir);
                    Console.ResetColor();
                    counter = ListFileSystem(dir, counter);
                }
                foreach (string file in Directory.GetFiles(path))
                {
                    counter++;
                    Console.WriteLine(counter + " " + file);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return counter;
        }
        static void BeispielDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string[] entries = Directory.GetFileSystemEntries(currentDir);

            foreach (string entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        static void BeispielDrives()
        {
            DriveInfo[] di = DriveInfo.GetDrives();

            foreach (DriveInfo drive in di)
            {
                Console.WriteLine($"Drive: {drive.Name}");
                Console.WriteLine($" FileType: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($" Label: {drive.VolumeLabel}");
                    Console.WriteLine($" Filesystem: {drive.DriveFormat}");
                    Console.WriteLine($" FreeSpace: {drive.TotalFreeSpace}");
                    Console.WriteLine($" TotalSize: {drive.TotalSize}");
                }
            }
        }
    }
}