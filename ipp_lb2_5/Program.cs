//////////////////////////////////////////
//  Лабораторная работа #2  | Вариант 5 //
//  Студент Киуки-20-5 Мавринский А.Д.  //
//////////////////////////////////////////


using System.Diagnostics;

internal class Program {

    private static Mutex _mutex = new Mutex();
    private static int count = 0;
    private static long oversum = 0;

    private static void Main(string[] args) {
        List<Thread> threads = new List<Thread>();
        for (int i = 0; i < 5; i++) {
            Thread thread = new Thread(work);
            thread.Name = $"Thread {i}";
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads) { thread.Join(); }
        Console.WriteLine($"OVERSUM={oversum}");
    }

    private static void work() {
        _mutex.WaitOne();
        long sum = 0;
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = count + 1; i <= count + 20000; i++) { sum += i; }

        stopWatch.Stop();
        Interlocked.Add(ref oversum, sum);
        TimeSpan ts = stopWatch.Elapsed;
        Console.WriteLine(
            $"{Thread.CurrentThread.Name}:\tRANGE=({count + 1}:{count + 20000})\tSUM= {sum}\tIntimeSum= {oversum}\tTIME= " +
            String.Format("{0:00}:{1:00}.{2:000}",
                ts.Minutes.ToString(), ts.Seconds.ToString(),
                ts.Milliseconds.ToString()) + $"\tTICK= {stopWatch.ElapsedTicks}"
            + $"\tPRIORITY={Thread.CurrentThread.Priority}");
        Interlocked.Add(ref count, 20000);
        _mutex.ReleaseMutex();
    }
}