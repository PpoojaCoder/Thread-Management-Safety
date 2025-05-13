using System;
using System.Threading;

public class SharedResource
{
    private static Mutex mutex = new Mutex(false, "MyMutex"); // Named mutex shared across threads
    private int resourceValue = 0; // Shared resource
    private string resourceUser;

    // Property to access resourceValue from outside (Main method)
    public int ResourceValue => resourceValue;

    public void AccessResource(string threadName)
    {
        Console.WriteLine($"{threadName} is requesting the mutex.");

        // Request the mutex (waits if another thread is inside)
        mutex.WaitOne();
        Console.WriteLine($"{threadName} has acquired the mutex.");

        resourceUser = threadName;

        try
        {
            // Critical section begins
            Console.WriteLine($"{threadName} is in the critical section. resourceValue: {resourceValue}, accessed by: {resourceUser}");
            resourceValue++;
            Console.WriteLine($"{threadName} incremented resourceValue to {resourceValue}.");
            Thread.Sleep(2000); 
        }
        finally
        {
            // Critical section ends
            mutex.ReleaseMutex();
            Console.WriteLine($"{threadName} has released the mutex.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SharedResource sharedResource = new SharedResource();

        // Create multiple threads accessing the same shared resource
        Thread thread1 = new Thread(() => sharedResource.AccessResource("Thread 1"));
        Thread thread2 = new Thread(() => sharedResource.AccessResource("Thread 2"));
        Thread thread3 = new Thread(() => sharedResource.AccessResource("Thread 3"));

        // Start the threads
        thread1.Start();
        thread2.Start();
        thread3.Start();

        // Wait for all threads to finish
        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("Main thread finished. Final resourceValue: " + sharedResource.ResourceValue);
        Console.ReadLine(); 
    }
}
