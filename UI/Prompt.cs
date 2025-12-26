namespace CLIGames.UI;

public static class Prompt
{
    public static bool PrintPlay(string prompt, int y)
    {
        int pos = 0;
        while (true)
        {
            Console.SetCursorPosition(0,y);
            Console.WriteLine(prompt);
            Console.WriteLine($"{((pos == 0) ? "->" : "  ")} Yes");
            Console.WriteLine($"{((pos == 1) ? "->" : "  ")} No");

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    pos = (pos == 0) ? 1 : 0;
                    break;
                case ConsoleKey.DownArrow:
                    pos = (pos == 1) ? 0 : 1;
                    break;
                case ConsoleKey.Enter:
                    if(pos == 0)
                        return true;
                    else
                        return false;
            }
        }
    }
}