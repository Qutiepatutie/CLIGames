using CLIGames.Games;

namespace CLIGames.UI;

public class Menu
{
    public static void Show()
    {
        Console.Clear();
        int pos = 0;
        int items = 3;
        while (true)
        {
            PrintMenu(pos);

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    Console.Clear();
                    return;
                
                case ConsoleKey.DownArrow:
                    pos = (pos == (items-1)) ? 0 : pos += 1 ;
                    break;
                
                case ConsoleKey.UpArrow:
                    pos = (pos == 0) ? (items-1) : pos -= 1;
                    break;
                
                case ConsoleKey.Enter:
                    Console.Clear();
                    
                    if(pos == 0)
                        NumberGuessingGame.Run();
                    else if(pos == 1)
                        WordleGame.Run();
                    else if(pos == 2)
                        PewPew.Run();
                    break;

            }
        }
    }

    public static void PrintMenu(int pos)
    {
        Console.SetCursorPosition(0,0);

        Console.WriteLine("(Press Esc to exit)");
        Console.WriteLine("Select using arrow keys\n");
        Console.WriteLine("Select a game:");

        Console.WriteLine($"{(pos == 0 ? "->" : "  ")} Number Guessing Game");
        Console.WriteLine($"{(pos == 1 ? "->" : "  ")} Wordle");
        Console.WriteLine($"{(pos == 2 ? "->" : "  ")} PewPew");

    }
}