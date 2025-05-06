using System;
using System.Collections.Generic;

public class SecureDiary : Diary
{
    private int shift = 3;  // Caesar cipher shift

    public override void WriteEntry(string text)
    {
        string encrypted = Encrypt(text);
        base.WriteEntry(encrypted);
    }

    public override List<string> ViewAllEntries()
    {
        List<string> encryptedEntries = base.ViewAllEntries();
        List<string> decryptedEntries = new List<string>();

        foreach (string line in encryptedEntries)
        {
            int delimiter = line.IndexOf("|");
            if (delimiter > 0 && delimiter < line.Length - 1)
            {
                string timestamp = line.Substring(0, delimiter + 1);
                string encryptedMessage = line.Substring(delimiter + 1).Trim();
                string decryptedMessage = Decrypt(encryptedMessage);
                decryptedEntries.Add($"{timestamp} {decryptedMessage}");
            }
            else
            {
                decryptedEntries.Add(line);
            }
        }

        return decryptedEntries;
    }

    public List<string> GetEncryptedEntries()
    {
        return base.ViewAllEntries();
    }

    public List<string> SearchByDate(string date)
    {
        List<string> encryptedEntries = base.ViewAllEntries();
        List<string> filteredDecryptedEntries = new List<string>();

        foreach (string line in encryptedEntries)
        {
            int delimiter = line.IndexOf("|");
            if (delimiter > 0 && delimiter < line.Length - 1)
            {
                string timestamp = line.Substring(0, delimiter).Trim();
                // Validate Timestamp String Format (date format: yyyy-MM-dd)
                if (timestamp.StartsWith(date))
                {
                    string encryptedMessage = line.Substring(delimiter + 1).Trim();
                    string decryptedMessage = Decrypt(encryptedMessage);
                    filteredDecryptedEntries.Add($"{timestamp}| {decryptedMessage}");
                }
            }
        }

        return filteredDecryptedEntries;
    }

    private string Encrypt(string input)
    {
        char[] buffer = input.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            if (char.IsLetter(buffer[i]))
            {
                char offset = char.IsUpper(buffer[i]) ? 'A' : 'a';
                buffer[i] = (char)(((buffer[i] + shift - offset) % 26) + offset);
            }
        }
        return new string(buffer);
    }

    private string Decrypt(string input)
    {
        char[] buffer = input.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            if (char.IsLetter(buffer[i]))
            {
                char offset = char.IsUpper(buffer[i]) ? 'A' : 'a';
                buffer[i] = (char)(((buffer[i] - shift - offset + 26) % 26) + offset);
            }
        }
        return new string(buffer);
    }
}