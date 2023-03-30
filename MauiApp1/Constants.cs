namespace MauiApp1;

public static class Constants
{
    public const string DatabaseFileName = "ToDo.db3";
    public const SQLite.SQLiteOpenFlags Flags =
             SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath => 
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFileName);

}
