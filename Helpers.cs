namespace FileCleaner
{
    public class Helpers
    {
        public static void MoveFileTo(string[] files, string to)
        {
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                Console.WriteLine($"Moving {fileName} to {to}");
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
    }
}
