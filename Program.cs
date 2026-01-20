using FileCleaner.Games;

namespace FileCleaner;

class Program
{
    private static readonly Base[] SupportedGames =
    [
        new IW7()
    ];

    private static Base? DetectGame()
    {
        string root = AppDomain.CurrentDomain.BaseDirectory;

        foreach (var game in SupportedGames)
        {
            if (game.GAME_EXECUTABLES.Any(exe => File.Exists(Path.Combine(root, exe))))
            {
                return game;
            }
        }
        return null;
    }

    static async Task Main(string[] args)
    {
        Console.Title = "File Cleaner";

        Console.WriteLine("Detecting Game...");

        var game = DetectGame();

        if (game == null)
        {
            Console.WriteLine("No Supported Game Found!\nMake sure you put the exe in the correct game folder");
            Console.ReadKey();
            return;
        }

        await game.Process();
    }
}
