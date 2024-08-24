//////////////////////////////////////////
//  Лабораторная работа #1  | Вариант 5 //
//  Студент Киуки-20-5 Мавринский А.Д.  //
//////////////////////////////////////////


// Моя частота процессора 3.5 ГГЦ, так что
// приведенная скорость в ms не покажет время выполнения операций с малой нагрузкой
// В таком случае я прошел к решению - воспользоваться измерением в тактах.

using System.Diagnostics;

class Worker {
    public Func<int[], long> currentFunc;
    public int[] dep;
    public long timeTick;
    
    public Worker(Func<int[], long> calcMethod, int[] dep) {
        this.currentFunc = calcMethod;
        this.dep = dep;
        this.timeTick = getCalcTicks(this.currentFunc, this.dep);
    }

    public void StartThread(int priority=2) {
        Thread thread = genThreadCalc(this.currentFunc, this.dep,priority);
        thread.Start();
    }
    
    private static long getCalcTicks(Func<int[], long> calcMethod, int[] dep) {
        Stopwatch time = new Stopwatch();
        time.Start();
        calcMethod(dep);
        time.Stop();
        return time.ElapsedTicks;
    }
    
    public static Thread genThreadCalc(Func<int[],long> calcMethod, int[] dep, int priority = 2,  string threadName = "") {
        Stopwatch stopWatch = new Stopwatch();
        Thread newThread = new Thread(() => {
            stopWatch.Start();
            var sum = calcMethod(dep);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"{Thread.CurrentThread.Name}:\tSUM= {sum}\tTIME= " +
                              String.Format("{0:00}:{1:00}.{2:000}",
                                  ts.Minutes.ToString(), ts.Seconds.ToString(),
                                  ts.Milliseconds.ToString()) + $"\tTICK= {stopWatch.ElapsedTicks}"
                              +$"\tPRIORITY={Thread.CurrentThread.Priority}");
        });

        newThread.Priority = (ThreadPriority)priority;
        newThread.Name = String.IsNullOrWhiteSpace(threadName)
            ? "thread_" + calcMethod.Method.Name.ToString()
            : threadName;

        return newThread;
    }
}

internal class Program
{
    private static object locker = new object();
    private static void Main(string[] args) {
        Stopwatch timer = new Stopwatch();
        
        // ДО
        
        List<Thread> threads = new List<Thread>() {
            Worker.genThreadCalc(calcSumInt, new int[] { 1, 10000 }),
            Worker.genThreadCalc(calcSumEvenInt, new int[] { 1000, 20000 }),
            Worker.genThreadCalc(calcSumOddInt, new int[] { 3000, 21000 })
        };
        
        timer.Start();
        foreach (var thread in threads) { thread.Start(); }
        foreach (var thread in threads) { thread.Join(); }
        timer.Stop();
        
        Console.WriteLine($"OVERTIME= {timer.ElapsedTicks}");

        timer.Reset();
        Console.WriteLine("-------");
        // ПОСЛЕ

        List<Worker> workers = new List<Worker>() {
            new Worker(calcSumInt, new int[] { 1, 10000 }),
            new Worker(calcSumEvenInt, new int[] { 1000, 20000 }),
            new Worker(calcSumOddInt, new int[] { 3000, 21000 })
        };
        
        //Приоритетности: Lowest=0 | BelowNormal=1 | Normal=2 | AboveNormal=3 | Highest=4
        
        //Сортируем по скорости операции
        workers.Sort((x,y)=>x.timeTick<y.timeTick?1:0); // 1 --> 0
        int i = 0;
        foreach (var worker in workers) {
            Console.Write($"{worker.currentFunc.Method.Name}.timeTick={worker.timeTick}(P={(ThreadPriority)i})" + (i==workers.Count-1?"\n":"\t"));
            i++;
        }
        //Обновляем лист потоков
        // Также можно воспользоваться ThreadPool , но в танной примере не буду усложнять им логику
        threads = new List<Thread>();

        // Запускаем с приоритетом
        timer.Start();
        for(i=0;i<workers.Count;i++) {
            Thread thread = Worker.genThreadCalc(workers.ElementAt(i).currentFunc, workers.ElementAt(i).dep, i);
            thread.Start();
            threads.Add(thread);
        }
        foreach (var thread in threads) { thread.Join(); }
        timer.Stop();
        
        Console.WriteLine($"OVERTIME= {timer.ElapsedTicks}");

        
    }

    private static long calcSumInt(int[] dep) {
        lock (locker)
        {
            long sum = 0;
            for (int i = dep[0]; i <= dep[1]; i++) {
                sum += i;
            }
            return sum;
        }
    }
    
    private static long calcSumEvenInt(int[] dep) {
        lock (locker) {
            long sum = 0;
            for (int i = dep[0]; i <= dep[1]; i++) {
                sum += i % 2 == 0 ? i : 0;
            }
            return sum; 
        }
    }
    
    private static long calcSumOddInt(int[] dep) {
        lock (locker) {
            long sum = 0;
            for (int i = dep[0]; i <= dep[1]; i++) {
                sum += i % 2 == 0 ? 0 : i;
            }
            return sum;   
        }
    }
}