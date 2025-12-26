namespace CLIGames.Util;

public class ConsoleHelper
{
    private static int oWidth;
    private static int oHeight;
    private static int oBWidth;
    private static int oBHeight;
    
    public static void ResizeWindow(int width, int height)
    {
        oWidth = Console.WindowWidth;
        oHeight = Console.WindowHeight;
        oBWidth = Console.BufferWidth;
        oBHeight = Console.BufferHeight;

        Console.CursorVisible = false;
        Console.Title = "PewPew";
        if (OperatingSystem.IsWindows())
        {
            int maxWidth = Math.Min(width, Console.LargestWindowWidth);
            int maxHeight = Math.Min(height, Console.LargestWindowHeight);

            Console.SetWindowSize(maxWidth, maxHeight);
            Console.SetBufferSize(maxWidth, maxHeight);
        }
    }
    public static void ResetWindowSize()
    {
        Console.Clear();
        if (OperatingSystem.IsWindows())
        {
            Console.SetWindowSize(oWidth, oHeight);
            Console.SetBufferSize(oBWidth, oBHeight);
        }
        Console.CursorVisible = true;
    }
}