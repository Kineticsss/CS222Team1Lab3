using System;
using System.Collections.Generic;
using System.IO;

public class Diary
{
    private string filePath = "diary.txt";

    public Diary()
    {
        EnsureFileExists();
    }

    private void EnsureFileExists()
    {
        if (!File.Exists(filePath))
        {
            using (File.Create(filePath)) { }
        }
    }

    public virtual void WriteEntry(string text)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            writer.WriteLine($"{timestamp} | {text}");
        }
    }

    public virtual List<string> ViewAllEntries()
    {
        List<string> entries = new List<string>();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                entries.Add(line);
            }
        }
        return entries;
    }
}