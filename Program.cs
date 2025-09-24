// This file will contain Main() and menu
using System;

namespace laboration3;

class Program
{
    // Created a new Guestbook object that will hold all guestbook entries in memory (list).
    static void Main(string[] args)
    {
        Guestbook guestbook = new Guestbook();
        guestbook.LoadFromFile();

        /*
        * Used an infinite loop so the menu keeps showing until the user chooses to exit. We print the menu options so the user knows what they can do.
        */
        while (true)
        {
            Console.WriteLine("=== Gästbook ===");
            Console.WriteLine("1.Visa alla inlägg");
            Console.WriteLine("2.Lägg till inlägg");
            Console.WriteLine("3.Ta bort inlägg");
            Console.WriteLine("4.Avslut");

            string choice = Console.ReadLine();

            /*
            * Used a switch statement to decide what action to take based on the choice. You can show all post that are currently in the guestbook, add a new post, remove a post and save all the posts to a file.
            */
            switch (choice)
            {
                case "1":
                    guestbook.ShowPosts();
                    break;
                case "2":
                    guestbook.AddPosts();
                    break;
                case "3":
                    guestbook.RemovePosts();
                    break;
                case "4":
                    guestbook.SaveToFile();
                    break;
                default:
                    Console.WriteLine("Felaktigt val, försök igen!");
                    break;
            }

            // Wait for the user to press a key before showing the menu again.
            Console.WriteLine("\nTryck på valfri tanget.");
            Console.ReadKey();
        }
    }
}
