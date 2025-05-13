
using System;
using System.Threading;

public class SharedResource
{
    private int resourceValue = 0;
    private object resourceLock = new object(); // Lock object for the Monitor

    public void AccessResource(string threadName)
    {
        // Try to acquire the lock.  This will block if another thread holds it.
        Monitor.Enter(resourceLock); // Equivalent to lock(resourceLock)
        try
        {
            Console.WriteLine($"{threadName} has entered the critical section.");
            resourceValue++; // Access and modify the shared resource
            Console.WriteLine($"{threadName} incremented resourceValue to {resourceValue}.");
            Thread.Sleep(500); // Simulate some work
        }
        finally
        {
            // Ensure the lock is always released, even if an exception occurs.
            Monitor.Exit(resourceLock);
            Console.WriteLine($"{threadName} has exited the critical section.");
        }
    }

    public void AccessResourceWithTimeout(string threadName)
    {
        //Try to enter the lock, with a timeout
        if (Monitor.TryEnter(resourceLock, 1000)) // Try to get lock for 1 second
        {
            try
            {
                Console.WriteLine($"{threadName} has entered the critical section with timeout.");
                resourceValue++;
                Console.WriteLine($"{threadName} incremented resourceValue to {resourceValue}.");
                Thread.Sleep(500);
            }
            finally
            {
                Monitor.Exit(resourceLock);
                Console.WriteLine($"{threadName} has exited the critical section with timeout.");
            }
        }
        else
        {
            Console.WriteLine($"{threadName} was unable to enter the critical section within the timeout.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SharedResource sharedResource = new SharedResource();

        // Create multiple threads to access the resource
        Thread thread1 = new Thread(() => sharedResource.AccessResourceWithTimeout("Thread 1"));
        Thread thread2 = new Thread(() => sharedResource.AccessResourceWithTimeout("Thread 2"));
        Thread thread3 = new Thread(() => sharedResource.AccessResourceWithTimeout("Thread 3"));


        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();


        Console.WriteLine("Main thread finished.");
        Console.ReadLine();
    }
}
