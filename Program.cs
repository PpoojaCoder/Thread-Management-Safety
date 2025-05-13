using System;
using System.Threading;

class Program
{
    // Method to simulate chopping vegetables
    static void ChopVegetables()
    {
        Console.WriteLine("Chopping vegetables...");
        Thread.Sleep(1000); // Simulate 1 second of chopping
        Console.WriteLine("Vegetables chopped!");
    }

    // Method to simulate stirring the soup
    static void StirSoup()
    {
        Console.WriteLine("Stirring soup...");
        Thread.Sleep(500); // Simulate 1.5 seconds of stirring
        Console.WriteLine("Soup stirred!");
    }

    // Method to simulate baking bread
    static void BakeBread()
    {
        Console.WriteLine("Baking bread...");
        Thread.Sleep(3000); // Simulate 3 seconds of baking
        Console.WriteLine("Bread baked!");
    }

    static void Main(string[] args)
    {
        // Create threads for each cooking task
        Thread chef1 = new Thread(ChopVegetables);
        Thread chef2 = new Thread(StirSoup);
        Thread chef3 = new Thread(BakeBread);

        // Start all threads
        chef1.Start(); // Chef 1 starts chopping
        chef2.Start(); // Chef 2 starts stirring
        chef3.Start(); // Chef 3 starts baking

        // Wait for all threads to finish (optional, can be omitted)
        chef1.Join(); // Wait for Chef 1 (ChopVegetables) to finish
        chef2.Join(); // Wait for Chef 2 (StirSoup) to finish
        chef3.Join(); // Wait for Chef 3 (BakeBread) to finish

        // Final message after all tasks are done
        Console.WriteLine("Meal is ready!");
    }
}
