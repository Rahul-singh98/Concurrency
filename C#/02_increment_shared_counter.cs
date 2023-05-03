using System;
using System.Threading;

class Program
{
    static int counter = 0;
    static readonly object lockObject = new object();

    static void Increment()
    {
        lock (lockObject)
        {
            counter++;
        }
        Console.WriteLine("Counter value: {0}", counter);
    }

    static void Main(string[] args)
    {
        Thread[] threads = new Thread[10];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(Increment);
            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("All threads completed");
        Console.WriteLine("Final counter value: {0}", counter);
    }
}
