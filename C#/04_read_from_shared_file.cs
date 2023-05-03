using System;
using System.IO;
using System.Threading;

class Program {
    static void Main() {
        string filePath = "shared_file.txt";
        var fileContent = File.ReadAllText(filePath);

        var threads = new Thread[10];
        for (int i = 0; i < threads.Length; i++) {
            threads[i] = new Thread(() => ReadFile(filePath));
            threads[i].Start();
        }

        foreach (var thread in threads) {
            thread.Join();
        }
    }

    static void ReadFile(string filePath) {
        var threadId = Thread.CurrentThread.ManagedThreadId;
        var content = File.ReadAllText(filePath);
        Console.WriteLine("Thread {0} read from file: {1}", threadId, content);
    }
}
