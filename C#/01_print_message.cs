using System;
using System.Threading;

class Program {
    static void Main(string[] args) {
        for (int i = 0; i < 10; i++) {
            Thread thread = new Thread(() => {
                Console.WriteLine("Thread {0} is running.", Thread.CurrentThread.ManagedThreadId);
            });
            thread.Start();
        }
    }
}
