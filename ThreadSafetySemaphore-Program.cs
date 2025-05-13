using System;
using System.Threading;

public class SharedResource
{
    private static Semaphore semaphore = new Semaphore(3, 3); // Initial count: 3, maximum count: 3
    private int resourceValue = 0;
    public int ResourceValue => resourceValue;

    public void AccessResource(string threadName)
    {
        Console.WriteLine($"{threadName} is requesting access to the resource.");
        // Wait until a semaphore slot is available.
        semaphore.WaitOne();
        Console.WriteLine($"{threadName} has entered the resource.");

        try
        {
            // Access the shared resource.
            Console.WriteLine($"{threadName} is in the critical section. resourceValue: {resourceValue}");
            resourceValue++;
            Console.WriteLine($"{threadName} incremented resourceValue to {resourceValue}.");
            Thread.Sleep(1000); // Simulate some work.
        }
        finally
        {
            // Release a semaphore slot.
            semaphore.Release();
            Console.WriteLine($"{threadName} has released the resource.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SharedResource sharedResource = new SharedResource();

        // Create multiple threads.  More than the maximum semaphore count.
        Thread thread1 = new Thread(() => sharedResource.AccessResource("Thread 1"));
        Thread thread2 = new Thread(() => sharedResource.AccessResource("Thread 2"));
        Thread thread3 = new Thread(() => sharedResource.AccessResource("Thread 3"));
        Thread thread4 = new Thread(() => sharedResource.AccessResource("Thread 4"));
        Thread thread5 = new Thread(() => sharedResource.AccessResource("Thread 5"));


        // Start the threads.
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();
        thread5.Start();

        // Wait for the threads to finish.
        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();
        thread5.Join();

        Console.WriteLine("Main thread finished. resourceValue: " + sharedResource.ResourceValue);
        Console.ReadLine();
    }
}
