namespace FileCleaner.Games
{
    public class IW7 : Base
    {
        public override string WELCOME_MESSAGE => "COD: Infinite Warfare Cleaner";
        public override string[] GAME_EXECUTABLES { get; } = { "iw7_ship.exe" };

        public override async Task Process()
        {
        Main:
            Console.WriteLine(WELCOME_MESSAGE);
            Console.WriteLine("[1] Clean Game Files");
            Console.WriteLine("[2] Revert Cleaning");
            var choice = Console.ReadLine();

            if (choice == null)
            {
                Console.WriteLine("Not a Valid Choice!");
                goto Main;
            }

            if (choice == "1")
            {
                string[] fastFiles = Directory.GetFiles("./", FASTFILE_EXTENSION);
                string[] bikFiles = Directory.GetFiles("./", BIK_EXTENSION);
                string[] pakFiles = Directory.GetFiles("./", PAK_EXTENSION);
                string[] sablFiles = Directory.GetFiles("./", SABL_EXTENSION);
                string[] sabsFiles = Directory.GetFiles("./", SABS_EXTENSION);

                if (!File.Exists(COMMON_MP_FASTFILE) || !File.Exists(COMMON_FASTFILE))
                {
                    Console.WriteLine("Your game is already clean!\nIf not, make sure you have put the file in the correct game folder.\n");
                    goto Main;
                }

                if (!Directory.Exists(ZONE_FOLDER))
                {
                    Console.WriteLine("Creating Zone Folder");
                    Directory.CreateDirectory(ZONE_FOLDER);
                }

                if (!Directory.Exists(RAW_FOLDER))
                {
                    Console.WriteLine("Creating Raw Folder");
                    Directory.CreateDirectory(RAW_FOLDER);
                }

                if (!Directory.Exists(RAW_VIDEO_FOLDER))
                {
                    Console.WriteLine("Creating Raw Video Folder");
                    Directory.CreateDirectory(RAW_VIDEO_FOLDER);
                }

                Helpers.MoveFileTo(fastFiles, CLEAN_ZONE_FOLDER);
                Helpers.MoveFileTo(pakFiles, CLEAN_ZONE_FOLDER);
                Helpers.MoveFileTo(sablFiles, CLEAN_ZONE_FOLDER);
                Helpers.MoveFileTo(sabsFiles, CLEAN_ZONE_FOLDER);
                Helpers.MoveFileTo(bikFiles, CLEAN_RAW_VIDEO_FOLDER);

                try
                {
                    Helpers.MoveDirectoryTo(ENGLISH_FOLDER, ENGLISH_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(ENGLISH_SAFE_FOLDER, ENGLISH_SAFE_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(FRENCH_FOLDER, FRENCH_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(GERMAN_FOLDER, GERMAN_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(RUSSIAN_FOLDER, RUSSIAN_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(POLISH_FOLDER, POLISH_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(JAPAN_FOLDER, JAPAN_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(KOREAN_FOLDER, KOREAN_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(PORTUGUESE_FOLDER, PORTUGUESE_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(SPANISH_FOLDER, SPANISH_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(ITALIAN_FOLDER, ITALIAN_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(SCHINA_FOLDER, SCHINA_ZONE_FOLDER);
                    Helpers.MoveDirectoryTo(TCHINA_FOLDER, TCHINA_ZONE_FOLDER);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Finished Processing Files\n");
                goto Main;
            }

            if (choice == "2")
            {
                string[] fastFiles = Directory.GetFiles("./", CLEAN_FASTFILE_EXTENSION);
                string[] bikFiles = Directory.GetFiles("./", CLEAN_BIK_EXTENSION);
                string[] pakFiles = Directory.GetFiles("./", CLEAN_PAK_EXTENSION);
                string[] sablFiles = Directory.GetFiles("./", CLEAN_SABL_EXTENSION);
                string[] sabsFiles = Directory.GetFiles("./", CLEAN_SABS_EXTENSION);

                Helpers.MoveFileTo(fastFiles, "./");
                Helpers.MoveFileTo(pakFiles, "./");
                Helpers.MoveFileTo(sablFiles, "./");
                Helpers.MoveFileTo(sabsFiles, "./");
                Helpers.MoveFileTo(bikFiles, "./");

                try
                {
                    Helpers.MoveDirectoryTo(ENGLISH_ZONE_FOLDER, ENGLISH_FOLDER);
                    Helpers.MoveDirectoryTo(ENGLISH_SAFE_ZONE_FOLDER, ENGLISH_SAFE_FOLDER);
                    Helpers.MoveDirectoryTo(FRENCH_ZONE_FOLDER, FRENCH_FOLDER);
                    Helpers.MoveDirectoryTo(GERMAN_ZONE_FOLDER, GERMAN_FOLDER);
                    Helpers.MoveDirectoryTo(RUSSIAN_ZONE_FOLDER, RUSSIAN_FOLDER);
                    Helpers.MoveDirectoryTo(POLISH_ZONE_FOLDER, POLISH_FOLDER);
                    Helpers.MoveDirectoryTo(JAPAN_ZONE_FOLDER, JAPAN_FOLDER);
                    Helpers.MoveDirectoryTo(KOREAN_ZONE_FOLDER, KOREAN_FOLDER);
                    Helpers.MoveDirectoryTo(PORTUGUESE_ZONE_FOLDER, PORTUGUESE_FOLDER);
                    Helpers.MoveDirectoryTo(SPANISH_ZONE_FOLDER, SPANISH_FOLDER);
                    Helpers.MoveDirectoryTo(ITALIAN_ZONE_FOLDER, ITALIAN_FOLDER);
                    Helpers.MoveDirectoryTo(SCHINA_ZONE_FOLDER, SCHINA_FOLDER);
                    Helpers.MoveDirectoryTo(TCHINA_ZONE_FOLDER, TCHINA_FOLDER);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    File.Delete("zone");
                    File.Delete("raw/video");
                    File.Delete("raw");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Done Reverting Files\n");
                goto Main;
            }

            goto Main;
        }
    }
}
