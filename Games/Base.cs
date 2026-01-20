namespace FileCleaner.Games
{
    public class Base
    {
        public virtual string WELCOME_MESSAGE { get; } = "COD Files Cleaner";

        // Games
        public virtual string[] GAME_EXECUTABLES { get; } = [];

        // Extensions
        public virtual string FASTFILE_EXTENSION { get; } = "*.ff";
        public virtual string BIK_EXTENSION { get; } = "*.bik";
        public virtual string PAK_EXTENSION { get; } = "*.pak";
        public virtual string SABL_EXTENSION { get; } = "*.sabl";
        public virtual string SABS_EXTENSION { get; } = "*.sabs";
        public virtual string CLEAN_FASTFILE_EXTENSION { get; } = "zone/*.ff";
        public virtual string CLEAN_BIK_EXTENSION { get; } = "raw/video/*.bik";
        public virtual string CLEAN_PAK_EXTENSION { get; } = "zone/*.pak";
        public virtual string CLEAN_SABL_EXTENSION { get; } = "zone/*.sabl";
        public virtual string CLEAN_SABS_EXTENSION { get; } = "zone/*.sabs";

        // Default Files
        public virtual string COMMON_MP_FASTFILE { get; } = "patch_common_mp.ff";
        public virtual string COMMON_FASTFILE { get; } = "patch_common.ff";

        // Folders
        public virtual string ZONE_FOLDER { get; } = ".\\zone";
        public virtual string RAW_FOLDER { get; } = ".\\raw";
        public virtual string RAW_VIDEO_FOLDER { get; } = ".\\raw\\video";
        public virtual string CLEAN_ZONE_FOLDER { get; } = "zone";
        public virtual string CLEAN_RAW_VIDEO_FOLDER { get; } = "raw\\video";

        // Languages
        public virtual string ENGLISH_FOLDER { get; } = "english";
        public virtual string ENGLISH_SAFE_FOLDER { get; } = "english_safe";
        public virtual string FRENCH_FOLDER { get; } = "french";
        public virtual string GERMAN_FOLDER { get; } = "german";
        public virtual string RUSSIAN_FOLDER { get; } = "russian";
        public virtual string POLISH_FOLDER { get; } = "polish";
        public virtual string JAPAN_FOLDER { get; } = "japanese_partial";
        public virtual string KOREAN_FOLDER { get; } = "korean";
        public virtual string PORTUGUESE_FOLDER { get; } = "portuguese";
        public virtual string SPANISH_FOLDER { get; } = "spanish";
        public virtual string ITALIAN_FOLDER { get; } = "italian";
        public virtual string SCHINA_FOLDER { get; } = "simplified_chinese";
        public virtual string TCHINA_FOLDER { get; } = "traditional_chinese";

        // Language Folders
        public virtual string ENGLISH_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, ENGLISH_FOLDER);
        public virtual string ENGLISH_SAFE_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, ENGLISH_SAFE_FOLDER);
        public virtual string FRENCH_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, FRENCH_FOLDER);
        public virtual string GERMAN_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, GERMAN_FOLDER);
        public virtual string RUSSIAN_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, RUSSIAN_FOLDER);
        public virtual string POLISH_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, POLISH_FOLDER);
        public virtual string JAPAN_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, JAPAN_FOLDER);
        public virtual string KOREAN_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, KOREAN_FOLDER);
        public virtual string PORTUGUESE_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, PORTUGUESE_FOLDER);
        public virtual string SPANISH_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, SPANISH_FOLDER);
        public virtual string ITALIAN_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, ITALIAN_FOLDER);
        public virtual string SCHINA_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, SCHINA_FOLDER);
        public virtual string TCHINA_ZONE_FOLDER => Path.Combine(CLEAN_ZONE_FOLDER, TCHINA_FOLDER);

        public virtual async Task Process()
        {
            Console.WriteLine("Cannot use Base Class to Process");
        }
    }
}
