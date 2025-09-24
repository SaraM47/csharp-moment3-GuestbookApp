// This file contains Class that handles the list of posts and save/load
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Guestbook
{
    /*
    * Used a private list that holds all guestbook entries in memory. By using List<T> allows us to add and remove items easily.
    */
    private List<GuestbookEntry> entries = new List<GuestbookEntry>();
    private string filePath = "guestbook.json"; //Path to the file where we will store the guestbook data in JSON format.

    // This method prints all posts in the guestbook.
    public void ShowPosts()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Inga inlägg än.");
            return;
        }

        for (int i = 0; i < entries.Count; i++)
        {
            Console.WriteLine($"{i}: {entries[i]}");
        }
    }

    // This method allows the user to add a new post, which asks for both the owner's name and the message text.
    // Not allow empty input for the owner or message field.
    public void AddPosts()
    {
        Console.WriteLine("Ägare: ");
        string owner = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(owner))
        {
            Console.WriteLine("Uppstår ett fel: ägaren får inte vara tom!");
            return;
        }

        Console.WriteLine("Inlägg: ");
        string text = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Uppstår ett fel: inlägg får inte vara tom!");
            return;
        }

        // If both inputs are valid, create a new GuestbookEntry object and add it to the list of entries.
        entries.Add(new GuestbookEntry { Owner = owner, Text = text });
        Console.WriteLine("Inlägg är tillagd!");
    }

    // This method removes a post based on its index number.
    public void RemovePosts()
    {
        ShowPosts();
        Console.WriteLine("Skriv index att ta bort: ");

        if (int.TryParse(Console.ReadLine(), out int index))
        {
            if (index >= 0 && index < entries.Count)
            {
                entries.RemoveAt(index);
                Console.WriteLine("Inlägg är borttagen!");
            }
            else
            {
                Console.WriteLine("Felaktigt: index ligger utanför listan.");
            }
        }
        else
        {
            Console.WriteLine("Felaktigt: ogiltig siffra.");
        }
    }

    // Method to saves all guestbook entries to a JSON file.
    public void SaveToFile()
    {
        string json = JsonSerializer.Serialize(entries);
        File.WriteAllText(filePath, json);
    }

    /*
    * Method to loads guestbook entries from a JSON file if it exists,and if the file is emty we do nothing and the guestbook will simply start empty.
    */
    public void LoadFromFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            entries =
                JsonSerializer.Deserialize<List<GuestbookEntry>>(json)
                ?? new List<GuestbookEntry>();
        }
    }
}
