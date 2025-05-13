

void Esamina(DirectoryInfo dir, int livello = 0)
{
    FileInfo[]? files = null;
    DirectoryInfo[]? subDirs = null;

    LogDirectory(dir, livello);

    subDirs = dir.GetDirectories();
    foreach (var dirInfo in subDirs){
        Esamina(dirInfo, livello +1);
    }

    files = dir.GetFiles();

    foreach (var fi in files)
    {
        LogFile(fi, livello + 1);
    }
}

void LogDirectory(DirectoryInfo dirInfo, int livello)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine($"{GetSeparatore(livello)}{dirInfo.Name}");
    Console.ResetColor();
}
void LogFile(FileInfo fi, int livello)
{
    var oggi = DateTime.Now;
    var t = oggi.Subtract(fi.LastWriteTime).TotalMinutes;
    var dataModifica = $"({Math.Floor(t)} minuti fa)"; // 45 minuti fa
    if (t < 5){
        Console.ForegroundColor = ConsoleColor.Magenta;
    }
    else if (t < 30){
        Console.ForegroundColor = ConsoleColor.DarkYellow;
    }
    Console.WriteLine($"{GetSeparatore(livello)}{fi.Name} {dataModifica}");
}

string GetSeparatore(int livello)
{
    string s = "";
    for (int i = 0; i < livello; i++)
    {
        s += "|   ";
    }
    s += "|-- ";
    return s;
}
// var root = new DirectoryInfo(@"Desktop");
// Esamina(root);

Console.Write("Inserisci il percorso della cartella da scansionare:");
string? percorso = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(percorso) && Directory.Exists(percorso))
{
    var root = new DirectoryInfo(percorso);
    Esamina(root);
}
else {
    Console.WriteLine("Percorso non valido o cartella inesistente");
}