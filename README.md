# COD File Cleaner & Optimizer

A modular C# tool (built for NativeAOT) designed to clean up and revert game directories by siphoning specific file types (videos, fastfiles, paks) into secondary storage folders. This helps in reducing the active game footprint or managing files for modding and localization purposes.

## 🚀 Features

- **Modular Architecture**: Uses an inheritance-based system (`Base.cs`) allowing for easy addition of new games.
- **Intelligent Siphoning**: Automatically detects and separates `.bik` video files from language data folders.
- **Safe Reversion**: A comprehensive "Undo" feature that restores the original game directory structure perfectly.
- **Case-Sensitive Handling**: Correctly handles language folder casing (e.g., `English` vs `english`) via property overrides.
- **Robust Error Handling**: Prevents crashes using directory existence checks and safe file move operations.
- **Color-Coded CLI**: High-visibility feedback using a custom `WriteColor` helper for success, warnings, and errors.

## 📁 Project Structure

- **`Base.cs`**: Contains the core logic, folder constants, and virtual properties.
- **`Games/`**: Contains game-specific overrides (e.g., `IW7.cs` for Infinite Warfare).
- **`Helpers.cs`**: Static utility methods for file moving, directory cleanup, and console styling.

## 🛠 Usage

1. **Select Game**: Run the application and choose the game module you wish to process.
2. **Clean [Option 1]**:

- Creates a `zone` and `raw/video` structure.
- Moves main directory extensions (`.ff`, `.pak`, etc.) to the `zone` folder.
- Scans language folders (e.g., `English`) and separates videos into `raw/video/LanguageName` while moving data to `zone/LanguageName`.

3. **Revert [Option 2]**:

- Pulls all files from the storage folders back to the root.
- Merges split language data and videos back into their original folders.
- Deletes empty storage directories to leave the game folder exactly as it was found.

## 💻 Implementation Example (S1)

To add a new game or modify casing, simply override the base properties:

```csharp
public override string WELCOME_MESSAGE => "COD: Advanced Warfare Cleaner";
public override string ENGLISH_FOLDER => "English"; // Ensures uppercase "E"

```

## ⚠️ Safety Measures

- **Empty Folder Protection**: The tool will only delete directories if they are completely empty to prevent data loss.
- **State Detection**: Checks for essential game files before running the cleaning process to prevent duplicate moves.
- **Overwrite Safety**: If a file already exists at the destination during a move, the tool clears the conflict before proceeding.

## 🔧 Requirements

- .NET 10.0 SDK or higher
