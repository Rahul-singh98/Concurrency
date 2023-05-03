using System;
using System.IO;
using System.Threading;

class Program
{
    static void WriteToFile(string fileName, int idx)
    {
        using (StreamWriter writer = File.AppendText(fileName))
        {
            writer.WriteLine("Thread{0} wrote to file", idx);
        }
    }

    static void Main(string[] args)
    {
        string fileName = "shared_file.txt";
        Thread[] threads = new Thread[10];

        for (int i = 0; i < 10; i++)
        {
            threads[i] = new Thread(() => WriteToFile(fileName, i));
            threads[i].Start();
        }

        for (int i = 0; i < 10; i++)
        {
            threads[i].Join();
        }
    }
}
