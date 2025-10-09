using System;
using System.Threading;

namespace AddressBook.Utilities
{
    public static class Utilities
    {
        // METHOD TO MAKE A LOADER AUTOMATION IN THE CONSOLE
        public static void Loader()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }
        }

        // METHOD TO MAKE A STOP IN THE CONSOLE
        public static void Stop()
        {
            Console.WriteLine("\nPress any key to return to menu");
            Console.ReadKey();
        }

        // METHOD TO PRINT A MESSAGE (HEADER) IN THE CONSOLE
        public static void OrderMessage(string message)
        {
            Console.WriteLine(message);
        }

        // METHOD TO CHECK IF THE USER WANTS TO GO BACK TO THE PREVIOUS MENU
        public static bool Back(string input)
        {
            return input?.ToLower() == "0";
        }

        // METHOD TO SAFELY READ A LINE FROM THE CONSOLE WITHOUT WARNINGS
        public static string SafeReadLine()
        {
            return (Console.ReadLine() ?? "").Trim();
        }

        // METHOD TO HIGHLIGHT THE MATCHING PART OF A STRING
        public static void HighlightMatch(string text, string search)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(search))
            {
                Console.Write(text);
                return;
            }

            int index = 0;
            string lowerText = text.ToLower();
            string lowerSearch = search.ToLower();

            while (index < text.Length)
            {
                int matchIndex = lowerText.IndexOf(lowerSearch, index);
                if (matchIndex == -1)
                {
                    Console.Write(text.Substring(index));
                    break;
                }

                if (matchIndex > index)
                {
                    Console.Write(text.Substring(index, matchIndex - index));
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(text.Substring(matchIndex, search.Length));
                Console.ResetColor();

                index = matchIndex + search.Length;
            }
        }
    }
}
