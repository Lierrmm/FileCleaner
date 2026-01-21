namespace FileCleaner
{
    public class Helpers
    {
        public static void WriteColor(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void MoveFileTo(string[] files, string to)
        {
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                WriteColor($"Moving {fileName} to {to}", ConsoleColor.Cyan);
                File.Move(file, Path.Combine(to, fileName));
            }
        }

        public static void MoveDirectoryTo(string directory, string to)
        {
            if (Directory.Exists(directory))
            {
                Directory.Move(directory, to);
            }
        }

        public static void EnsureDirectoriesExist(string[] requiredFolders)
        {
            foreach (var folder in requiredFolders)
            {
                if (!Directory.Exists(folder))
                {
                    WriteColor($"Creating Folder: {folder}", ConsoleColor.Cyan);
                    Directory.CreateDirectory(folder);
                }
            }
        }

        public static void MoveSpecificFiles(string sourceDir, string destDir, string pattern)
        {
            if (!Directory.Exists(sourceDir)) return;
            if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);

            string[] files = Directory.GetFiles(sourceDir, pattern);
            foreach (var file in files)
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                if (File.Exists(destFile)) File.Delete(destFile);
                File.Move(file, destFile);
            }
        }

        public static void TryCleanupDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    if (!Directory.EnumerateFileSystemEntries(path).Any())
                    {
                        Directory.Delete(path);
                        WriteColor($"Removed empty directory: {path}", ConsoleColor.Cyan);
                    }
                    else
                    {
                        WriteColor($"Skipped directory (not empty): {path}", ConsoleColor.Cyan);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cleaning up {path}: {ex.Message}");
            }
        }
    }
}
