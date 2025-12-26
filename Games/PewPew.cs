using CLIGames.Util;

namespace CLIGames.Games;

public class PewPew
{
    public static void Run()
    {
        bool moveLeft = false;
        bool moveRight = false;

        string[] ship =
        {

        "      ***      ",
        "**   *   *   **",
        "*****     *****",
        "**  *     *  **",  
        "   *       *   ",
        "   *********   ",
        "    *******    ",
        "     *****     "
        }; 

        string[] projectile =
        {
        "|             |",
        "@             @",
        };

        ConsoleHelper.ResizeWindow(80,55);
        Console.Clear();

        List<(int x, int y)> projectiles = new List<(int x, int y)>();
        int projectileHeight = projectile.Length;
        int projectileWidth = projectile[0].Length;

        int fireRate = 10;

        int frame = 0;

        int moveSpeed = 2;

        int shipHeight = ship.Length;
        int shipWidth = ship[0].Length;

        int posX = (Console.WindowWidth - shipWidth) / 2;
        int posY = Console.WindowHeight - shipHeight;

        //ConsoleKeyInfo key;

        while (true)
        {
            frame++;

            EraseShip(posX, posY, shipHeight,shipWidth);
            EraseProjectiles(projectiles, projectileHeight, projectileWidth);

            // Input for ship movement
            moveLeft = moveRight = false;
            while(Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        moveLeft = true;
                        break;
                    case ConsoleKey.RightArrow:
                        moveRight = true;
                        break;
                    case ConsoleKey.Escape:
                        ConsoleHelper.ResetWindowSize();
                        Console.Title = "CLI Games";
                        return;
                }
            }

            if(moveLeft)
                posX = Math.Max(0, posX - moveSpeed);
            
            if(moveRight)
                posX = Math.Min(Console.WindowWidth - shipWidth - 1, posX + moveSpeed);

            // Fire projectiles
            if(frame % fireRate == 0)
            {
                int projX = posX + (shipWidth - projectileWidth) / 2;
                projectiles.Add((projX, posY - 1));
            }

            MoveProjectiles(projectiles);
            DrawProjectiles(projectiles, projectile, projectileHeight);
            DrawShip(posX,posY, shipHeight, ship);

            Thread.Sleep(1);
        }
    }

    private static void EraseShip(int posX, int posY, int shipHeight, int shipWidth)
    {
        for(int i = 0; i < shipHeight; i++)
        {
            Console.SetCursorPosition(posX, posY + i);
            Console.Write(new string(' ', shipWidth));
        }
    }

    private static void DrawShip(int posX, int posY, int shipHeight, string[] ship)
    {

        // Draw ship
        for(int i = 0; i < shipHeight; i++)
        {
            Console.SetCursorPosition(posX, posY + i);
            Console.Write(ship[i]);
        }
    }
    private static void EraseProjectiles(List<(int x, int y)> projectiles, int projectileHeight, int projectileWidth)
    {
        foreach (var p in projectiles)
        {
            for(int i = 0; i < projectileHeight; i++)
            {
                int projY = p.y - i;
                if(projY >= 0)
                {
                    Console.SetCursorPosition(p.x, projY);
                    Console.Write(new string(' ', projectileWidth));
                }
            }
        }
    }

    private static void MoveProjectiles(List<(int x, int y)> projectiles)
    {
        // Move Projectiles
        for(int i = projectiles.Count - 1; i >= 0; i--)
        {
            projectiles[i] = (projectiles[i].x, projectiles[i].y - 1);

            if(projectiles[i].y < 0) projectiles.RemoveAt(i);
        }
    }

    private static void DrawProjectiles(List<(int x, int y)> projectiles, string[] projectile, int projectileHeight)
    {
        // Draw projectiles
        foreach (var p in projectiles)
        {
            for(int i = 0; i < projectileHeight; i++)
            {
                int projY = p.y - i;
                if(projY >= 0)
                {
                    Console.SetCursorPosition(p.x, projY);
                    Console.Write(projectile[i]);
                }
            }
        }
    }

}