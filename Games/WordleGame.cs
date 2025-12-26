using CLIGames.UI;

namespace CLIGames.Games;

public class WordleGame
{
    public static void Run()
    {
        Console.Title = "Wordle";

        string[] words = {"Sample", "Connect", "Hello", "Computer"};
        Random rand = new();
        
        string randWord = words[rand.Next(0,words.Length)].ToLower();
        int wordLength = randWord.Length;

        Console.WriteLine("Welcome to Wordle!");
        Console.WriteLine("You have 6 gueses for this game\n");

        bool isPlay = Prompt.PrintPlay("Do you want to start now?", Console.CursorTop);
        if (!isPlay)
        {
            Console.WriteLine("Goodbye!");
            Thread.Sleep(600);
            Console.Clear();
            Console.Title = "CLI Games";
            return;
        }
        string[] attempts = {"","","","","",""};

        int guesses = 6;
        string guess = "";
        
        while (guesses != 0)
        {
            Console.WriteLine();
            for(int i = 0; i < 6; i++)
            {
                if(attempts[i] == "")
                {
                    for(int j=0; j < wordLength; j++)
                        Console.Write("_ ");
                }
                else
                {
                    foreach (char c in attempts[i])
                    {
                        if (!randWord.Contains(c))
                            Console.ForegroundColor = ConsoleColor.Gray;
                        else if(attempts[i].IndexOf(c) == randWord.IndexOf(c))
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.Write(c + " ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }

            if(guess == randWord)
            {
                Console.WriteLine("\nYou Win!");
                bool doReplay = Prompt.PrintPlay("Do you want to play again?", Console.CursorTop);

                if(!doReplay)
                {
                    Console.Write("Goodbye!");
                    Thread.Sleep(600);
                    Console.Clear();
                    Console.Title = "CLI Games";
                    return;
                }
                guesses = 6;
                attempts = new string[] {"","","","","",""};
                randWord = words[rand.Next(0,words.Length)].ToLower();
                wordLength = randWord.Length;
                Console.Clear();
            }

            while (true)
            {
                Console.Write("\nGuess: ");
                guess = Console.ReadLine() ?? "";

                if(guess.Length != wordLength)
                {
                    Console.WriteLine($"Please enter only {wordLength} letter words");
                    continue;
                }
                break;
            }
            attempts[6 - guesses] = guess.ToLower() ?? "";
            guesses--;
        }
    }

}