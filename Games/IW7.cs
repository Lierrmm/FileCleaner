namespace FileCleaner.Games
{
    public class IW7 : Base
    {
        public override string WELCOME_MESSAGE => "COD: Infinite Warfare Cleaner";
        public override string[] GAME_EXECUTABLES { get; } = { "iw7_ship.exe" };

        public override async Task Process()
        {
            RUNNING = true;
            while (RUNNING)
            {
                Helpers.WriteColor(WELCOME_MESSAGE);
                Helpers.WriteColor("[1] Clean Game Files");
                Helpers.WriteColor("[2] Revert Cleaning");
                Helpers.WriteColor("[Q] Quit", ConsoleColor.DarkGray);

                var choice = Console.ReadLine()?.ToUpperInvariant();

                switch (choice)
                {
                    case "1":
                        await CleanGameFiles();
                        break;
                    case "2":
                        await RevertCleaning();
                        break;
                    case "Q":
                        RUNNING = false;
                        break;
                    default:
                        Helpers.WriteColor("Not a Valid Choice!\n", ConsoleColor.Red);
                        break;
                }
            }
        }

        private async Task CleanGameFiles()
        {
            if (!File.Exists(COMMON_MP_FASTFILE) || !File.Exists(COMMON_FASTFILE))
            {
                Helpers.WriteColor("Your game is already clean!\nIf not, make sure you have put the file in the correct game folder.\n", ConsoleColor.Yellow);
                return;
            }

            Helpers.EnsureDirectoriesExist([ZONE_FOLDER,
                RAW_FOLDER,
                RAW_VIDEO_FOLDER,
                CLEAN_ZONE_FOLDER,
                CLEAN_RAW_VIDEO_FOLDER]);

            var fileTypeMap = new Dictionary<string, string>
            {
                { FASTFILE_EXTENSION, CLEAN_ZONE_FOLDER },
                { PAK_EXTENSION,      CLEAN_ZONE_FOLDER },
                { SABL_EXTENSION,     CLEAN_ZONE_FOLDER },
                { SABS_EXTENSION,     CLEAN_ZONE_FOLDER },
                { BIK_EXTENSION,      CLEAN_RAW_VIDEO_FOLDER }
            };

            foreach (var entry in fileTypeMap)
            {
                string[] files = Directory.GetFiles("./", entry.Key);
                if (files.Length > 0)
                {
                    Helpers.MoveFileTo(files, entry.Value);
                }
            }

            MoveLanguageFolders(isReverting: false);
            Helpers.WriteColor("Finished Processing Files\n", ConsoleColor.Green);
        }

        private void MoveLanguageFolders(bool isReverting)
        {
            var folderMap = new Dictionary<string, string>
            {
                { ENGLISH_FOLDER, ENGLISH_ZONE_FOLDER },
                { ENGLISH_SAFE_FOLDER, ENGLISH_SAFE_ZONE_FOLDER },
                { FRENCH_FOLDER, FRENCH_ZONE_FOLDER },
                { GERMAN_FOLDER, GERMAN_ZONE_FOLDER },
                { RUSSIAN_FOLDER, RUSSIAN_ZONE_FOLDER },
                { POLISH_FOLDER, POLISH_ZONE_FOLDER },
                { JAPAN_FOLDER, JAPAN_ZONE_FOLDER },
                { KOREAN_FOLDER, KOREAN_ZONE_FOLDER },
                { PORTUGUESE_FOLDER, PORTUGUESE_ZONE_FOLDER },
                { SPANISH_FOLDER, SPANISH_ZONE_FOLDER },
                { ITALIAN_FOLDER, ITALIAN_ZONE_FOLDER },
                { SCHINA_FOLDER, SCHINA_ZONE_FOLDER },
                { TCHINA_FOLDER, TCHINA_ZONE_FOLDER }
            };

            foreach (var entry in folderMap)
            {
                try
                {
                    string source = isReverting ? entry.Value : entry.Key;
                    string dest = isReverting ? entry.Key : entry.Value;
                    Helpers.MoveDirectoryTo(source, dest);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        private async Task RevertCleaning()
        {
            Helpers.WriteColor("Reverting Game Files...", ConsoleColor.Cyan);

            string[] sourceFolders = { CLEAN_ZONE_FOLDER, CLEAN_RAW_VIDEO_FOLDER };

            foreach (var folder in sourceFolders)
            {
                if (Directory.Exists(folder))
                {
                    var files = Directory.GetFiles(folder, "*.*");
                    if (files.Length > 0)
                    {
                        Helpers.MoveFileTo(files, "./");
                    }
                }
            }

            MoveLanguageFolders(isReverting: true);

            Helpers.TryCleanupDirectory(CLEAN_RAW_VIDEO_FOLDER);
            Helpers.TryCleanupDirectory(RAW_VIDEO_FOLDER);
            Helpers.TryCleanupDirectory(RAW_FOLDER);
            Helpers.TryCleanupDirectory(CLEAN_ZONE_FOLDER);
            Helpers.TryCleanupDirectory(ZONE_FOLDER);

            Helpers.WriteColor("Done Reverting Files\n", ConsoleColor.Green);
        }
    }
}
