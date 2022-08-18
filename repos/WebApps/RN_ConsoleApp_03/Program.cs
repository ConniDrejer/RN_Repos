using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

class Program
{
    /// <summary>
    /// This Console app uses simphoreSlim to check and control the number of simultaneously threads - in this case 3 - to make a pause, the method sleeps 3 second between items in the list
    /// My Comments: Again - I found an example on Google and changed it to fit the demands
    /// </summary>
    private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 3);
    static async Task Main()
    {
        int counter = 0;
        string[] array =
         {
                "string 01",
                "string 02",
                "string 03",
                "string 04",
                "string 05",
                "string 06",
                "string 07",
                "string 08",
                "string 09",
                "string 10",
                "string 11",
                "string 12",
                "string 13",
                "string 14",
                "string 15",
                "string 16",
                "string 17",
                "string 18",
                "string 19",
                "string 20",
                "string 21",
                "string 22",
                "...Test"
            };
        try
        {
            foreach (string value in array)
            {
                counter++;
                Console.WriteLine("counter: " + counter + " threadID: " + Thread.CurrentThread.ManagedThreadId);
                //await Function1(counter); // I haad to make new instance of Program because of static/non-static issues 
                Program p = new Program();
                await p.Function1(counter);
                Console.WriteLine("counter: " + counter + " threadID: " + Thread.CurrentThread.ManagedThreadId + Environment.NewLine);
            }
        }
        catch (Exception ex)
        {
            string error = "Unexpected error: " + ex.Message;
            Console.WriteLine(error);
        }
    }

    private async Task Function1(int counter)
    {
        try
        {
            await _semaphoreSlim.WaitAsync();
            await Task.Run(() => Function2(counter));
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    private void Function2(int counter)
    {
        Console.WriteLine("Function2 start" + " counter: " + counter + " threadID: " + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(3000);//Sleeps in 3 seconds
        Console.WriteLine("Function2 end" + " counter: " + counter + " threadID: " + Thread.CurrentThread.ManagedThreadId);
        return;
    }
}

