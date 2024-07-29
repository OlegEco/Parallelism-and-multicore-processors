using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;


var tasks = new List<Task>();
var stopwatch = Stopwatch.StartNew();

for (int i = 0; i <= 250; i++)
{
    int taskId = i;
    tasks.Add(Task.Run(() => DoWork2(taskId, stopwatch)));
}

await Task.WhenAll(tasks);
Console.WriteLine("All tasks comleted.");


static void Multy()
{
    Parallel.Invoke(
        () => DoWork(1),
        () => DoWork(2),
        () => DoWork(3),
        () => DoWork(4)
    );
    Console.WriteLine("All tasks completed");
}

static void DoWork(int taskID)
{
    Console.WriteLine($"Task {taskID} is starting on thread {Task.CurrentId}");
    Task.Delay(1000).Wait();
    Console.WriteLine($"Task {taskID} is completed on thread {Task.CurrentId}");
}

static void DoWork2(int taskID, Stopwatch stopwatch)
{
    Console.WriteLine($"Task {taskID} is starting. Times: {stopwatch.Elapsed.TotalSeconds:F1} sec");
    Task.Delay(2000).Wait();
    Console.WriteLine($"Task {taskID} is completed. Times: {stopwatch.Elapsed.TotalSeconds:F1} sec");
}
