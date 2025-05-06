using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SecureDiary diary = new SecureDiary();
        const string password = "Group 1"; //Password!!!!!!!!!!!!!!!!!!

        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- DIGITAL DIARY ---");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. View All Entries");
            Console.WriteLine("3. Search Entry by Date");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("\nEnter your diary entry (x to cancel): ");
                    string? text = Console.ReadLine();
                    if (text?.ToLower() == "x") break;

                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        diary.WriteEntry(text);
                        Console.WriteLine("\nEntry added.");
                    }
                    else
                    {
                        Console.WriteLine("\nEntry cannot be empty.");
                    }
                    break;

                case "2":
                    // Applied Security (Show encrypted entries first)
                    List<string> encryptedEntries = (diary as SecureDiary)?.GetEncryptedEntries() ?? diary.ViewAllEntries();

                    if (encryptedEntries.Count == 0)
                    {
                        Console.WriteLine("\nNo entries found.");
                        break;
                    }

                    Console.WriteLine("\n--- Encrypted Entries ---");
                    foreach (var entry in encryptedEntries)
                    {
                        Console.WriteLine(entry);
                    }

                    // Prompts for Password (To view the original entries)
                    Console.Write("\nEnter password to view decrypted entries (or 'x' to return): ");
                    string? inputPassword = Console.ReadLine();

                    if (inputPassword == null || inputPassword.ToLower() == "x")
                    {
                        //Return to Menu (Without decrypting the entries)
                        break;
                    }
                    else if (inputPassword == password)
                    {
                        //If password is correct (Show original entries)
                        List<string> decryptedEntries = diary.ViewAllEntries();
                        Console.WriteLine("\n--- Decrypted Entries ---");
                        foreach (var entry in decryptedEntries)
                        {
                            Console.WriteLine(entry);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect password. Returning to menu.");
                    }
                    break;

                case "3":
                    Console.Write("\nEnter password to search entries (or 'x' to cancel): ");
                    string? searchPassword = Console.ReadLine();

                    if (searchPassword == null || searchPassword.ToLower() == "x")
                    {
                        break;
                    }
                    else if (searchPassword != password) //Return to Menu (Since password is wrong)
                    {
                        Console.WriteLine("\nIncorrect password. Access denied.");
                        break;
                    }

                    Console.Write("\nEnter date (yyyy-MM-dd) (x to cancel): ");
                    string? date = Console.ReadLine();
                    if (date?.ToLower() == "x") break;

                    if (!string.IsNullOrWhiteSpace(date))
                    {
                        List<string> results = diary.SearchByDate(date);
                        if (results.Count == 0)
                        {
                            Console.WriteLine("\nNo entries found on that date.");
                        }
                        else
                        {
                            Console.WriteLine($"\n--- Entries on {date} ---");
                            foreach (var entry in results)
                            {
                                Console.WriteLine(entry);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid date input.");
                    }
                    break;

                case "4":
                    Console.WriteLine("\nExiting diary. Goodbye!");
                    return;

                default:
                    Console.WriteLine("\nInvalid choice. Try again.");
                    break;
            }

            Pause();
        }
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}