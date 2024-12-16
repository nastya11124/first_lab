using System;
using System.IO;

public class TemporaryFile : IDisposable
{
    public string FilePath { get; }

    public TemporaryFile()
    {
        FilePath = Path.GetTempFileName();
    }

    public void Dispose()
    {
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
        }
    }
}