using System;
using System.Threading;
using System.Threading.Tasks;

public class Kitchen
{
    private int specialIngredientsAvailable = 10; // Shared resource
    private object pantryLock = new object(); // The "access badge" - lock object

    // Method for a chef to try to get ingredients
    public void GetSpecialIngredients(string chefName, int quantityNeeded)
    {
        // Use a lock to control access to the shared resource
       lock (pantryLock)
        {
            Console.WriteLine($"{chefName} is trying to get {quantityNeeded} special ingredients.");

            if (specialIngredientsAvailable >= quantityNeeded)
            {
                // Chef has the "badge" (lock), can access the ingredients
                specialIngredientsAvailable -= quantityNeeded;
                Console.WriteLine($"{chefName} got {quantityNeeded} special ingredients. Remaining: {specialIngredientsAvailable}");
            }
            else
            {
                // Not enough ingredients
                Console.WriteLine($"{chefName} could not get ingredients. Not enough available. Remaining: {specialIngredientsAvailable}");
            }
        } // The lock is released here, like returning the "badge"
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Kitchen sharedKitchen = new Kitchen(); // Create one shared kitchen (shared resource)

        // Create multiple chefs (threads)
        Thread chef1 = new Thread(() => sharedKitchen.GetSpecialIngredients("Chef Alice", 5));
        Thread chef2 = new Thread(() => sharedKitchen.GetSpecialIngredients("Chef Bob", 7));
        Thread chef3 = new Thread(() => sharedKitchen.GetSpecialIngredients("Chef Carol", 3));

        // Start the chefs (threads)
        chef1.Start();
        chef2.Start();
        chef3.Start();

        // Wait for all chefs to finish (optional, but good practice in console apps)
        chef1.Join();
        chef2.Join();
        chef3.Join();

        Console.WriteLine("All chefs have finished trying to get ingredients.");
        Console.ReadLine(); // Keep the console window open
    }
}

