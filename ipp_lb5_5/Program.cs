//////////////////////////////////////////
//  Лабораторная работа #3  | Вариант 5 //
//  Студент Киуки-20-5 Мавринский А.Д.  //
//////////////////////////////////////////

using System.Threading.Channels;

void inlinePrintMatrixAdds(long[,] matrix1, long[,] matrix2, long[,] matrix3, long matrixRange, long maxValue=2)
{
    Console.Clear();
    for (long i = 0; i < matrixRange; i++) {
        for (long w = 0; w < matrixRange; w++) {
            string space = "";
            for (int sp = 0; sp <= 100.ToString().Length - matrix1[i, w].ToString().Length ; sp++) space += " ";
            Console.Write($"{matrix1[i,w]} "+space);
        }
        Console.Write("\t+\t");
        for (long w = 0; w < matrixRange; w++) {
            string space = "";
            for (int sp = 0; sp <= 100.ToString().Length - matrix2[i, w].ToString().Length ; sp++) space += " ";
            Console.Write($"{matrix2[i,w]} "+ space);
        }
        Console.Write("\t=>\t");
        for (long w = 0; w < matrixRange; w++) {
            string space = "";
            for (int sp = 0; sp <= maxValue.ToString().Length - matrix3[i, w].ToString().Length ; sp++) space += " ";
            Console.Write($"{matrix3[i,w]} "+space);
        }
        Console.WriteLine();
    }
}

// ##########
const long matrixRange = 8;
const int threadCount = 8;
const int maxRndValue = 100;
long maxValue = 0;
Thread[] threads;

long[,] rand(long matrixRange) {
    long[,] matrix = new long[matrixRange, matrixRange];
    for (long i = 0; i < matrixRange; i++) {
        Random rnd = new Random();
        for (long w = 0; w < matrixRange; w++) {
            matrix[i, w] = rnd.Next(0, maxRndValue);
        }
    }
    return matrix;
}

long[,] matrix1 = rand(matrixRange);
long[,] matrix2 = rand(matrixRange);
long[,] matrix3 = new long[matrixRange,matrixRange];

void Job() {
    threads = new Thread[threadCount];
    var range = (int)Math.Ceiling((double)matrixRange / threadCount);
    for (int i = 0; i < threadCount; i++) {
        long start = i * range,
            end = start + range - 1;
        if (start > matrixRange - 1) break;
        if (end > matrixRange - 1) end = matrixRange - 1;
        threads[i] = new Thread(() => { SumRange(start, end); });
        threads[i].Start();
        threads[i].Join();
    }
}

void SumRange(long start, long end) {
    for (long i = start; i <= end; i++) {
        for (long j = 0; j < matrixRange; j++) {
            matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
            if (matrix3[i, j] > maxValue) maxValue = matrix3[i, j];
        }
    }
}


Job();
Console.WriteLine("########################################");
inlinePrintMatrixAdds(matrix1, matrix2, matrix3, matrixRange, maxValue);
Console.WriteLine("########################################");

long[] rowSquare = new long[matrixRange];

//Parallel square matrix rows;
for (long i = 0; i < matrixRange; i++) {
    Parallel.For(0, matrixRange, w => {
        rowSquare[i] += matrix3[i, w]; });
}

Console.Write($"Matrix rows sum array: ");
foreach(var elem in rowSquare) Console.Write($"{elem} ");
Console.WriteLine();

Console.WriteLine($"Arithmetic mean: {(double)rowSquare.Sum()/matrixRange}");