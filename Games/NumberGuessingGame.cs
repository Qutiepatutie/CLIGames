using CLIGames.UI;

namespace CLIGames.Games;

public static class NumberGuessingGame
{
    public static void Run()
    {
        Random rand = new();

        int guesses = 5;
        int guess;
        int randomNum = rand.Next(1, 101);

        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("You have only 5 Guesses for this game\n");

        bool isStart = Prompt.PrintPlay("Do you want to start now?",Console.CursorTop);
        if(!isStart)
        {
            Console.WriteLine("Goodbye!");
            Thread.Sleep(600);
            Console.Clear();
            return;
        }
        
        Console.Clear();
        do
        {
            guess = ValidateInput("Guess: ", 1, 100);   
            --guesses;
            
            PrintResult(randomNum, guess, guesses);

            if(guesses == 0 || guess == randomNum)
            {
                bool doReplay = Prompt.PrintPlay("Do you want to play again?", Console.CursorTop); 
                if(!doReplay)
                {
                    Console.WriteLine("Goodbye!");
                    Thread.Sleep(600);
                    Console.Clear();
                    return;   
                }
                Console.Clear();
                guesses = 5;
                randomNum = rand.Next(1, 101);
            }
        }
        while (guesses != 0);
        Console.Clear();

    }

    private static int ValidateInput(string prompt, int min, int max)
    {
        int input;
        while (true)
        {
            Console.Write(prompt);
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                if(input > max || input < min)
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                    continue;
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid number.");   
                continue;
            }

            return input;
        }
    }
    private static void PrintResult(int randomNum, int guess, int guesses)
    {
        if (guess == randomNum)
        {
            Console.WriteLine("\nCongratulations! You Guessed The Number Right!");
            Console.WriteLine($"The number was: {randomNum}\n");
        }
        else if(guesses > 0 && guess != randomNum)
        {
            Console.WriteLine(guess > randomNum ? "\nLower!" : "\nHigher!");    
            Console.WriteLine($"You have {guesses} guesses left!\n");
        }

        if(guesses == 0 && guess != randomNum)
        {
            Console.WriteLine("\nNice Try!");
            Console.WriteLine($"The number was: {randomNum}\n");
        }
    }
}